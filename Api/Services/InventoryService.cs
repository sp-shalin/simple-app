using Api.Data;
using Api.Models;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly SimpleAppDBContext _simpleAppDBContext;

        public InventoryService()
        {
            _simpleAppDBContext = new SimpleAppDBContext();
        }

        public IEnumerable<WebInventory>? GetAll()
        {
            try
            {
                return _simpleAppDBContext.Inventories?.Where(i => i.DeletedAt == null)?.Select(inventory => new WebInventory
                {
                    InventoryId = inventory.InventoryId,
                    Name = inventory.Name,
                    Description = inventory.Description,
                    Quantity = inventory.Quantity,
                    Price = inventory.Price,
                    AddedAt = inventory.AddedAt,
                    UpdatedAt = inventory.UpdatedAt,
                    DeletedAt = inventory.DeletedAt
                });
            }
            catch
            {
                // log error
            }

            return null;
        }

        public WebInventory? GetById(int id)
        {
            try
            {
                var inventory = _simpleAppDBContext.Inventories?.FirstOrDefault(i => i.InventoryId == id);

                if (inventory != null)
                {
                    return new WebInventory
                    {
                        InventoryId = inventory.InventoryId,
                        Name = inventory.Name,
                        Description = inventory.Description,
                        Quantity = inventory.Quantity,
                        Price = inventory.Price,
                        AddedAt = inventory.AddedAt,
                        UpdatedAt = inventory.UpdatedAt,
                        DeletedAt = inventory.DeletedAt
                    };
                }
            }
            catch
            {
                // log error
            }

            return null;
        }

        public WebInventory? Create(WebInventory webInventory)
        {
            try
            {
                var inventory = new Inventory
                {
                    Name = webInventory.Name,
                    Description = webInventory.Description,
                    Quantity = webInventory.Quantity,
                    Price = webInventory.Price,
                    AddedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = 1
                };

                _simpleAppDBContext.Inventories.Add(inventory);
                _simpleAppDBContext.SaveChanges();

                webInventory.InventoryId = inventory.InventoryId;

                return webInventory;
            }
            catch
            {
                // log error
            }

            return null;
        }

        public WebInventory? Update(WebInventory webInventory)
        {
            try
            {
                var inventory = _simpleAppDBContext.Inventories.FirstOrDefault(i => i.InventoryId == webInventory.InventoryId);
                if (inventory != null)
                {
                    inventory.Name = webInventory.Name;
                    inventory.Description = webInventory.Description ?? null;
                    inventory.Quantity = webInventory.Quantity;
                    inventory.Price = webInventory.Price;
                    inventory.AddedAt = webInventory.AddedAt;
                    inventory.UpdatedAt = DateTime.Now;

                    _simpleAppDBContext.SaveChanges();

                    webInventory.UpdatedAt = DateTime.Now;
                    return webInventory;
                }
            }
            catch
            {
                // log error
            }

            return null;
        }

        public bool Delete(int id)
        {
            try
            {
                var inventory = _simpleAppDBContext.Inventories.FirstOrDefault(i => i.InventoryId == id);
                if (inventory != null)
                {
                    // to actual delete item from db
                    //_simpleAppDBContext.Remove(inventory);

                    inventory.DeletedAt = DateTime.Now;
                    var deleted = _simpleAppDBContext.SaveChanges();

                    if (deleted > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                // log error
            }

            return false;
        }
    }
}