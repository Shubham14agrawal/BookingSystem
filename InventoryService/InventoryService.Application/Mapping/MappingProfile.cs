using AutoMapper;
using System;
using InventoryService.Domain.Models;
using AutoMapper.Execution;

namespace InventoryService.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()

        {
            CreateMap<BulkMemberRequest, InventoryService.Domain.Models.BulkMemberRequest>();
            CreateMap<InventoryService.Domain.Models.BulkMemberResponse, BulkMemberResponse>();


            // Map Domain InventoryItem (DTO) to Domain Inventory
            CreateMap<InventoryItem, Inventory>()
                    .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate));
            // Map between DTO and Domain models
            CreateMap<MemberDTO, InventoryService.Domain.Models.Member>().ReverseMap();
            CreateMap<BulkMemberRequest, List<InventoryService.Domain.Models.Member>>();
            CreateMap<BulkMemberResponse, List<MemberUpdateResult>>();
            // Map Domain Inventory to Domain InventoryItem
            CreateMap<Inventory, InventoryItem>()
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate));
        }
    }
}
