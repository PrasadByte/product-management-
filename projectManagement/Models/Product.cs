using System.ComponentModel.DataAnnotations;

namespace projectManagement.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage ="Stock Must Be positive")]
        public int Stock { get; set; }
    }
}
