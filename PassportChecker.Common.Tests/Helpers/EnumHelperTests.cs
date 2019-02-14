using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using PassportChecker.Common.Helpers;
using PassportChecker.Common.Enums;

namespace PassportChecker.Common.Tests.Helpers
{
    [TestClass]
    public class EnumHelperTests_GetDescription
    {
        [TestMethod]
        public void GetDescription_From_FemaleGenderEnum_Returns_FemaleString()
        {
            string expectedDescription = "Female";
            string returnedDescription = "";

            returnedDescription = EnumHelper.GetDescription(Gender.Female);

            Assert.AreEqual(expectedDescription, returnedDescription);
        }
        [TestMethod]
        public void GetDescription_From_Null_ExceptionThrown()
        {
            Gender? input = null;

            Assert.ThrowsException<NullReferenceException>(() => EnumHelper.GetDescription(input));
        }
    }
    [TestClass]
    public class EnumHelperTests_GetSelectList
    {
        [TestMethod]
        public void GetSelectList_From_GenderEnum_Returns_ListOfGenders()
        {
            List<KeyValuePair<int, string>> expectedGenders = new List<KeyValuePair<int, string>>();
            List<KeyValuePair<int, string>> returnedGenders = new List<KeyValuePair<int, string>>();
            KeyValuePair<int, string> nonSpecified = new KeyValuePair<int, string>(1, "Non-specified");
            KeyValuePair<int, string> male = new KeyValuePair<int, string>(2, "Male");
            KeyValuePair<int, string> female = new KeyValuePair<int, string>(4, "Female");
            expectedGenders.Add(nonSpecified);
            expectedGenders.Add(male);
            expectedGenders.Add(female);
            
            returnedGenders = EnumHelper.GetSelectList(typeof(Gender));

            CollectionAssert.AreEqual(expectedGenders, returnedGenders);
        }
        [TestMethod]
        public void GetSelectList_From_Null_ExceptionThrown()
        {
            List<KeyValuePair<int, string>> returnedGenders = new List<KeyValuePair<int, string>>();
            Type nullType = null;

            Assert.ThrowsException<NullReferenceException>(() => EnumHelper.GetSelectList(nullType));
        }
    }
}

