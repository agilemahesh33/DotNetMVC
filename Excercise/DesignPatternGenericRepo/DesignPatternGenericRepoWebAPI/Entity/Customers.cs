using System.ComponentModel.DataAnnotations;

namespace WebAPIGenericRepoDP.Entity
{
    public class Customers
    {
        [Key]
        public int CustId { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string EmailId {  get; set; }
    }
}
