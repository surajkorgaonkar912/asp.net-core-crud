using System.ComponentModel.DataAnnotations;

namespace MVC6Crud.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? Image { get; set; }
        [Required]
        public int CategoryId { get; set; }       
    }
}
