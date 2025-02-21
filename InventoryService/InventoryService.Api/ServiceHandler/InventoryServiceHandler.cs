using Grpc.Core;
using InventoryService.Application.Interfaces;
using InventoryService.Protos;
using AutoMapper;
using System.Threading.Tasks;
using InventoryService.Domain.Models;

namespace InventoryService.Api.Services
{
    public class InventoryServiceHandler : Protos.Inventory.InventoryBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;
        private readonly IMemberService _memberService;

        public InventoryServiceHandler(IInventoryService inventoryService, IMemberService memberService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
            _memberService = memberService;
        }

        public override async Task<InventoryResponse> IsInventoryAvailable(InventoryRequest request, ServerCallContext context)
        {
            bool available = await _inventoryService.IsInventoryAvailableAsync(request.InventoryItemId);
            return new InventoryResponse { Success = available };
        }

        public override async Task<InventoryResponse> DecrementInventory(InventoryRequest request, ServerCallContext context)
        {
            bool success = await _inventoryService.DecrementInventoryAsync(request.InventoryItemId);
            return new InventoryResponse { Success = success };
        }

        public override async Task<InventoryResponse> IncreaseInventory(IncreaseInventoryRequest request, ServerCallContext context)
        {
            bool success = await _inventoryService.IncreaseInventoryAsync(request.InventoryItemId);
            return new InventoryResponse { Success = success };
        }

        public override async Task<Protos.BulkInventoryResponse> UpdateInventoryBulk(
            Protos.BulkInventoryRequest request,
            ServerCallContext context)
        {
            try
            {
                // Convert gRPC request to Application DTO
                var appRequest = _mapper.Map<Domain.Models.BulkInventoryRequest>(request);

                // Call the Application service
                var appResponse = await _inventoryService.UpdateInventoryBulkAsync(appRequest.Updates);

                // Convert Application response back to gRPC
                var protoResponse = _mapper.Map<Protos.BulkInventoryResponse>(appResponse);
                return protoResponse;
            }
            catch (System.Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
        public override async Task<Protos.BulkMemberResponse> BulkAddOrUpdateMembers(Protos.BulkMemberRequest request, ServerCallContext context)
        {
            try
            {
                var appRequest = _mapper.Map<List<MemberDTO>>(request.Members);
                var appResponse = await _memberService.BulkAddOrUpdateMembersAsync(appRequest);
                return _mapper.Map<Protos.BulkMemberResponse>(appResponse);
            }
            catch (System.Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }
    }
}
