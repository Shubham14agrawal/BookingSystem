using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class MemberUpdateResult
    {
        public int MemberId { get; set; }
        public bool Success { get; set; }
    }
}
