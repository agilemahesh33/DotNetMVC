namespace MVCUIDesigning.Models
{
    public class Customer
    {
        public int CustId { get; set; }
        public string Name { get; set; }    
        public string Account { get; set; }           
        public double Balance { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }  
        public string Photo { get; set; }
    }
}