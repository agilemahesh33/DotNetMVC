using System.ComponentModel.DataAnnotations;

namespace WebAPIGenericRepoDP.Entity
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate{ get; set; }

        //Foreign Key
        public int ProdId { get; set; }

        //Navigation property
        public Products Products { get; set; }
     
    }
}
