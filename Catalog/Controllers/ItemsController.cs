using Catalog.Models;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("api/items")]

    public class ItemsController : ControllerBase
    {
        private readonly InMemItemRepository _repo;

        public ItemsController()
        {
            _repo = new InMemItemRepository();
        }

        [HttpGet]
        public IEnumerable<Item> getItems()
        {
            return _repo.getItems();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> getItem(Guid id)
        {
            Item item = _repo.GetItemById(id);

            if(item == null)
                return NotFound();

            return Ok(item);
        }
    }
}