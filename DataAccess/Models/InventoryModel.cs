using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static DataAccess.Models.Enums;

namespace DataAccess.Models
{
    public class InventoryModel
    {
        [Required]
        [MinLength(12), MaxLength(12)]
        public string UPC { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Warehouse { get; set; }
    }
}
