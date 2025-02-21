// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: inventory.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace InventoryService.Protos {
  public static partial class Inventory
  {
    static readonly string __ServiceName = "Inventory";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::InventoryService.Protos.InventoryRequest> __Marshaller_InventoryRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::InventoryService.Protos.InventoryRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::InventoryService.Protos.InventoryResponse> __Marshaller_InventoryResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::InventoryService.Protos.InventoryResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::InventoryService.Protos.IncreaseInventoryRequest> __Marshaller_IncreaseInventoryRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::InventoryService.Protos.IncreaseInventoryRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::InventoryService.Protos.BulkInventoryRequest> __Marshaller_BulkInventoryRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::InventoryService.Protos.BulkInventoryRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::InventoryService.Protos.BulkInventoryResponse> __Marshaller_BulkInventoryResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::InventoryService.Protos.BulkInventoryResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::InventoryService.Protos.BulkMemberRequest> __Marshaller_BulkMemberRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::InventoryService.Protos.BulkMemberRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::InventoryService.Protos.BulkMemberResponse> __Marshaller_BulkMemberResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::InventoryService.Protos.BulkMemberResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::InventoryService.Protos.InventoryRequest, global::InventoryService.Protos.InventoryResponse> __Method_IsInventoryAvailable = new grpc::Method<global::InventoryService.Protos.InventoryRequest, global::InventoryService.Protos.InventoryResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IsInventoryAvailable",
        __Marshaller_InventoryRequest,
        __Marshaller_InventoryResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::InventoryService.Protos.InventoryRequest, global::InventoryService.Protos.InventoryResponse> __Method_DecrementInventory = new grpc::Method<global::InventoryService.Protos.InventoryRequest, global::InventoryService.Protos.InventoryResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DecrementInventory",
        __Marshaller_InventoryRequest,
        __Marshaller_InventoryResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::InventoryService.Protos.IncreaseInventoryRequest, global::InventoryService.Protos.InventoryResponse> __Method_IncreaseInventory = new grpc::Method<global::InventoryService.Protos.IncreaseInventoryRequest, global::InventoryService.Protos.InventoryResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "IncreaseInventory",
        __Marshaller_IncreaseInventoryRequest,
        __Marshaller_InventoryResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::InventoryService.Protos.BulkInventoryRequest, global::InventoryService.Protos.BulkInventoryResponse> __Method_UpdateInventoryBulk = new grpc::Method<global::InventoryService.Protos.BulkInventoryRequest, global::InventoryService.Protos.BulkInventoryResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateInventoryBulk",
        __Marshaller_BulkInventoryRequest,
        __Marshaller_BulkInventoryResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::InventoryService.Protos.BulkMemberRequest, global::InventoryService.Protos.BulkMemberResponse> __Method_BulkAddOrUpdateMembers = new grpc::Method<global::InventoryService.Protos.BulkMemberRequest, global::InventoryService.Protos.BulkMemberResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "BulkAddOrUpdateMembers",
        __Marshaller_BulkMemberRequest,
        __Marshaller_BulkMemberResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::InventoryService.Protos.InventoryReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Inventory</summary>
    public partial class InventoryClient : grpc::ClientBase<InventoryClient>
    {
      /// <summary>Creates a new client for Inventory</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public InventoryClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Inventory that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public InventoryClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected InventoryClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected InventoryClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.InventoryResponse IsInventoryAvailable(global::InventoryService.Protos.InventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsInventoryAvailable(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.InventoryResponse IsInventoryAvailable(global::InventoryService.Protos.InventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IsInventoryAvailable, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.InventoryResponse> IsInventoryAvailableAsync(global::InventoryService.Protos.InventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IsInventoryAvailableAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.InventoryResponse> IsInventoryAvailableAsync(global::InventoryService.Protos.InventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IsInventoryAvailable, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.InventoryResponse DecrementInventory(global::InventoryService.Protos.InventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DecrementInventory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.InventoryResponse DecrementInventory(global::InventoryService.Protos.InventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DecrementInventory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.InventoryResponse> DecrementInventoryAsync(global::InventoryService.Protos.InventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DecrementInventoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.InventoryResponse> DecrementInventoryAsync(global::InventoryService.Protos.InventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DecrementInventory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.InventoryResponse IncreaseInventory(global::InventoryService.Protos.IncreaseInventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IncreaseInventory(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.InventoryResponse IncreaseInventory(global::InventoryService.Protos.IncreaseInventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_IncreaseInventory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.InventoryResponse> IncreaseInventoryAsync(global::InventoryService.Protos.IncreaseInventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return IncreaseInventoryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.InventoryResponse> IncreaseInventoryAsync(global::InventoryService.Protos.IncreaseInventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_IncreaseInventory, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.BulkInventoryResponse UpdateInventoryBulk(global::InventoryService.Protos.BulkInventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateInventoryBulk(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.BulkInventoryResponse UpdateInventoryBulk(global::InventoryService.Protos.BulkInventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateInventoryBulk, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.BulkInventoryResponse> UpdateInventoryBulkAsync(global::InventoryService.Protos.BulkInventoryRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateInventoryBulkAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.BulkInventoryResponse> UpdateInventoryBulkAsync(global::InventoryService.Protos.BulkInventoryRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateInventoryBulk, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.BulkMemberResponse BulkAddOrUpdateMembers(global::InventoryService.Protos.BulkMemberRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return BulkAddOrUpdateMembers(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::InventoryService.Protos.BulkMemberResponse BulkAddOrUpdateMembers(global::InventoryService.Protos.BulkMemberRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_BulkAddOrUpdateMembers, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.BulkMemberResponse> BulkAddOrUpdateMembersAsync(global::InventoryService.Protos.BulkMemberRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return BulkAddOrUpdateMembersAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::InventoryService.Protos.BulkMemberResponse> BulkAddOrUpdateMembersAsync(global::InventoryService.Protos.BulkMemberRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_BulkAddOrUpdateMembers, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override InventoryClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new InventoryClient(configuration);
      }
    }

  }
}
#endregion
