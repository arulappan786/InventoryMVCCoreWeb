using System.ComponentModel.DataAnnotations;

namespace InventoryMVCCoreWeb.Models
{
    public class ProductCreateViewModel
    {
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required]
        [RegularExpression(@"^[0-9\-]+$")]
        public int StockQuantity { get; set; }
    }
}
