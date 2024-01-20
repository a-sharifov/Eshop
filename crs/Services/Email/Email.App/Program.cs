var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddYamlFile(
    "appsettings.yml", optional: true, reloadOnChange: true);

var app = builder.Build();