using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [NotNull]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string? Name { get; set; }

        [Required]
        [NotNull]
        [Range(0, 100)]
        [DisplayName("Display Order")]
        public int DispayOrder { get; set; }
    }
}
