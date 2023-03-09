using Catalog.Models;
using System;

namespace  Catalog.Repositories
{
    public class InMemItemRepository
    {
        private readonly List<Item> _items;

        public InMemItemRepository()
        {
            _items = new()
                {
                    new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
                    new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
                    new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTimeOffset.UtcNow }

                };
        }

        public IEnumerable<Item> getItems()
        {
            return _items;
        }

        public Item GetItemById(Guid id)
        {
            return _items.Where(i => i.Id == id).SingleOrDefault();
        }
    }
}