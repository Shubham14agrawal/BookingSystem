using System.Threading.Tasks;
using InventoryService.Protos;
using Grpc.Net.Client;

namespace CsvService.Api.Services
{
    public class InventoryClientService
    {
        private readonly Inventory.InventoryClient _client;

        public InventoryClientService(Inventory.InventoryClient client)
        {
            _client = client;
        }

        public async Task<bool> BulkUpdateInventoryAsync(BulkInventoryRequest request)
        {
            var response = await _client.UpdateInventoryBulkAsync(request);
            return response.Results.All(r => r.Success);
        }

        public async Task<bool> AddOrUpdateMemberAsync(BulkMemberRequest request)
        {
            var response = await _client.BulkAddOrUpdateMembersAsync(request);
            return response.Results.All(r => r.Success);
        }
    }
}
