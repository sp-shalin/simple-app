using Api.Models;

namespace Api.Services.Interfaces
{
    public interface IInventoryService
    {
        /// <summary>
        /// Get all inventories
        /// </summary>
        /// <returns>List of inventories</returns>
        IEnumerable<WebInventory>? GetAll();

        /// <summary>
        /// Get inventory by id
        /// </summary>
        /// <param name="id">WebInventory id</param>
        /// <returns>WebInventory</returns>
        WebInventory? GetById(int id);

        /// <summary>
        /// Create new inventory
        /// </summary>
        /// <param name="webInventory">Web Inventory</param>
        /// <returns>WebInventory</returns>
        /// <returns>null if fail</returns>
        WebInventory? Create(WebInventory webInventory);

        /// <summary>
        /// Update inventory
        /// </summary>
        /// <param name="webInventory">Web Inventory</param>
        /// <returns>WebInventory</returns>
        WebInventory? Update(WebInventory webInventory);

        /// <summary>
        /// Delete inventory
        /// </summary>
        /// <param name="id">WebInventory id</param>
        /// <returns>true or false result</returns>
        bool Delete(int id);
    }
}