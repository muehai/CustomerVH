using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesApp.Models
{
    //Vehicle status to check if the 
    //customer vehicles are sending connection status 
    public enum VehicleStatus
    {
        [Description("Connected")]
        Connected = 1 ,
        [Description("Unconnected")]
        Unconnected = 2
    }
    //Customer classe represneting the vehicles entities
    public class Customers
    {   
        public string VIN { get; set; } // Vehicle Id 
        public string RegNr { get; set; } // Vehicle register number
        [Required]
        public string CustomersName { get; set; } // Customer and owner of Vehicles
        public string CustomerAddresses { get; set; } // Customer Address
        [EnumDataType(typeof(VehicleStatus))]
        public VehicleStatus ConnectionStatus { get; set; } // Vehicle connection status 
        public DateTime VehicleconnectedTime { get; set; }  // Vehicle connection timestamp
        
        


    }




}
