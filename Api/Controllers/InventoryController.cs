using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/inventory")]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<IEnumerable<WebInventory>> Get()
        {
            var inventories = _inventoryService.GetAll();

            if (inventories == null)
            {
                return NoContent();
            }

            return Ok(inventories);
        }

        [HttpGet]
        [Route("get/{id:int}")]
        public ActionResult<WebInventory> Get(int id)
        {
            var inventory = id > 0 ? _inventoryService.GetById(id) : null;

            if (inventory == null)
            {
                return NoContent();
            }

            return Ok(inventory);
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<WebInventory> Post([FromBody] WebInventory inventory)
        {
            var inventoryResponse = _inventoryService.Create(inventory);

            if (inventoryResponse == null)
            {
                return BadRequest();
            }

            return Ok(inventoryResponse);
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<WebInventory> Put([FromBody] WebInventory inventory)
        {
            var inventoryResponse = _inventoryService.Update(inventory);

            if (inventoryResponse == null)
            {
                return BadRequest();
            }

            return Ok(inventoryResponse);
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public ActionResult<bool> Delete(int id)
        {
            if (id > 0)
            {
                var deleted = _inventoryService.Delete(id);

                if (deleted)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}
