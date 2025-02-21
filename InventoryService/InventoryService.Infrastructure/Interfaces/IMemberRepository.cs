using InventoryService.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> BulkAddOrUpdateMembersAsync(List<Member> members);
    }
}
