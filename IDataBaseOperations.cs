using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMAster
{
    public interface IDataBaseOperations
    {
        void Save(NewCinemaHall newHall);
    }
}
