using Catalog.Dtos;
using Catalog.Models;

namespace  Catalog
{
    public static class Extensions
    {
        public static ItemDto AsItemDto(this Item item)
        {
            ItemDto dto = new()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate
            };

            return dto;
        }
    }
}