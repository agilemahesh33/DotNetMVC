namespace MVCDHProject.Models
{
    public interface ICustomerDAL
    {
        List<Customer> Select_Customers();
        Customer Select_Customer(int CustId);
        void Customer_Insert(Customer customer);
        void Customer_Update(Customer customer);
        void Customer_Delete(int Custid);
    }
}
