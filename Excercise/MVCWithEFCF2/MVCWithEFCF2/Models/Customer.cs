using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCWithEFCF2.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Column(TypeName = "Money")]
        public decimal? Balance { get; set; }
        [Index]
        [Required]
        [MaxLength(50)]
        [Column("Cname", TypeName = "Varchar")]
        public string CustomerName { get; set; }
        [StringLength(1000)]
        [Column(TypeName = "Varchar")]
        public string Address { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustId { get; set; }
        public int SupplierId {  get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
    }
}