using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class BulkInventoryRequest
    {
        public List<InventoryItem> Updates { get; set; } = new List<InventoryItem>();
    }
}
