using System.Collections.Generic;
using AutoMapper;
using InventoryService.Application.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Interfaces;

namespace InventoryService.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<BulkMemberResponse> BulkAddOrUpdateMembersAsync(List<MemberDTO> member)
        {
            var domainMembers = _mapper.Map<List<Member>>(member);
            var response = await _memberRepository.BulkAddOrUpdateMembersAsync(domainMembers);

            return new BulkMemberResponse
            {
                Results = response.Select(m => new MemberUpdateResult
                {
                    MemberId = m.Id,
                    Success = true
                }).ToList()
            };
        }
    }
}
