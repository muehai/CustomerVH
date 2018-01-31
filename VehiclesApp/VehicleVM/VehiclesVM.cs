using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesApp.Models;
namespace VehiclesApp.VehicleVM
{
    public class VehiclesVM
    {
        public string VIN { get; set; } // Vehicle Id 
        public string RegNr { get; set; } // Vehicle register number
        public string CustomersName { get; set; } // Customer and owner of Vehicles
        public string CustomerAddresses { get; set; } // Customer Address
        public VehicleStatus ConnectionStatus { get; set; } // Vehicle connection status 
        public DateTime VehicleconnectedTime { get; set; }
       public IEnumerable<Customers> vehiclesLst { get; set; }
    }
}
