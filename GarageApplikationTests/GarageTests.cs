using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageApplikation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplikation.Tests
{
    [TestClass()]
    public class GarageTests
    {
        [TestInitialize]
        public void TestInitializer()
        {
            Garage garage = new Garage(10);
        }
        [TestMethod()]
        public void GarageTest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }
    }
}