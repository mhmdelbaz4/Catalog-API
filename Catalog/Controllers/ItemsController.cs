using Catalog.Dtos;
using Catalog.Models;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("api/items")]

    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _repo;

        public ItemsController(IItemRepository repo)
        {
            _repo = repo;
        }

        // GET /api/items
        
        [HttpGet]
        public IEnumerable<ItemDto> getItems()
        {
            return _repo.getItems().Select(i => i.AsItemDto());
        }

        // GET /api/items/{id}

        [HttpGet("{id}")]
        
        public ActionResult<ItemDto> getItem(Guid id)
        {
            ItemDto item = _repo.GetItemById(id)?.AsItemDto();

            if(item == null)
                return NotFound();

            return Ok(item);
        }

        
        // POST api/items
        
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto dto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                CreatedDate = DateTimeOffset.Now
            };

            _repo.CreateItem(item);

            return CreatedAtAction(nameof(getItem) ,item.AsItemDto() , new{id = item.Id} );
        }

        //POST /api/items/{id}

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdatedDto dto)
        {
            Item existingItem = _repo.GetItemById(id);

            if(existingItem is null)
                return NotFound();

            Item updatedItem = existingItem with
            {
                Name = dto.Name,
                Price = dto.Price
            };

            _repo.UpdateItem(updatedItem);

            return NoContent();
        }

        //DELETE /api/items/{id}
       
        [HttpDelete("{id}")]
        
        public ActionResult DeleteItem(Guid id)
        {
            Item deletedItem = _repo.GetItemById(id);

            if(deletedItem is null)
                return NotFound();

            _repo.DeleteItem(id);

            return NoContent();
        }
    }
}