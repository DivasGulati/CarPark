using CarPark.Application;
using CarPark.Core;
using CarPark.Core.DomainModel.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarPark.Tests
{
    [TestClass]
    public class CarParkTests : BaseTest
    {    

        [TestMethod]
        public void EarlyBirdTest_Entry_7Nov2019_Time_11_11_11_Exit_7Nov2019_Time_16_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019,11,7,7,11,11); // Thrusday Morning 7 am 
            var exitDateTime = new DateTime(2019, 11, 7,16, 0, 0, 0); // Thrusday Afternoon 4 pm

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);
            
            //Assert
            Assert.AreEqual<double>(rate, 13.0);

        }


        [TestMethod]
        public void Negative_EarlyBirdTest_Entry_7Nov2019_Time_11_11_11_Exit_7Nov2019_Time_23_31_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 7, 7, 11, 11); 
            var exitDateTime = new DateTime(2019, 11, 7, 23, 31, 0); 

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreNotEqual<double>(rate, 13.0);

        }


        [TestMethod]
        public void NightTest_Entry_7Nov2019_Time_19_11_11_Exit_8Nov2019_Time_5_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 7, 19, 11, 11); // Thrusday Morning 7 pm 
            var exitDateTime = new DateTime(2019, 11, 8, 5, 0, 0, 0); // Thrusday Afternoon 4 pm

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 6.5);

        }

        
        [TestMethod]
        public void WeekEndTest_Entry_9Nov2019_Time_1_0_0_Exit_10Nov2019_Time_23_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 9, 1, 0, 0); // Saturday Morning 1 am 
            var exitDateTime = new DateTime(2019, 11, 10, 23, 0, 0, 0); // Sunday Night 11 pm

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 10.0);

        }

        [TestMethod]
        public void StandardTest_Entry_9Nov2019_Time_1_0_0_Exit_10Nov2019_Time_23_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 7, 12, 0, 0); // Saturday Morning 1 am 
            var exitDateTime = new DateTime(2019, 11, 7, 13, 0, 0, 0); // Monday Morning 5 am

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 5);

        }

        [TestMethod]
        public void StandardTest_Entry_7Nov2019_Time_12_0_0_Exit_7Nov2019_Time_13_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 7, 12, 0, 0);  
            var exitDateTime = new DateTime(2019, 11, 7, 13, 0, 0, 1);

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 10);

        }


        [TestMethod]
        public void StandardTest_Entry_7Nov2019_Time_12_0_0_Exit_7Nov2019_Time_14_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 7, 12, 0, 0);  
            var exitDateTime = new DateTime(2019, 11, 7, 14, 0, 1, 0); 

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 15);

        }


        [TestMethod]
        public void StandardTest_Entry_7Nov2019_Time_12_0_0_Exit_7Nov2019_Time_17_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 7, 12, 0, 0); 
            var exitDateTime = new DateTime(2019, 11, 7, 17, 0, 0, 0); 

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 20);

        }

        [TestMethod]
        public void StandardTest_Entry_9Nov2019_Time_1_0_0_Exit_11Nov2019_Time_5_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 9, 1, 0, 0); 
            var exitDateTime = new DateTime(2019, 11, 11, 5, 0, 0, 0); 

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 60.0);

        }

        [TestMethod]
        public void StandardTest_Entry_9Nov2019_Time_1_0_0_Exit_11Nov2019_Time_1_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 9, 1, 0, 0); 
            var exitDateTime = new DateTime(2019, 11, 11, 1, 0, 0);

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 45.0);

        }


        [TestMethod]
        public void StandardTest_Entry_9Nov2019_Time_1_0_0_Exit_11Nov2019_Time_2_0_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 9, 1, 0, 0);  
            var exitDateTime = new DateTime(2019, 11, 11, 2, 0, 0, 0); 

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 50.0);

        }


        [TestMethod]
        public void StandardTest_Entry_9Nov2019_Time_1_0_0_Exit_11Nov2019_Time_2_1_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 9, 1, 0, 0); 
            var exitDateTime = new DateTime(2019, 11, 11, 2, 1, 0); 

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 55.0);

        }


        [TestMethod]
        public void StandardTest_Entry_7Nov2019_Time_23_0_0_Exit_8Nov2019_Time_23_1_0()
        {
            //Arrange
            var rateService = _serviceProvider.GetService<IRateService>();
            var entryDateTime = new DateTime(2019, 11, 7, 23, 0, 0); 
            var exitDateTime = new DateTime(2019, 11, 8, 23, 1, 0);

            //Act
            var rate = rateService.CalculateRate(entryDateTime, exitDateTime);

            //Assert
            Assert.AreEqual<double>(rate, 40.00);

        }
    }
}
