using AutoMapper;

namespace InventoryService.Api.Mapping
{
    public class MappingDTO : Profile
    {
        public MappingDTO()
        {
            // Map gRPC InventoryItem to Domain InventoryItem
            CreateMap<InventoryService.Protos.InventoryItem, InventoryService.Domain.Models.InventoryItem>()
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => DateTime.Parse(src.ExpirationDate)))
                .ReverseMap()
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate.ToString("yyyy-MM-dd")));

            // Map gRPC BulkInventoryRequest to Domain BulkInventoryRequest
            CreateMap<InventoryService.Protos.BulkInventoryRequest, InventoryService.Domain.Models.BulkInventoryRequest>()
                .ForMember(dest => dest.Updates, opt => opt.MapFrom(src => src.Updates));

            // Map Domain BulkInventoryResponse to gRPC BulkInventoryResponse
            CreateMap<InventoryService.Domain.Models.BulkInventoryResponse, InventoryService.Protos.BulkInventoryResponse>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));

            // Map Domain InventoryUpdateResult to gRPC InventoryUpdateResult
            CreateMap<InventoryService.Domain.Models.InventoryUpdateResult, InventoryService.Protos.InventoryUpdateResult>()
                .ReverseMap();

            // Map gRPC Member to Domain Member (if needed)
            CreateMap<InventoryService.Protos.Member, InventoryService.Domain.Models.Member>()
                .ForMember(dest => dest.DateJoined, opt => opt.MapFrom(src => DateTime.Parse(src.DateJoined)))
                .ReverseMap()
                .ForMember(dest => dest.DateJoined, opt => opt.MapFrom(src => src.DateJoined.ToString("yyyy-MM-ddTHH:mm:ss")));

            // Map gRPC Member to Domain MemberDTO
            CreateMap<InventoryService.Protos.Member, InventoryService.Domain.Models.MemberDTO>()
                .ForMember(dest => dest.DateJoined, opt => opt.MapFrom(src => DateTime.Parse(src.DateJoined)))
                .ReverseMap()
                .ForMember(dest => dest.DateJoined, opt => opt.MapFrom(src => src.DateJoined.ToString("yyyy-MM-ddTHH:mm:ss")));

            // Map gRPC BulkMemberRequest to Domain BulkMemberRequest
            CreateMap<InventoryService.Protos.BulkMemberRequest, InventoryService.Domain.Models.BulkMemberRequest>()
                .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members));

            // Map Domain BulkMemberResponse to gRPC BulkMemberResponse
            CreateMap<InventoryService.Domain.Models.BulkMemberResponse, InventoryService.Protos.BulkMemberResponse>()
                .ForMember(dest => dest.Results, opt => opt.MapFrom(src => src.Results));

            // Map Domain MemberUpdateResult to gRPC MemberUpdateResult
            CreateMap<InventoryService.Domain.Models.MemberUpdateResult, InventoryService.Protos.MemberUpdateResult>()
                .ReverseMap();
        }
    }
}
