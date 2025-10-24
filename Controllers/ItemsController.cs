
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
    }
}
