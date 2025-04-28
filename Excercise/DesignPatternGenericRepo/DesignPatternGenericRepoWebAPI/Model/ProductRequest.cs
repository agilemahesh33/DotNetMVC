namespace WebAPIGenericRepoDP.Model
{
    public class ProductRequest
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; } = string.Empty;
        public string ProdDescription { get; set; } = string.Empty;
        public double ProdPrice { get; set; }
        public DateTime ProdMFG { get; set; }
        public DateTime ProdEXP { get; set; }
    }
}
