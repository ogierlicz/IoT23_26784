using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CdvAzure.Functions;
using Lab1.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddDbContext<PeopleDb>(options=>{
            var connectionString = "Server=tcp:iot23dbserver.database.windows.net,1433;Initial Catalog=iot23db;Persist Security Info=False;User ID=ogierlicz;Password=1@qwerty;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            options.UseSqlServer(connectionString);
        });
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
        services.AddSingleton<PeopleService>();
    })
    .Build();

host.Run();