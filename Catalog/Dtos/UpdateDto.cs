using System.ComponentModel.DataAnnotations;

namespace Catalog
{
    public record UpdatedDto
    {
         [Required]
         public string Name { get; init; }

         [Required]
         [Range(1,1000)]

         public decimal Price { get; set; }
    }
}