using Catalog.Dtos;
using Catalog.Models;
using System;

namespace  Catalog.Repositories
{
    
    public class InMemItemRepository : IItemRepository
    {
        private readonly List<Item> _items;

        public InMemItemRepository()
        {
            _items = new()
                {
                    new Item { Id = Guid.NewGuid(), Name = "Portion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
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

        public void CreateItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Item updatedItem)
        {
            var existingIndex = _items.FindIndex(i => i.Id == updatedItem.Id);

            _items[existingIndex] = updatedItem;
                        
        }

        public void DeleteItem(Guid id)
        {
            var deltedIndex = _items.FindIndex(item => item.Id == id);
            
            _items.RemoveAt(deltedIndex);
        }
    }
}