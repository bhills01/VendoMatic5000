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
        public void DepositFiveTest()
        {
            //Arrange

            //Act
            VendingMachine depositFive = new VendingMachine();
            depositFive.Deposit(5);
            //Assert
            Assert.AreEqual(5, depositFive.Balance);
        }
        [TestMethod]
        public void DepositTenTest()
        {
            //Arrange

            //Act
            VendingMachine depositTen = new VendingMachine();
            depositTen.Deposit(10);
            //Assert
            Assert.AreEqual(10, depositTen.Balance);

        }
        [TestMethod]
        public void DepositTwentyTest()
        {
            //Arrange

            //Act
            VendingMachine depositTwenty = new VendingMachine();
            depositTwenty.Deposit(20);
            //Assert
            Assert.AreEqual(20, depositTwenty.Balance);

        }
        [TestMethod]
        public void DepositThirteenTest()
        {
            //Arrange

            //Act
            VendingMachine depositThirteen = new VendingMachine();
            depositThirteen.Deposit(13);
            //Assert
            Assert.AreEqual(13, depositThirteen.Balance);

        }
        [TestMethod]
        public void DepositTwentySevenTest()
        {
            //Arrange

            //Act
            VendingMachine depositTwentySeven = new VendingMachine();
            depositTwentySeven.Deposit(27);
            //Assert
            Assert.AreEqual(27, depositTwentySeven.Balance);

        }
        [TestMethod]
        public void DepositTooBigTest()
        {
            //Arrange

            //Act
            VendingMachine depositTooBig = new VendingMachine();
            depositTooBig.Deposit(100000000);

            //Assert
            Assert.AreEqual(0, depositTooBig.Balance);
        }
        [TestMethod]
        public void DepositLessThanZeroTest()
        {
            //Arrange

            //Act
            VendingMachine depositLessThanZero = new VendingMachine();
            depositLessThanZero.Deposit(-150);
            //Assert
            Assert.AreEqual(0, depositLessThanZero.Balance);
        }
        [TestMethod]
        public void DepositZeroTest()
        {
            //Arrange

            //Act
            VendingMachine depositLessThanZero = new VendingMachine();
            depositLessThanZero.Deposit(0);
            //Assert
            Assert.AreEqual(0, depositLessThanZero.Balance);
        }
        [TestMethod]
        public void SpendFiveTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Balance = 5;

            //Act
            testVend.Spend(5);

            //Assert
            Assert.AreEqual(0, testVend.Balance);
        }
        [TestMethod]
        public void InsufficientFundsTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Balance = 3;

            //Act
            testVend.Spend(5);

            //Assert
            Assert.AreEqual(3, testVend.Balance);
        }
        [TestMethod]
        public void DispenseNormalTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine
            {
                Balance = 5
            };
            testVend.Load();
            Slots testSlot = new Slots("A1")
            {
                Amount = 5                
            };
           
            //Act

            testVend.Dispense(testSlot);

            //Assert
            Assert.AreEqual(testSlot.Amount = 4, testSlot.Amount);
            Assert.AreEqual(testVend.Balance = 1.95m, testVend.Balance);
        }
        [TestMethod]
        public void DispenseSoldOutTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine
            {
                Balance = 5
            };
            testVend.Load();
            Slots testSlot = new Slots("A1")
            {
                Amount = 0
            };

            //Act

            testVend.Dispense(testSlot);

            //Assert
            Assert.AreEqual(testSlot.Amount = 0, testSlot.Amount);
            Assert.AreEqual(testVend.Balance = 5, testVend.Balance);
        }
        [TestMethod]
        public void VendingLoadAmountTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Load();

            //Act
            Slots testSlotA1 = new Slots("A1");
            Slots testSlotA2 = new Slots("A2");
            Slots testSlotA3 = new Slots("A3");
            Slots testSlotA4 = new Slots("A4");
            Candy testCandy = new Candy("Test Candy", 2);
            Chips testChips = new Chips("Test Chips", 2);
            Drink testDrink = new Drink("Test Drink", 2);
            Gum testGum = new Gum("Test Gum", 2);

            //Assert
            Assert.AreEqual(5, testSlotA1.Amount);
            Assert.AreEqual(5, testSlotA2.Amount);
            Assert.AreEqual(5, testSlotA3.Amount);
            Assert.AreEqual(5, testSlotA4.Amount);
        }
        [TestMethod]
        public void VendingLoadSlotTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Load();

            //Act
            Slots testSlotA1 = new Slots("A1");
            Slots testSlotA2 = new Slots("A2");
            Slots testSlotA3 = new Slots("A3");
            Slots testSlotA4 = new Slots("A4");
            Candy testCandy = new Candy("Test Candy", 2);
            Chips testChips = new Chips("Test Chips", 2);
            Drink testDrink = new Drink("Test Drink", 2);
            Gum testGum = new Gum("Test Gum", 2);

            //Assert
            Assert.AreEqual("A1", testSlotA1.SlotID);
            Assert.AreEqual("A2", testSlotA2.SlotID);
            Assert.AreEqual("A3", testSlotA3.SlotID);
            Assert.AreEqual("A4", testSlotA4.SlotID);
        }        
        [TestMethod]
        public void VendingLoadNameTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Load();

            //Act
            Slots testSlotA1 = new Slots("A1");
            Slots testSlotA2 = new Slots("A2");
            Slots testSlotA3 = new Slots("A3");
            Slots testSlotA4 = new Slots("A4");
            Candy testCandy = new Candy("Test Candy", 2);
            Chips testChips = new Chips("Test Chips", 2);
            Drink testDrink = new Drink("Test Drink", 2);
            Gum testGum = new Gum("Test Gum", 2);

            //Assert
            Assert.AreEqual("Test Candy", testCandy.Name);
            Assert.AreEqual("Test Chips", testChips.Name);
            Assert.AreEqual("Test Drink", testDrink.Name);
            Assert.AreEqual("Test Gum", testGum.Name);
        }        
        [TestMethod]
        public void VendingLoadSlotPriceTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Load();

            //Act
            Slots testSlotA1 = new Slots("A1");
            Slots testSlotA2 = new Slots("A2");
            Slots testSlotA3 = new Slots("A3");
            Slots testSlotA4 = new Slots("A4");
            Candy testCandy = new Candy("Test Candy", 2);
            Chips testChips = new Chips("Test Chips", 2);
            Drink testDrink = new Drink("Test Drink", 2);
            Gum testGum = new Gum("Test Gum", 2);

            //Assert
            Assert.AreEqual(2, testCandy.Price);
            Assert.AreEqual(2, testChips.Price);
            Assert.AreEqual(2, testDrink.Price);
            Assert.AreEqual(2, testGum.Price);
        }        
        [TestMethod]
        public void VendingLoadMessageTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Load();

            //Act
            Slots testSlotA1 = new Slots("A1");
            Slots testSlotA2 = new Slots("A2");
            Slots testSlotA3 = new Slots("A3");
            Slots testSlotA4 = new Slots("A4");
            Candy testCandy = new Candy("Test Candy", 2);
            Chips testChips = new Chips("Test Chips", 2);
            Drink testDrink = new Drink("Test Drink", 2);
            Gum testGum = new Gum("Test Gum", 2);

            //Assert
            Assert.AreEqual("Munch Munch, Yum!", testCandy.Message);
            Assert.AreEqual("Crunch Crunch, Yum!", testChips.Message);
            Assert.AreEqual("Glug Glug, Yum!", testDrink.Message);
            Assert.AreEqual("Chew Chew, Yum!", testGum.Message);
        }
        [TestMethod]
        public void GetChangeQuartersTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Balance = 2;
            //Act
            testVend.EndVending();

            //Assert
            Assert.AreEqual(8, testVend.quarters);
            Assert.AreEqual(0, testVend.dimes);
            Assert.AreEqual(0, testVend.nickels);
        }
        [TestMethod]
        public void GetChangeDimesTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Balance = .20m;
            //Act
            testVend.EndVending();

            //Assert
            Assert.AreEqual(0, testVend.quarters);
            Assert.AreEqual(2, testVend.dimes);
            Assert.AreEqual(0, testVend.nickels);
        }
        [TestMethod]
        public void GetChangeNickelTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Balance = .05m;
            //Act
            testVend.EndVending();

            //Assert
            Assert.AreEqual(0, testVend.quarters);
            Assert.AreEqual(0, testVend.dimes);
            Assert.AreEqual(1, testVend.nickels);
        }
        [TestMethod]
        public void GetChangeMultipleCoinsTest()
        {
            //Arrange
            VendingMachine testVend = new VendingMachine();
            testVend.Balance = 2.40m;
            //Act
            testVend.EndVending();

            //Assert
            Assert.AreEqual(9, testVend.quarters);
            Assert.AreEqual(1, testVend.dimes);
            Assert.AreEqual(1, testVend.nickels);
        }
    }
}
