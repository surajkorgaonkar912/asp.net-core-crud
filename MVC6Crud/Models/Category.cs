using System.ComponentModel.DataAnnotations;

namespace MVC6Crud.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name ="Category Name")]
        public string? CategoryName { get; set; }
    }
}
