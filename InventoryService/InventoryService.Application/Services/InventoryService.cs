using AutoMapper;
using InventoryService.Application.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Interfaces;
namespace InventoryService.Application.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;
        private readonly IMapper _mapper;

        public InventoryService(IInventoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> IsInventoryAvailableAsync(int inventoryItemId)
        {
            var inventory = await _repository.GetInventoryByIdAsync(inventoryItemId);
            return inventory != null && inventory.RemainingCount > 0;
        }

        public async Task<bool> DecrementInventoryAsync(int inventoryItemId)
        {
            var inventory = await _repository.GetInventoryByIdAsync(inventoryItemId);
            if (inventory != null && inventory.RemainingCount > 0)
            {
                inventory.RemainingCount--;
                await _repository.UpdateInventoryAsync(inventory);
                return true;
            }
            return false;
        }

        public async Task<bool> IncreaseInventoryAsync(int inventoryItemId)
        {
            var inventory = await _repository.GetInventoryByIdAsync(inventoryItemId);
            if (inventory != null)
            {
                inventory.RemainingCount += 1;
                await _repository.UpdateInventoryAsync(inventory);
                return true;
            }
            return false;
        }


        public async Task<BulkInventoryResponse> UpdateInventoryBulkAsync(List<InventoryItem> inventoryItems)
        {
            // Map application DTO to domain models
            var domainInventories = _mapper.Map<List<Inventory>>(inventoryItems);
            var response = await _repository.UpdateInventoryBulkAsync(domainInventories);
            // Build and return the response
            return new BulkInventoryResponse
            {
                Results = response.Select(u => new InventoryUpdateResult
                {
                    InventoryItemId = u.Id,
                    Success = true
                }).ToList()
            };
        }

    }
}
