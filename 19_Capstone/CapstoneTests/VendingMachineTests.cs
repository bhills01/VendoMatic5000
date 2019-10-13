using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void DepositTests()
        {
            //Arrange
              // See below :)
            //Act
            VendingMachine depositFive = new VendingMachine();
            depositFive.Deposit(5);
            VendingMachine depositTen = new VendingMachine();
            depositTen.Deposit(10);
            VendingMachine depositTwenty = new VendingMachine();
            depositTwenty.Deposit(20);
            VendingMachine depositThirteen= new VendingMachine();
            depositThirteen.Deposit(13);
            VendingMachine depositTwentySeven = new VendingMachine();
            depositTwentySeven.Deposit(27);
            //Assert
            Assert.AreEqual(5, depositFive.Balance);
            Assert.AreEqual(10, depositTen.Balance);
            Assert.AreEqual(20, depositTwenty.Balance);
            Assert.AreEqual(13, depositThirteen.Balance);
            Assert.AreEqual(27, depositTwentySeven.Balance);
        }

    }
}
