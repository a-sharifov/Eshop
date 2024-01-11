var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = SD.ProjectName, Version = "v1" });
});


builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection(SD.ReverseProxySectionKey));

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapReverseProxy();
app.MapHealthChecks(SD.HealthChecksSectionKey);

app.Run();
