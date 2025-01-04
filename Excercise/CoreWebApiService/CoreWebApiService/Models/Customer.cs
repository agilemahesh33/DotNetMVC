namespace CoreWebApiService.Models
{
    public class Customer
    {
        public int Custid { get; set; }
        public string Name { get; set; }
        public decimal? Balance { get; set; }
        public string City { get; set; }
        public bool Status { get; set; }

    }
}
