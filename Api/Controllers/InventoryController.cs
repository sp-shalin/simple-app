using Api.Services.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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
    public IActionResult Get()
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
    public IActionResult Get(int id)
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
    public IActionResult Post([FromBody] Inventory inventory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var inventoryResponse = _inventoryService.Create(inventory);

        if (inventoryResponse == null)
        {
            return Conflict();
        }

        return Ok(inventoryResponse);
    }

    [HttpPut]
    [Route("update")]
    public IActionResult Put([FromBody] Inventory inventory)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var inventoryResponse = _inventoryService.Update(inventory);

        if (inventoryResponse == null)
        {
            return Conflict();
        }

        return Ok(inventoryResponse);
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    public IActionResult Delete(int id)
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
