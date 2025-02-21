using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class MemberDTO
    {
        public int Id { get; set; }  // Nullable for new members
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
