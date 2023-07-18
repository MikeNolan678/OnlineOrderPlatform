using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class InventoryModel
    {
        [Required]
        [MinLength(12), MaxLength(12)]
        [Key]
        public string UPC { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Warehouse { get; set; }
    }
}
