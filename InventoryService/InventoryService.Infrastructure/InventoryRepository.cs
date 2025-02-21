using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryDbContext _context;

        public InventoryRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<Inventory> GetInventoryByIdAsync(int inventoryItemId)
        {
            return await _context.Inventories.FindAsync(inventoryItemId);
        }

        public async Task<bool> UpdateInventoryAsync(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Inventory>> UpdateInventoryBulkAsync(List<Inventory> inventories)
        {
            foreach (var inv in inventories)
            {
                Inventory? existing = null;
                if (inv.Id > 0)
                {
                    existing = await _context.Inventories.FindAsync(inv.Id);
                }

                if (existing != null)
                {
                    // Update the existing entity's fields
                    existing.Title = inv.Title;
                    existing.Description = inv.Description;
                    existing.RemainingCount = inv.RemainingCount;
                    existing.ExpirationDate = inv.ExpirationDate;
                }
                else
                {
                    // Add as a new entity
                    await _context.Inventories.AddAsync(inv);
                }
            }
            await _context.SaveChangesAsync();
            return inventories;
        }


    }
}
