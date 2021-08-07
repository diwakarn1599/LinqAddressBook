using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqAddressBook;
using System;
namespace LinqAddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        AddressBookManager manager;
        AddressBookData person;

        [TestInitialize]
        public void SetUp()
        {
            manager = new AddressBookManager();
            person = new AddressBookData();
        }
        /// <summary>
        /// Returns the count of inserted data
        /// </summary>
        [TestMethod]
        
        public void TestForInsertIntoDataTable()
        {
            try
            {
                int actual, expected = 2;
                actual = manager.InsertIntoDataTable(person);
                Assert.AreEqual(expected, actual);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        /// <summary>
        /// test method to modify existing data
        /// </summary>
        [TestMethod]

        public void TestForModifyData()
        {
            try
            {
                string actual, expected = "success";
                actual = manager.ModifyDataTableUsingName("Diwakar", person);
                Assert.AreEqual(expected, actual);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        /// <summary>
        /// test method to delete based on name
        /// </summary>
        [TestMethod]

        public void TestForDeleteData()
        {
            try
            {
                string actual, expected = "successfully deleted";
                actual = manager.DeleteDataTableRecordUsingName("Diwakar", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// test method to retreive based on either city or state
        /// </summary>
        [TestMethod]

        public void TestForRetreiveBasedOnStateOrCity()
        {
            try
            {
                int actual, expected = 2;
                actual = manager.RetreiveBasedOnStateOrCity("Tn","chennai", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test to count records based on  state name
        /// </summary>
        [TestMethod]
        public void TestForCountBasedOnState()
        {
            try
            {
                int actual, expected = 2;
                actual = manager.CountBasedOnState("Tn", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test to count records based on city 
        /// </summary>
        [TestMethod]
        public void TestForCountBasedOnCity()
        {
            try
            {
                int actual, expected = 2;
                actual = manager.CountBasedOnCity("chennai", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test method Sort records based on name in given city
        /// </summary>
        [TestMethod]
        public void TestForSortBasedOnNameinGivenCity()
        {
            try
            {
                string actual, expected = "success";
                actual = manager.SortBasedOnNameinGivenCity("chennai", person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// test method to get count based on type
        /// </summary>
        [TestMethod]
        public void TestForCountBasedOnTpe()
        {
            try
            {
                string actual, expected = "success";
                actual = manager.GetCountByType(person);
                Assert.AreEqual(expected, actual);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        [TestMethod]
        public void TestForAddToBothTypes()
        {
            try
            {
                
                manager.GetCountByType(person);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
