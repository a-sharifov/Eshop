CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
              {
                  config.AddYamlFile(
                      "appsettings.yml", optional: true, reloadOnChange: true);
              });

              webBuilder.UseStartup<Startup>();
          });