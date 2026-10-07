using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PromotionsMicroservice.ApplicationCore.Models
{
    [Table("Promotion_Details")]
    public class PromotionDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("Promotion_Id")]
        public int PromotionId { get; set; }

        [Required]
        [Column("Product_Category_Id")]
        public int ProductCategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Product_Category_Name")]
        public string ProductCategoryName { get; set; } = string.Empty;

        [JsonIgnore]
        public PromotionSale? Promotion { get; set; }
    }
}