using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using VehiclesApp.Models;
using VehiclesApp.UtilityExtension;
using VehiclesApp.VehicleVM;
using VehiclesApp.Infrastructure;


namespace VehiclesApp.Controllers
{
    public class VehiclesController : Controller
    {
        private IVehiclesRepository customerRepository; // Testing for Mocking
        private CustomersRepositor  customer_timer_ = new CustomersRepositor();
        
        //List to populate customer data
        List<Customers> Vehicle_list; 

        //temp_list to store the copied customer data
        List<Customers> temp_list = new List<Customers>();

     
        public VehiclesController(IVehiclesRepository cr)
        {
            Vehicle_list = new List<Customers>();
            customerRepository = cr;
            Vehicle_list = customerRepository.CustomersList();
            
           
          }

        [HttpGet]
        public IActionResult Index()
        {
            //Send connection status
            customer_timer_.StartingTimer();
            return View(Vehicle_list);
        }

        [HttpPost]
        public IActionResult Index(string sortOrder,string vehicleSearchStr, Customers c) // sortOrder
        {
            ViewData["CoustomerVehParm"] = String.IsNullOrEmpty(sortOrder) ? "VehicleName_Desc" : "";
            ViewData["VehicleStatusParm"] =  sortOrder == "connectionstatus" ? "connectionstatus_desc" : "connectionstatus";
            ViewData["VehicleFilteData"] = vehicleSearchStr;

            //string vehiclesId = customers
            ViewBag.ErrorMessage = "No such data found";

            // Create VehicleViewMode obj
            VehiclesVM vm = new VehiclesVM();
           
            //Copy the model data list
            var vm_list = from v in Vehicle_list
                                  select v;
            //Initialize the VehicleViewModel
            vm.vehiclesLst = vm_list.ToList();

            //string vehiclesId = customers

            ViewBag.SelectedValue = c.CustomersName;
            
               ViewBag.CustomerVehicles = vm.vehiclesLst.Where(v => v.ConnectionStatus == c.ConnectionStatus).ToString();


            if (!String.IsNullOrEmpty(vehicleSearchStr))
            {
                vm.vehiclesLst = vm.vehiclesLst.Where(v => v.CustomersName.Contains(vehicleSearchStr) || Convert.ToString(v.ConnectionStatus).Contains(vehicleSearchStr));

            }

             if (vehicleSearchStr == null)
             {
                return RedirectToAction("ErrorMessage", "Vehicles");

             }

            Customers customer = vm.vehiclesLst.FirstOrDefault(cus => cus.CustomersName == vehicleSearchStr);
            if (customer == null)
            {
                ViewBag.FoundMessage = "There is no such customer names.";
            }

               
            switch (sortOrder)
            {
               case "VehicleName_Desc":
                  vm.vehiclesLst = vm.vehiclesLst.OrderByDescending(v => v.CustomersName);
                  break;
               //case "connectionstatus":
               //     vm.vehiclesLst = vm.vehiclesLst.OrderBy(v => v.ConnectionStatus);
               //     break;
               //case "connectionstatus_desc":
               //     vm.vehiclesLst = vm.vehiclesLst.OrderByDescending(v => v.ConnectionStatus);
               // break;
                default:
                    vm.vehiclesLst = vm.vehiclesLst.OrderByDescending(v => v.ConnectionStatus);
                    break;
            }


            //Pass and show the vehicles data
            return View(vm.vehiclesLst);
        }

        public IActionResult ErrorMessage()
        {
          return View();
        }


        public IActionResult Detail(string vin)
        {
            var customer = customerRepository.GetCustomersById(vin);

            if (customer == null)
            {
                return View("Customer is not found.");
            }

            else
            {
                return View(customer);
            }
        }

    }
}