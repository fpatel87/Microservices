using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReviewsMicroservice.ApplicationCore.Models
{
    [Table("Customer_Review")]
    public class CustomerReview
    {
        [Key]
        public int Id { get; set; }

        [Column("Customer_Id")]
        public string? CustomerId { get; set; }

        [Required]
        [MinLength(2)]
        [Column("Customer_Name")]
        public string CustomerName { get; set; } = string.Empty;

        [Column("Order_Id")]
        public string? OrderId { get; set; }

        [Required]
        [Column("Order_Date")]
        public DateTime OrderDate { get; set; }

        [Column("Product_Id")]
        public string? ProductId { get; set; }

        [Required]
        [MinLength(2)]
        [Column("Product_Name")]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Column("Rating_Value")]
        public double RatingValue { get; set; }

        [Required]
        [MinLength(2)]
        [Column("Comment")]
        public string Comment { get; set; } = string.Empty;

        [Required]
        [Column("Review_Date")]
        public DateTime ReviewDate { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";
    }
}