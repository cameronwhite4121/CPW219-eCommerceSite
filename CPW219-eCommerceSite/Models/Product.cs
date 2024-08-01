using System.ComponentModel.DataAnnotations;

namespace CPW219_eCommerceSite.Models
{
    /// <summary>
    /// Represents a product that is sold at Cam's Consoles
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The primary key for each product
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        [Required]
        public string? Name { get; set; }

        /// <summary>
        /// Sale cost of the product
        /// </summary>
        [Required]
        [Range(0, 10000)]
        public double Price { get; set; }
    }
}
