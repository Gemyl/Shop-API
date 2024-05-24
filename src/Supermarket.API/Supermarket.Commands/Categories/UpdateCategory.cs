using System.ComponentModel.DataAnnotations;

namespace Supermarket.Commands.Categories
{
    public class UpdateCategory
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
