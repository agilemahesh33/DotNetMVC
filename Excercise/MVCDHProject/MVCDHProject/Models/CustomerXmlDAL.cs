﻿using System.Data;

namespace MVCDHProject.Models
{
    public class CustomerXmlDAL : ICustomerDAL
    {
        DataSet ds;
        public CustomerXmlDAL()
        {
            ds = new DataSet();
            ds.ReadXml("Customer.xml");
            //Below Array because of PK can be composite PK
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["Custid"] };
        }
        public List<Customer> Select_Customers()
        {
            List<Customer> Customers = new List<Customer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Customer customer = new Customer()
                {
                    Custid = Convert.ToInt32(dr["Custid"]),
                    Name = Convert.ToString(dr["Name"]),
                    Balance = Convert.ToDecimal(dr["Balance"]),
                    City = Convert.ToString(dr["City"]),
                    Status = Convert.ToBoolean(dr["Status"])
                };
                Customers.Add(customer);
            }
            return Customers;
        }
        public Customer Select_Customer(int CustId)
        {
            //Find DR based on the Primary key value
            DataRow dr = ds.Tables[0].Rows.Find(CustId);
            Customer customer = new Customer()
            {
                Custid = Convert.ToInt32(dr["Custid"]),
                Name = Convert.ToString(dr["Name"]),
                Balance = Convert.ToDecimal(dr["Balance"]),
                City = Convert.ToString(dr["City"]),
                Status = Convert.ToBoolean(dr["Status"])
            };
            return customer;
        }
        public void Customer_Insert(Customer customer)
        {
            //Creating a new DataRow based on the DataTable structure
            DataRow dr = ds.Tables[0].NewRow();
            //Assigning values to each Column of the DataRow
            dr["Custid"] = customer.Custid;
            dr["Name"] = customer.Name;
            dr["Balance"] = customer.Balance;
            dr["City"] = customer.City;
            dr["Status"] = customer.Status;
            //Adding the new DataRow to DataTable
            ds.Tables[0].Rows.Add(dr);
            //Saving data back to XML file
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Update(Customer customer)
        {
            //Finding a DataRow based on its Primary Key value
            DataRow dr = ds.Tables[0].Rows.Find(customer.Custid);
            //Finding the Index of DataRow by calling IndexOf method
            int Index = ds.Tables[0].Rows.IndexOf(dr);
            //Overriding the old values in DataRow with new values based on the Index
            ds.Tables[0].Rows[Index]["Name"] = customer.Name;
            ds.Tables[0].Rows[Index]["Balance"] = customer.Balance;
            ds.Tables[0].Rows[Index]["City"] = customer.City;
            //Saving data back to XML file
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Delete(int Custid)
        {
            //Finding a DataRow based on its Primary Key value
            DataRow dr = ds.Tables[0].Rows.Find(Custid);
            //Finding the Index of DataRow by calling IndexOf method
            int Index = ds.Tables[0].Rows.IndexOf(dr);
            //Deleting the DataRow from DataTable by using Index
            ds.Tables[0].Rows[Index].Delete();
            //Saving data back to XML file
            ds.WriteXml("Customer.xml");
        }

    }
}
