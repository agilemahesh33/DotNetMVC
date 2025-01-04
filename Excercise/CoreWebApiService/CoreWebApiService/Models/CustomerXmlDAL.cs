using System.Data;

namespace CoreWebApiService.Models
{
    public class CustomerXmlDAL : ICustomerDAL
    {
        DataSet ds;
        public CustomerXmlDAL()
        {
            ds = new DataSet();
            ds.ReadXml("Customer.xml");
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["Custid"] };
        }
        public List<Customer> Customers_Select()
        {
            List<Customer> Customers = new List<Customer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Customer obj = new Customer
                {
                    Custid = Convert.ToInt32(dr["Custid"]),
                    Name = (string)dr["Name"],
                    Balance = Convert.ToDecimal(dr["Balance"]),
                    City = (string)dr["City"],
                    Status = Convert.ToBoolean(dr["Status"])
                };
                Customers.Add(obj);
            }
            return Customers;
        }
        public Customer Customer_Select(int Custid)
        {
            DataRow dr = ds.Tables[0].Rows.Find(Custid);
            if (dr != null)
            {
                Customer obj = new Customer
                {
                    Custid = Convert.ToInt32(dr["Custid"]),
                    Name = (string)dr["Name"],
                    Balance = Convert.ToDecimal(dr["Balance"]),
                    City = (string)dr["City"],
                    Status = Convert.ToBoolean(dr["Status"])
                };
                return obj;
            }
            return null;
        }
        public void Customer_Insert(Customer customer)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = customer.Custid;
            dr[1] = customer.Name;
            dr[2] = customer.Balance;
            dr[3] = customer.City;
            dr[4] = customer.Status;
            ds.Tables[0].Rows.Add(dr);
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Update(Customer customer)
        {
            DataRow dr = ds.Tables[0].Rows.Find(customer.Custid);
            int Index = ds.Tables[0].Rows.IndexOf(dr);
            ds.Tables[0].Rows[Index]["Name"] = customer.Name;
            ds.Tables[0].Rows[Index]["Balance"] = customer.Balance;
            ds.Tables[0].Rows[Index]["City"] = customer.City;
            ds.Tables[0].Rows[Index]["Status"] = customer.Status;
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Delete(int Custid)
        {
            DataRow dr = ds.Tables[0].Rows.Find(Custid);
            int Index = ds.Tables[0].Rows.IndexOf(dr);
            ds.Tables[0].Rows[Index].Delete();
            ds.WriteXml("Customer.xml");
        }
    }
}
