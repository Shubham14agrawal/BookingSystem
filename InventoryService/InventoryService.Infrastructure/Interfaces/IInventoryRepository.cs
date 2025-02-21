using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryService.Domain.Models;

namespace InventoryService.Infrastructure.Interfaces
{
    public interface IInventoryRepository
    {
        Task<Inventory> GetInventoryByIdAsync(int inventoryItemId);
        Task<bool> UpdateInventoryAsync(Inventory inventory);
        Task<List<Inventory>> UpdateInventoryBulkAsync(List<Inventory> inventories);
    }
}
