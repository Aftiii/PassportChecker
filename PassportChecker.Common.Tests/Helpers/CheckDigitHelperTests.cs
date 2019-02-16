using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PassportChecker.Common.Helpers;

namespace PassportChecker.Common.Tests.Helpers
{
    [TestClass]
    public class CheckDigitHelperTests_CalculateCheckDigit
    {
        [TestMethod]
        public void CalculateCheckDigit_With_Valid_Data_Returns_Valid_CheckDigit()
        {
            string input = "586479869<<<";
            /* Math below
            5 = 5 * 7 = 35
            8 = 8 * 3 = 24
            6 = 6 * 1 = 6
            4 = 4 * 7 = 28
            7 = 7 * 3 = 21
            9 = 9 * 1 = 9
            8 = 8 * 7 = 56
            6 = 6 * 3 = 18
            9 = 9 * 1 = 9
            0 = 0 * 7 = 0
            0 = 0 * 3 = 0
            0 = 0 * 1 = 0
            35 + 24 + 6 + 28 + 21 + 9 + 56 + 18 + 9 + 0 + 0 + 0  = 206 % 10 = 6 */
            int expectedCheckDigit = 6;

            int returnedCheckDigit = CheckDigitHelper.CalculateCheckDigit(input);

            Assert.AreEqual(expectedCheckDigit, returnedCheckDigit);

        }
        [TestMethod]
        public void CalculateCheckDigit_With_Invalid_Data_Returns_Exception()
        {
            string input = "5^123(()";

            Assert.ThrowsException<ArgumentException>(() => CheckDigitHelper.CalculateCheckDigit(input));
        }

    }
}
