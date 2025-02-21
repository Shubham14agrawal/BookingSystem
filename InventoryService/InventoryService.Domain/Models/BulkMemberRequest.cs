using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class BulkMemberRequest
    {
        public List<MemberDTO> Members { get; set; } = new List<MemberDTO>();
    }
}
