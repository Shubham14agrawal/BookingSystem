using System.Threading.Tasks;
using BookingService.Application.Clients;
using InventoryService.Protos; // Generated from inventory.proto
using Grpc.Net.Client;

namespace BookingService.Infrastructure.Services
{
    public class InventoryServiceClient : IInventoryServiceClient
    {
        private readonly Inventory.InventoryClient _client;

        public InventoryServiceClient(Inventory.InventoryClient client)
        {
            _client = client;
        }

        public async Task<bool> IsInventoryAvailableAsync(int inventoryItemId)
        {
            var response = await _client.IsInventoryAvailableAsync(new InventoryRequest { InventoryItemId = inventoryItemId });
            return response.Success;
        }

        public async Task<bool> DecrementInventoryAsync(int inventoryItemId)
        {
            var response = await _client.DecrementInventoryAsync(new InventoryRequest { InventoryItemId = inventoryItemId });
            return response.Success;
        }
        public async Task<bool> IncreaseInventoryAsync(int inventoryItemId)
        {
            var response = await _client.IncreaseInventoryAsync(new IncreaseInventoryRequest { InventoryItemId = inventoryItemId });
            return response.Success;
        }
    }
}
