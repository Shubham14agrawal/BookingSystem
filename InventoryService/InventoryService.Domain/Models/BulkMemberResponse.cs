using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class BulkMemberResponse
    {
        public List<MemberUpdateResult> Results { get; set; } = new List<MemberUpdateResult>();
    }
}
