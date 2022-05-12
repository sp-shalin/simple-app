using Api.Services.Interfaces;
using Api.Models;

namespace Api.Services;

public class InventoryService : IInventoryService
{
    public IEnumerable<Inventory> GetAll()
    {
        return new List<Inventory>(){
            new Inventory{
                Id = 1,
                Name = "Item 1",
                Description = "Item 1 description",
                Quantity = 1,
                Price = 1.99m,
                AddedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                DeletedAt = DateTime.Now
            },
        };
    }

    public Inventory GetById(int id)
    {
        return new Inventory
        {
            Id = 1,
            Name = "Item 1",
            Description = "Item 1 description",
            Quantity = 1,
            Price = 1.99m,
            AddedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = DateTime.Now
        };
    }

    public Inventory Create(Inventory inventory)
    {
        return new Inventory
        {
            Id = 1,
            Name = "Item 1",
            Description = "Item 1 description",
            Quantity = 1,
            Price = 1.99m,
            AddedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = DateTime.Now
        };
    }

    public Inventory Update(Inventory inventory)
    {
        return new Inventory
        {
            Id = 1,
            Name = "Item 1",
            Description = "Item 1 description",
            Quantity = 1,
            Price = 1.99m,
            AddedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            DeletedAt = DateTime.Now
        };
    }

    public bool Delete(int id)
    {
        return false;
    }
}