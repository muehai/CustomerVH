using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesApp.Models;

namespace VehiclesApp.Infrastructure
{
    public interface IVehiclesRepository
    {
        List<Customers> CustomersList(); 
        Customers GetCustomersById(string vin);
    }
}
