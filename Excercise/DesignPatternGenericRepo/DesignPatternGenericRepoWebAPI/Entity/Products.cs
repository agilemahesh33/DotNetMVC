using System.ComponentModel.DataAnnotations;

namespace WebAPIGenericRepoDP.Entity
{
    public class Products
    {
        [Key]
        public int ProdId { get; set; }
        public string ProdName { get; set; } = string.Empty;
        public string ProdDescription { get; set; } = string.Empty;
        public double ProdPrice { get; set; }
        public DateTime ProdMFG { get; set; }
        public DateTime ProdEXP { get; set; }

        //Navigation property
        public List<Orders> Orders { get; set; }
    }
}
