using CsvHelper;
using CsvHelper.Configuration;
using CsvService.Api.Models;
using InventoryService.Protos;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace CsvService.Api.Services
{
    public class CsvParserService
    {
        public async Task<InventoryService.Protos.BulkMemberRequest> ParseMemberCsvAsync(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            var grpcRequest = new InventoryService.Protos.BulkMemberRequest();

            await foreach (var record in csv.GetRecordsAsync<MemberRecord>())
            {
                grpcRequest.Members.Add(new InventoryService.Protos.Member
                {
                    Id = 0,
                    Name = record?.Name,
                    Surname = record?.Surname,
                    DateJoined = record?.DateJoined.ToString("yyyy-MM-ddTHH:mm:ss")
                });
            }

            return grpcRequest;
        }

        public async Task<InventoryService.Protos.BulkInventoryRequest> ParseInventoryCsvAsync(Stream csvStream)
        {
            using var reader = new StreamReader(csvStream);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));

            var grpcRequest = new InventoryService.Protos.BulkInventoryRequest();
            await foreach (var record in csv.GetRecordsAsync<InventoryRecord>())
            {
                grpcRequest.Updates.Add(new InventoryService.Protos.InventoryItem
                {
                    Id = record.Id,
                    Title = record.Title,
                    Description = record.Description,
                    RemainingCount = record.RemainingCount,
                    ExpirationDate = record.ExpirationDate.ToString("yyyy-MM-dd")
                });
            }
            return grpcRequest;
        }
    }
}
