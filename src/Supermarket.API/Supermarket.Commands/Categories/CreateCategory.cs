using System.ComponentModel.DataAnnotations;

namespace Supermarket.Commands.Categories
{
    public class CreateCategory
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
