using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class BulkInventoryResponse
    {
        public List<InventoryUpdateResult> Results { get; set; } = new List<InventoryUpdateResult>();
    }
}
