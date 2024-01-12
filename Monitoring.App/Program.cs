var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddYamlFile(
    "appsettings.yml", optional: true, reloadOnChange: true);

builder.Services.();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseHealthChecks("/health");
