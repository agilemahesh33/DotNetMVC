
namespace MVCDHProject.Models
{
    public class CustomerSqlDAL : ICustomerDAL
    {
        private readonly MVCCoreDbContext context;

        public CustomerSqlDAL(MVCCoreDbContext context)
        {
            this.context = context;
        }
        public List<Customer> Select_Customers()
        {
            var customers = context.Customers.Where(c => c.Status == true).ToList();
            return customers;
        }
        public Customer Select_Customer(int CustId)
        {
            var customer = context.Customers.Find(CustId);
            return customer;
        }

        public void Customer_Insert(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void Customer_Update(Customer customer)
        {
            customer.Status = true; 
            context.Update(customer);
            context.SaveChanges();
        }        

        public void Customer_Delete(int Custid)
        {
            Customer customer = context.Customers.Find(Custid);
            customer.Status = false;
            context.SaveChanges();
        }
    }
}
