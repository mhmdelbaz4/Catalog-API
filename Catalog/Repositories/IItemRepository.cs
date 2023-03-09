using Catalog.Dtos;
using Catalog.Models;

namespace Catalog.Repositories
{
     public interface IItemRepository
        {
            Item GetItemById(Guid id);

            IEnumerable<Item> getItems();

            void CreateItem(Item item);

            void UpdateItem(Item updatedItem);

            void DeleteItem(Guid Id);
        }

}