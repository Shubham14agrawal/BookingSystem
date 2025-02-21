using System.Threading.Tasks;
using AutoMapper.Execution;
using InventoryService.Domain.Models;

namespace InventoryService.Application.Interfaces
{
    public interface IInventoryService
    {
        Task<bool> IsInventoryAvailableAsync(int inventoryItemId);
        Task<bool> DecrementInventoryAsync(int inventoryItemId);
        Task<bool> IncreaseInventoryAsync(int inventoryItemId);
        Task<BulkInventoryResponse> UpdateInventoryBulkAsync(List<InventoryItem> InventoryItem );
    }
}
