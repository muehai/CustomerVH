using System;
using System.Collections.Generic;
using Xunit;
using VehiclesApp.Controllers;
using VehiclesApp.Models;
using VehiclesApp.Infrastructure;
using Moq;
using VehiclesApp.UtilityExtension;

namespace VehiclesXUnitTesting
{
    public class VehiclesTest
    {

        [Fact]
        public void vehicleObjTypeTest()
        {
            var customerRepository = new CustomersRepositor();
            var controller = new VehiclesController(customerRepository);

            var result = controller.Index();
            Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);

        }

        [Fact]
        public void VehileListAccounts()
        {

            var customerRepository = new CustomersRepositor();
            var controller = new VehiclesController(customerRepository);
            var result = Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(controller.Index());
            var model = Assert.IsType<List<Customers>>(result.Model);
            Assert.Equal(21, model.Count);

        }

        [Fact]
        public void VerifyVehicleCustomers()
        { 
            var customerRepository = new Mock<IVehiclesRepository>();

            customerRepository.Setup(m => m.CustomersList()).Returns(new List<Customers>
            {
                new Customers(), new Customers(), new Customers(), new Customers(), new Customers(), new Customers(), new Customers(),
                new Customers(), new Customers(), new Customers(), new Customers(), new Customers(), new Customers(), new Customers(),
                new Customers(), new Customers(), new Customers(), new Customers(), new Customers(), new Customers(), new Customers(),

            });
            //Check if the constructor is passed the obj
            var controller = new VehiclesController(customerRepository.Object);
            var result = Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(controller.Index());
            var model = Assert.IsType<List<Customers>>(result.Model);
            Assert.Equal(21, model.Count);  
        }

        [Fact]
        public void VerifyCustomersDetailsReturnAction()
        {
            VehicleStatus Temp_Enumvalue = VehicleEnumExtension.Of<VehicleStatus>();
            var customerRepos = new Mock<IVehiclesRepository>();
            customerRepos.Setup(v => v.GetCustomersById(It.IsAny<string>())).Returns(new Customers {
                VIN = "YS2R4X20005399401",
                RegNr = "ABC123",
                CustomersName = "Kalles Grustransporter AB",
                CustomerAddresses = "Cementvägen 8, 111 11 Södertälje",
                ConnectionStatus = Temp_Enumvalue,
                VehicleconnectedTime = DateTime.Now,
            });

            var controller = new VehiclesController(customerRepos.Object);
            var result = Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(controller.Detail("YS2R4X20005399401"));
            var model = Assert.IsType<Customers>(result.Model);
            Assert.Equal("ABC123", model.RegNr);
        }

    }
}
