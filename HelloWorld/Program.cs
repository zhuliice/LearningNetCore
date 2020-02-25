using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

namespace HelloWorld
{
    class Program
    {
        static public string DefaultConnectionString { get; } = @"Server=";
        static IReadOnlyDictionary<string, string> DefaultConnectionStrings { get; } =
            new Dictionary<string, string>()
            {
                ["Profile:Username"] = Environment.UserName,
                [$"AppCofiguration:ConnectionString"] = DefaultConnectionString,
            };

        static public IConfiguration Configuration { get; set; }
        
        static void Main(string[] args)
        {           
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(DefaultConnectionStrings);
            configurationBuilder.AddJsonFile("appsettings.json", true, true);

            Configuration = configurationBuilder.Build();

            Console.SetWindowSize(Int32.Parse(Configuration["AppConfiguration:MainWindow:Width"]), Int32.Parse(Configuration["AppConfiguration:MainWindow:Height"]));

            Console.WriteLine($"Hello {Configuration.GetValue<string>("Profile:Username")}!");
            Console.WriteLine($"Hello {Configuration.GetValue<string>("AppConfiguration:MainWindow:Top")}!");

            Console.ReadKey();
        }
    }
}
