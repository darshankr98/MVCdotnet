using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace dotnetMastery.Models{

    public class Category{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [MaxLength(30)]
    [DisplayName("Category Name")]
    public string? Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,100, ErrorMessage ="The Display Order should be between 1 - 100")]
    public int DisplayOrder { get; set; }
    }
}