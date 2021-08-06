using System;
using System.Collections.Generic;
using System.Data;
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
        /// <summary>
        /// Method to insert the data into column
        /// </summary>
        /// <param name="Person"></param>
        public int InsertIntoDataTable(AddressBookData Person)
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
            //display the table
            DisplayDataTable();
            return dataTable.Rows.Count;
        }
        /// <summary>
        /// Add row into the data table
        /// </summary>
        /// <param name="Person"></param>
        public void AddRowintoDataTable(AddressBookData Person)
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

        /// <summary>
        /// Method to display the data table
        /// </summary>
        public void DisplayDataTable()
        {
            //display the rows
            foreach (DataRow row in dataTable.Rows)
            {
                
                Console.WriteLine($"{row["FirstName"]} | { row["LastName"]} | {row["Address"]} | {row["City"]} | {row["State"]} | {row["ZipCode"]} | {row["PhoneNumber"]} | {row["Email"]}\n");
            }
        }
    }
}
