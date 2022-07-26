using CineMAster.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineMAster
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataBase database = DataBase.GetInstance();

            var formFactory = CompositionRoot();
            Application.Run(formFactory.CreateForm1());
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
              .ConfigureServices((context, services) => {
                  services.AddTransient<INewCinemaHall, NewCinemaHall>();
                  services.AddTransient<IDataBaseOperations, DataBaseOperations>();
                  services.AddTransient<NewCinemaHall>();
                  services.AddTransient<Form4>();
                  services.AddTransient<Form1>();
                  
                  services.AddTransient<FormHallParameters>();
                  services.AddTransient<Func<int,int,FormNewCinemaHall>>(container => (something1,something) =>
                  {
                      var databaseOperation = container.GetRequiredService<IDataBaseOperations>();
                      NewCinemaHall newCinemaHall = container.GetRequiredService<NewCinemaHall>();
                    
                      return new FormNewCinemaHall(databaseOperation,newCinemaHall,something1,something);
                  });
                  
              });
        }


        static IFormFactory CompositionRoot()
        {
            //host
            var hostBuilder = CreateHostBuilder();
            var host = hostBuilder.Build();

            //container
            var serviceProvider = host.Services;

            //form factory
            var formFactory = new FormFactoryImpl(serviceProvider);
            FormFactory.SetProvider(formFactory);

            return formFactory;
        }
    }
}
