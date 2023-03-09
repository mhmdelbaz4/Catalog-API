using Catalog.Models;

namespace Catalog.Repositories
{
     public interface IItemRepository
        {
            Item GetItemById(Guid id);
            IEnumerable<Item> getItems();
        }

}