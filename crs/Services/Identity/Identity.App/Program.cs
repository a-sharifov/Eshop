using Microsoft.AspNetCore.Server.Kestrel.Core;

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

              webBuilder.ConfigureKestrel(options =>
              {
                  options.ListenAnyIP(Env.HTTP_PORT, listenOptions =>
                  {
                      listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                  });
                  
                  options.ListenAnyIP(Env.GRPC_PORT, listenOptions =>
                  {
                      listenOptions.Protocols = HttpProtocols.Http2;
                  });
              });

              webBuilder.UseStartup<Startup>();
          });
