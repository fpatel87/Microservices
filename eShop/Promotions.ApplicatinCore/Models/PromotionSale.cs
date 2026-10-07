using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionsMicroservice.ApplicationCore.Models
{
    [Table("Promotion/Sale")]
    public class PromotionSale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Discount { get; set; }

        [Required]
        [Column("Start_Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("End_Date")]
        public DateTime EndDate { get; set; }

        public ICollection<PromotionDetail> PromotionDetails { get; set; }
            = new List<PromotionDetail>();
    }
}