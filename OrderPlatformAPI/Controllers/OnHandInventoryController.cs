using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DataAccess.Models;

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
        public ActionResult<string> Get()
        {
            try
            {
                SQLCrud sql = new SQLCrud(OrderPlatformAPI.ConfigurationService.GetConnectionString());

                var inventory = sql.GetAllInventory();

                var jsonString = JsonSerializer.Serialize(inventory);

                 return Ok(jsonString);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting all inventory items");
                
                return StatusCode(500,$"Error: {e.Message}");
            }
        }

        // GET api/<OnHandInventoryController>/5
        [HttpGet("{upcCode}")]
        public ActionResult<string> Get(string upcCode)
        {
            try
            {
                SQLCrud sql = new SQLCrud(OrderPlatformAPI.ConfigurationService.GetConnectionString());

                var inventory = sql.GetInventoryByItem(upcCode);

                if (inventory == null)
                {
                    _logger.LogInformation($"Inventory item {upcCode} does not exist");
                    return NotFound();
                }

                var jsonString = JsonSerializer.Serialize(inventory);

                return Ok(jsonString);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error getting inventory item");

                return StatusCode(500, $"Error: {e.Message}");
            }
        }

        // POST api/<OnHandInventoryController>
        [HttpPost]
        public IActionResult Post([FromBody] List<InventoryModel> incomingInventory)
        {
            SQLCrud sql = new SQLCrud(OrderPlatformAPI.ConfigurationService.GetConnectionString());

            try
            {
                if (incomingInventory == null)
                {
                    _logger.LogError("Incoming inventory is empty");
                    return BadRequest("Incoming inventory is empty");
                }

                var (inventoryExists, inventoryNotExists) = sql.SplitIncomingInventory(incomingInventory);

                sql.BulkUpdateInventory(inventoryExists, inventoryNotExists);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing incoming inventory");
                return StatusCode(500, $"Error: {ex.Message}");
            }

            
        }
    }
}