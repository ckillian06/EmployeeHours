using EmployeeHours.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace EmployeeHours.Test
{
    [TestClass]
    public class TestBench
    {
        [TestMethod]
        public void Test_StandardEmployeeBreak_ExpectToSucceed()
        {
            //Arrange
            var expected = 1.33;
            var testEmployee = TestFactory.StandardEmpolyee();

            //Act
            var actual = HoursProcessor.CalculateBreakTime(testEmployee);

            //Assert
            Assert.AreEqual(expected, actual);         
        }

        [TestMethod]
        public void Test_NightShiftEmployeeBreak_ExpectToSucceed()
        {
            //Arrange
            var expected = 1.5;
            var testEmployee = TestFactory.NightShiftEmpolyee();
         
            //Act          
            var actual = HoursProcessor.CalculateBreakTime(testEmployee);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
