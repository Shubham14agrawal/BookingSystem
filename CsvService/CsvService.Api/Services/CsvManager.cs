using System.Threading.Tasks;
using CsvService.Api.Models;
using Microsoft.AspNetCore.Http;

namespace CsvService.Api.Services
{
    public class CsvManager
    {
        private readonly CsvParserService _csvParserService;
        private readonly InventoryClientService _inventoryClientService;

        public CsvManager(CsvParserService csvParserService, InventoryClientService inventoryClientService)
        {
            _csvParserService = csvParserService;
            _inventoryClientService = inventoryClientService;
        }

        public async Task<bool> ProcessMemberCsvAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var grpcRequest = await _csvParserService.ParseMemberCsvAsync(stream);


            return await _inventoryClientService.AddOrUpdateMemberAsync(grpcRequest);
        }

        public async Task<bool> ProcessInventoryCsvAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            var grpcRequest = await _csvParserService.ParseInventoryCsvAsync(stream);
            return await _inventoryClientService.BulkUpdateInventoryAsync(grpcRequest);
        }
    }
}