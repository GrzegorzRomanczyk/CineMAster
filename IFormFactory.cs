using CineMAster.Forms;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMAster
{
    interface IFormFactory
    {
        Form1 CreateForm1();
        FormHallParameters CreateFormHallParameters();
        FormNewCinemaHall CreateFormNewCinemaHall( int collumns, int rows);
        Form4 CreateForm4();
    }
    class FormFactory : IFormFactory
    {
        static IFormFactory _provider;

        public static void SetProvider(IFormFactory provider)
        {
            _provider = provider;
        }
        public Form1 CreateForm1()
        {
            return _provider.CreateForm1();
        }

        public Form4 CreateForm4()
        {
            return _provider.CreateForm4();
        }

        public FormHallParameters CreateFormHallParameters()
        {
            return _provider.CreateFormHallParameters();
        }

        public FormNewCinemaHall CreateFormNewCinemaHall(int collumns, int rows)
        {
            return _provider.CreateFormNewCinemaHall(collumns,rows);
        }
    }

    public class FormFactoryImpl : IFormFactory
    {
        private IServiceProvider _serviceProvider;

        public FormFactoryImpl(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }
        public Form1 CreateForm1()
        {
            return _serviceProvider.GetRequiredService<Form1>();
        }

        public Form4 CreateForm4()
        {
            return _serviceProvider.GetRequiredService<Form4>();
        }

        public FormHallParameters CreateFormHallParameters()
        {
            return _serviceProvider.GetRequiredService<FormHallParameters>();
        }

        public FormNewCinemaHall CreateFormNewCinemaHall(int collumns, int rows)
        {
            var _form3Factory = _serviceProvider.GetRequiredService<Func<int,int, FormNewCinemaHall>>();
            return _form3Factory(collumns,rows);
        }
    }
}
