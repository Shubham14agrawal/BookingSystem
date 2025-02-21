using InventoryService.Domain.Models;
using System.Threading.Tasks;

namespace InventoryService.Application.Interfaces
{
    public interface IMemberService
    {
        Task<BulkMemberResponse> BulkAddOrUpdateMembersAsync(List<MemberDTO> member);
    }
}
