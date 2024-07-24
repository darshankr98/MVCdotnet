using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace dotnetMastery.Models{

    public class Category{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [DisplayName("Category Name")]
    public string? Name { get; set; }
    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
    }
}