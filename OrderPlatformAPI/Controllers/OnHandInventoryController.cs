using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OrderPlatformAPI;
using System.Text.Json;
using DataAccess.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnHandInventoryController : ControllerBase
    {

        private readonly ILogger<OnHandInventoryController> _logger;

        public OnHandInventoryController(ILogger<OnHandInventoryController> logger)
        {
            _logger = logger;
        }

        // GET: api/<OnHandInventoryController>
        [HttpGet]
        public string Get()
        {
            SQLCrud sql = new SQLCrud(OrderPlatformAPI.ConfigurationService.GetConnectionString());

            var inventory = sql.GetAllInventory();

            var jsonString = JsonSerializer.Serialize(inventory);

            return jsonString;
        }

        // GET api/<OnHandInventoryController>/5
        [HttpGet ("{upcCode}")]
        public string Get(string upcCode)
        {
            SQLCrud sql = new SQLCrud(OrderPlatformAPI.ConfigurationService.GetConnectionString());

            var inventory = sql.GetInventoryByItem(upcCode);

            var jsonString = JsonSerializer.Serialize(inventory);

            return jsonString;
        }

        // POST api/<OnHandInventoryController>
        [HttpPost]
        public void Post([FromBody] InventoryModel inventoryModel)
        {

        }

        // PUT api/<OnHandInventoryController>/5
        [HttpPut]
        public void Put([FromBody] InventoryModel inventoryModel)
        {
        }
    }
}
