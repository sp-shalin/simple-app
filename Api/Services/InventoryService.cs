using Api.Models;

namespace Api.Services.Interfaces;

public interface IInventoryService
{
    /// <summary>
    /// Get all inventories
    /// </summary>
    /// <returns>List of inventories</returns>
    IEnumerable<Inventory> GetAll();

    /// <summary>
    /// Get inventory by id
    /// </summary>
    /// <param name="id">Inventory id</param>
    /// <returns>Inventory</returns>
    Inventory GetById(int id);

    /// <summary>
    /// Create new inventory
    /// </summary>
    /// <param name="inventory">Inventory</param>
    /// <returns>Inventory</returns>
    Inventory Create(Inventory inventory);

    /// <summary>
    /// Update inventory
    /// </summary>
    /// <param name="inventory">Inventory</param>
    /// <returns>Inventory</returns>
    Inventory Update(Inventory inventory);

    /// <summary>
    /// Delete inventory
    /// </summary>
    /// <param name="id">Inventory id</param>
    /// <returns>true or false result</returns>
    bool Delete(int id);
}