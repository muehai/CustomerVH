using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using VehiclesApp.Models;
using VehiclesApp.UtilityExtension;


namespace VehiclesApp.Infrastructure
{
    public class CustomersRepositor : IVehiclesRepository
    {
        VehicleStatus Temp_Enumvalue; //instance of connections status
        List<Customers> customers = null; //Store vehicle customers
        Timer timer = null; //Time which the customer connection is set to send status after 30 seconds

        public CustomersRepositor()
        {

            customers = new List<Customers>();
            //Create Vehicle obj
            InitializeVehicle();
            
        }

        public void StartingTimer()
        {
            SetTimer();
            timer.Stop();
            timer.Dispose();
        }

        //Set timer to start afte 30 seconds
        public void SetTimer()
        {
            timer = new System.Timers.Timer(30000);
            //Set up the elapsed event for the timer. 
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        //Refresh the connection status after 30 seconds
        protected void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {

                InitializeVehicle();
               
            }
            catch (Exception ex)
            {
                throw new Exception("Timer is error!" + ex.Message);
            }
            
          }
        //Populate the Customer obj
        public void InitializeVehicle()
        {
            for (int i = 0; i < 3; i++)
            {

                Temp_Enumvalue = VehicleEnumExtension.Of<VehicleStatus>();

                Customers c1 = new Customers
                {
                    VIN = "YS2R4X20005399401",
                    RegNr = "ABC123",
                    CustomersName = "Kalles Grustransporter AB",
                    CustomerAddresses = "Cementvägen 8, 111 11 Södertälje",
                    ConnectionStatus = Temp_Enumvalue,
                    VehicleconnectedTime = DateTime.Now,
                };
                customers.Add(c1);

                Customers c2 = new Customers
                {
                    VIN = "VLUR4X20009093588",
                    RegNr = "DEF456",
                    CustomersName = "Kalles Grustransporter AB",
                    CustomerAddresses = "Cementvägen 8, 111 11 Södertälje",
                    ConnectionStatus = Temp_Enumvalue,
                    VehicleconnectedTime = DateTime.Now
                };
                customers.Add(c2);

                Customers c3 = new Customers
                {
                    VIN = "VLUR4X20009048066",
                    RegNr = "GHI789",
                    CustomersName = "Kalles Grustransporter AB",
                    CustomerAddresses = "Cementvägen 8, 111 11 Södertälje",
                    ConnectionStatus = Temp_Enumvalue,
                    VehicleconnectedTime = DateTime.Now
                };
                customers.Add(c3);
                Customers c4 = new Customers
                {
                    VIN = "YS2R4X20005388011",
                    RegNr = "JKL012 ",
                    CustomersName = "Johans Bulk AB",
                    CustomerAddresses = "Balkvägen 12, 222 22 Stockholm",
                    ConnectionStatus = Temp_Enumvalue,
                    VehicleconnectedTime = DateTime.Now
                };
                customers.Add(c4);
                Customers c5 = new Customers
                {
                    VIN = "YS2R4X20005387949",
                    RegNr = "MNO345",
                    CustomersName = "Johans Bulk AB",
                    CustomerAddresses = "Balkvägen 12, 222 22 Stockholm",
                    ConnectionStatus = Temp_Enumvalue,
                    VehicleconnectedTime = DateTime.Now
                };
                customers.Add(c5);

                Customers c6 = new Customers
                {
                    VIN = "YS2R4X20005387765",
                    RegNr = "PQR678",
                    CustomersName = "Haralds Värdetransporter AB",
                    CustomerAddresses = "Budgetvägen 1, 333 33 Uppsala",
                    ConnectionStatus = Temp_Enumvalue,
                    VehicleconnectedTime = DateTime.Now
                };

                customers.Add(c6);
                Customers c7 = new Customers
                {
                    VIN = "YS2R4X20005387055",
                    RegNr = "STU901",
                    CustomersName = "Haralds Värdetransporter AB",
                    CustomerAddresses = "Budgetvägen 1, 333 33 Uppsala",
                    ConnectionStatus = Temp_Enumvalue,
                    VehicleconnectedTime = DateTime.Now
                };

                customers.Add(c7);

            }
        }

        public Customers GetCustomersById(string vin)
        {
            return customers.Where(v => v.VIN == vin).FirstOrDefault();

        }

        public List<Customers> CustomersList()
        {
            return customers;
        }

      
    }

}

