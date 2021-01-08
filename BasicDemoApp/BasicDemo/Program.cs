using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BasicDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) // create default builder actually sets the priority like this
                .ConfigureAppConfiguration((hostingContext, configBuilder) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    configBuilder.Sources.Clear();
                    // adding it first means it has the least priority
                    
                    configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    configBuilder.AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);

                    if (hostingContext.HostingEnvironment.IsDevelopment())
                    {
                        configBuilder.AddUserSecrets<Program>();
                    }

                    configBuilder.AddEnvironmentVariables();
                    configBuilder.AddCommandLine(args);


                    // we could change the order (not recomended)
                    // we could change appsettings.json....

                    // or if we are in production, look for other json file..

                    // or we dont need commandline ...lets get rid of them
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
