using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Bike : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("DRIVE BIKE!!!");
        }
    }
}
