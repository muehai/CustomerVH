using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesApp.UtilityExtension
{
    public static class VehicleEnumExtension
    {
        //Declare random variable
        private static Random rd = new Random(Environment.TickCount);

        //declare static generic method to randomize the enum
       public static T Of<T>()
        {
            Array vehicleVal = Array.Empty<T>();
            try
            {
                if (!typeof(T).IsEnum)
                {
                    throw new InvalidOperationException("The parameter T must be Enum type.");
                 }
                 
                vehicleVal = Enum.GetValues(typeof(T));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (T)vehicleVal.GetValue(rd.Next(vehicleVal.Length));

        }

    }
}
