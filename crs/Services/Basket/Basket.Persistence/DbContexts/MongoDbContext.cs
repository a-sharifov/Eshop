using Basket.Persistence.DbContexts.Abstractions;
using Common.Extensions;
using MongoDB.Bson.Serialization;

namespace Basket.Persistence.DbContexts;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;
    private readonly MongoClient _mongoClient;
    private readonly List<Func<Task>> _commands;

    public MongoDbContext(IOptions<MongoDbContextOptions> options)
    {
        var mongoDbContextOptions = options.Value;

        _mongoClient = new MongoClient(mongoDbContextOptions.ConnectionString);
        _database = _mongoClient.GetDatabase(mongoDbContextOptions.ConnectionString);
        _commands = [];
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        using var session = await _mongoClient.StartSessionAsync(cancellationToken: cancellationToken);
        session.StartTransaction();

        var commandTasks = _commands.Select(c => c());

        await Task.WhenAll(commandTasks);
        await session.CommitTransactionAsync(cancellationToken);

        return _commands.Count;
    }

    public IMongoCollection<T> GetCollection<T>(string name) => _database.GetCollection<T>(name);

    public void AddCommand(Func<Task> func) => _commands.Add(func);


    public static void ConfigureMapFromAssembly(Assembly assembly) =>
        assembly.DefinedTypes.Where(IsMapConfiguration)
        .Foreach(mapConfigurationType => mapConfigurationType.GetInterfaces()
        .Where(IsMapConfigurationGeneric)
        .Foreach(interfaceMapConfigurationType =>
        {
            var interfaceMapConfigurationTypeGenericArgument = interfaceMapConfigurationType.GetGenericArguments()[0];
            var bsonClassMapType = typeof(BsonClassMap<>).MakeGenericType(interfaceMapConfigurationTypeGenericArgument);
            var bsonClassMapObject = Activator.CreateInstance(bsonClassMapType);
            var configureMethod = interfaceMapConfigurationType.GetMethod("Configure");
            configureMethod!.Invoke(Activator.CreateInstance(mapConfigurationType), [bsonClassMapObject]);
        }));

    private static bool IsMapConfiguration(Type type) =>
        !type.IsInterface &&
        !type.IsAbstract &&
        type.GetInterfaces().Any(i => i.GetGenericTypeDefinition() == typeof(IMapConfiguration<>));

    private static bool IsMapConfigurationGeneric(Type type) =>
        type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IMapConfiguration<>);
}
