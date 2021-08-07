using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LinqAddressBook
{
    public class AddressBookManager
    {
        DataTable dataTable;
        /// <summary>
        /// Method to create data table
        /// </summary>
        public void CreateDataTable()
        {
            try
            {


                dataTable = new DataTable();

                DataColumn dataColumn = new DataColumn();
                //column for Firstname 
                dataColumn.DataType = typeof(String);
                dataColumn.ColumnName = "FirstName";
                dataColumn.AutoIncrement = false;
                dataTable.Columns.Add(dataColumn);


                //column for LastName
                dataColumn = new DataColumn();
                dataColumn.DataType = typeof(String);
                dataColumn.ColumnName = "LastName";
                dataColumn.Caption = "Last Name";
                dataColumn.AutoIncrement = false;

                dataTable.Columns.Add(dataColumn);

                // column for Address 
                dataColumn = new DataColumn();
                dataColumn.DataType = typeof(String);
                dataColumn.ColumnName = "Address";
                dataColumn.AutoIncrement = false;
                dataTable.Columns.Add(dataColumn);

                // column for City 
                dataColumn = new DataColumn();
                dataColumn.DataType = typeof(String);
                dataColumn.ColumnName = "City";
                dataColumn.AutoIncrement = false;
                dataTable.Columns.Add(dataColumn);

                // column for State 
                dataColumn = new DataColumn();
                dataColumn.DataType = typeof(String);
                dataColumn.ColumnName = "State";
                dataColumn.AutoIncrement = false;
                dataTable.Columns.Add(dataColumn);

                // column for EmailId 
                dataColumn = new DataColumn();
                dataColumn.DataType = typeof(String);
                dataColumn.ColumnName = "Email";
                dataColumn.AutoIncrement = false;
                dataTable.Columns.Add(dataColumn);

                // column for Address .    
                dataColumn = new DataColumn();
                dataColumn.DataType = typeof(Int64);
                dataColumn.ColumnName = "PhoneNumber";
                dataColumn.AutoIncrement = false;
                dataTable.Columns.Add(dataColumn);

                // column for ZipCode 
                dataColumn = new DataColumn();
                dataColumn.DataType = typeof(Int32);
                dataColumn.ColumnName = "ZipCode";
                dataColumn.AutoIncrement = false;
                dataTable.Columns.Add(dataColumn);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Method to insert the data into column
        /// </summary>
        /// <param name="Person"></param>
        public int InsertIntoDataTable(AddressBookData Person)
        {
            try
            {


                //Create the table
                CreateDataTable();
                //Assign values to objects
                Person.firstName = "Diwakar";
                Person.lastName = "N";
                Person.address = "ambattur";
                Person.city = "chennai";
                Person.state = "Tn";
                Person.zipCode = 123456;
                Person.phoneNumber = 1234567890;
                Person.emailId = "asfd@sdf.com";
                //Add into table
                AddRowintoDataTable(Person);
                //Assigning second value
                Person.firstName = "Gayathri";
                Person.lastName = "Sri";
                Person.address = "Egmore";
                Person.city = "chennai";
                Person.state = "Tn";
                Person.zipCode = 158456;
                Person.phoneNumber = 1238527890;
                Person.emailId = "qrre@sdf.com";
                AddRowintoDataTable(Person);
                //Assigning third value
                Person.firstName = "Dhoni";
                Person.lastName = "MS";
                Person.address = "Ranchi";
                Person.city = "ranchi";
                Person.state = "chattisgarh";
                Person.zipCode = 158456;
                Person.phoneNumber = 8538527890;
                Person.emailId = "msd@sdf.com";
                AddRowintoDataTable(Person);
                //display the table
                DisplayDataTable();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataTable.Rows.Count;
        }
        /// <summary>
        /// Add row into the data table
        /// </summary>
        /// <param name="Person"></param>
        public void AddRowintoDataTable(AddressBookData Person)
        {
            try
            {


                //create object for datarow
                DataRow dataRow = dataTable.NewRow();
                dataRow["FirstName"] = Person.firstName;
                dataRow["LastName"] = Person.lastName;
                dataRow["Address"] = Person.address;
                dataRow["City"] = Person.city;
                dataRow["State"] = Person.state;
                dataRow["ZipCode"] = Person.zipCode;
                dataRow["PhoneNumber"] = Person.phoneNumber;
                dataRow["Email"] = Person.emailId;
                //add row into table
                dataTable.Rows.Add(dataRow);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /// <summary>
        /// modify data from the table
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="Person"></param>
        /// <returns></returns>
        public string ModifyDataTableUsingName(string name, AddressBookData Person)
        {
            string output = string.Empty;
            try
            {
                //insert into table
                InsertIntoDataTable(Person);
                var res = (from person in dataTable.AsEnumerable() where person.Field<string>("FirstName").Equals(name) select person).LastOrDefault();//returns last element satisfies the condition or default value
                if (res != null)
                {
                    res["LastName"] = "NN";
                    //display after its modified
                    Console.WriteLine("After Modification");
                    DisplayDataTable();
                    output = "successfully modified";
                    return output;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }
        /// <summary>
        /// Delete record on data table using name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Person"></param>
        /// <returns></returns>
        public string DeleteDataTableRecordUsingName(string name, AddressBookData Person)
        {
            string output = string.Empty;
            try
            {


                //insert into table
                InsertIntoDataTable(Person);
                var res = (from person in dataTable.AsEnumerable() where person.Field<string>("FirstName").Equals(name) select person).FirstOrDefault();//returns first element satisfies the condition or default value
                if (res != null)
                {
                    res.Delete();
                    //display after its deleted
                    Console.WriteLine("After Deletion");
                    DisplayDataTable();
                    output = "successfully deleted";
                    return output;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return output;
        }
        /// <summary>
        /// Retreive records based on state or city 
        /// </summary>
        /// <param name="stateName"></param>
        /// <param name="cityName"></param>
        /// <param name="Person"></param>
        /// <returns></returns>
        public int RetreiveBasedOnStateOrCity(string stateName,string cityName, AddressBookData Person)
        {
            int c=0;
            try
            {
                //insert into table
                InsertIntoDataTable(Person);
                var res = (from person in dataTable.AsEnumerable() where (person.Field<string>("State").Equals(stateName) || person.Field<string>("City").Equals(cityName)) select person);
                if (res != null)
                {
                    Console.WriteLine("After retreiving");
                    foreach (DataRow row in res)
                    {

                        Console.WriteLine($"{row["FirstName"]} | { row["LastName"]} | {row["Address"]} | {row["City"]} | {row["State"]} | {row["ZipCode"]} | {row["PhoneNumber"]} | {row["Email"]}\n");
                    }
                    c = res.Count();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return c;
            
        }
        /// <summary>
        /// Method to count to based on  state
        /// </summary>
        /// <param name="stateName"></param>
        /// <param name="cityName"></param>
        /// <param name="Person"></param>
        /// <returns></returns>
        public int CountBasedOnState(string stateName, AddressBookData Person)
        {
            int c = 0;
            try
            {
                //insert into table
                InsertIntoDataTable(Person);
                var res = (from person in dataTable.AsEnumerable() where person.Field<string>("State").Equals(stateName) select person).ToList().Count;
                c = res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return c;

        }
        /// <summary>
        /// method to count based on city
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="Person"></param>
        /// <returns></returns>
        public int CountBasedOnCity(string cityName, AddressBookData Person)
        {
            int c = 0;
            try
            {
                //insert into table
                InsertIntoDataTable(Person);
                var res = (from person in dataTable.AsEnumerable() where person.Field<string>("City").Equals(cityName) select person).ToList().Count;
                c = res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return c;

        }

        /// <summary>
        /// Method to display the data table
        /// </summary>
        public void DisplayDataTable()
        {
            try
            {
                //display the rows
                foreach (DataRow row in dataTable.Rows)
                {

                    Console.WriteLine($"{row["FirstName"]} | { row["LastName"]} | {row["Address"]} | {row["City"]} | {row["State"]} | {row["ZipCode"]} | {row["PhoneNumber"]} | {row["Email"]}\n");
                }
            }
             catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
