
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController:ControllerBase
    {
        private static readonly List<Item> items = new List<Item>
        {
            new Item{Id=1,Name="Item 1"},
            new Item{Id=2,Name="Item 2"},
            new Item{Id=3,Name="Item 3"}
        };
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return items;
        }

        //get api/item/2
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        //post: api/items
        [HttpPost]
        public ActionResult<Item> Post(Item newItem)
        {
            newItem.Id = items.Max(i => i.Id) + 1;
            items.Add(newItem);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        //PUT: api/items/2
        [HttpPut("{id}")]
        public IActionResult Put(int id,Item updatedItem)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();

            item.Name = updatedItem.Name;
            return NoContent();
        }
        //DELETE:api/items/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                return NotFound();
            items.Remove(item);
            return NoContent();
        }
    }
}
