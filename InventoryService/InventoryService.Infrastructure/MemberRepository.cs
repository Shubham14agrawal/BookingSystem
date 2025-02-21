using InventoryService.Infrastructure.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly InventoryDbContext _context;

        public MemberRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<List<Member>> BulkAddOrUpdateMembersAsync(List<Member> members)
        {
            foreach (var member in members)
            {
                var existingMember = await _context.Members.FirstOrDefaultAsync(m => m.Id == member.Id);
                if (existingMember != null)
                {
                    // Update existing member
                    existingMember.Name = member.Name;
                    existingMember.Surname = member.Surname;
                    existingMember.DateJoined = member.DateJoined;
                }
                else
                {
                    // Add new member
                    await _context.Members.AddAsync(member);
                }
            }
            await _context.SaveChangesAsync();
            return members;
        }
    }
}
