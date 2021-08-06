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
    }
}
