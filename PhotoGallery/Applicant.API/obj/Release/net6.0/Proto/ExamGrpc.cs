// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Proto/exam.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcExam {
  public static partial class ExamGrpc
  {
    static readonly string __ServiceName = "ExamGrpc";

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
    static readonly grpc::Marshaller<global::GrpcExam.GetExamItem> __Marshaller_GetExamItem = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcExam.GetExamItem.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcExam.ExamItemModel> __Marshaller_ExamItemModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcExam.ExamItemModel.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcExam.ExamRequest> __Marshaller_ExamRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcExam.ExamRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcExam.ExamResponse> __Marshaller_ExamResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcExam.ExamResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcExam.ExamQuestionsResponse> __Marshaller_ExamQuestionsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcExam.ExamQuestionsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcExam.GetExamItem, global::GrpcExam.ExamItemModel> __Method_GetExamItemFromExamData = new grpc::Method<global::GrpcExam.GetExamItem, global::GrpcExam.ExamItemModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExamItemFromExamData",
        __Marshaller_GetExamItem,
        __Marshaller_ExamItemModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcExam.ExamRequest, global::GrpcExam.ExamResponse> __Method_CheckIfQuestionExistsInExam = new grpc::Method<global::GrpcExam.ExamRequest, global::GrpcExam.ExamResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckIfQuestionExistsInExam",
        __Marshaller_ExamRequest,
        __Marshaller_ExamResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcExam.GetExamItem, global::GrpcExam.ExamQuestionsResponse> __Method_GetExamQuestions = new grpc::Method<global::GrpcExam.GetExamItem, global::GrpcExam.ExamQuestionsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExamQuestions",
        __Marshaller_GetExamItem,
        __Marshaller_ExamQuestionsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcExam.ExamReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ExamGrpc</summary>
    public partial class ExamGrpcClient : grpc::ClientBase<ExamGrpcClient>
    {
      /// <summary>Creates a new client for ExamGrpc</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ExamGrpcClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ExamGrpc that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ExamGrpcClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ExamGrpcClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ExamGrpcClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcExam.ExamItemModel GetExamItemFromExamData(global::GrpcExam.GetExamItem request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExamItemFromExamData(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcExam.ExamItemModel GetExamItemFromExamData(global::GrpcExam.GetExamItem request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetExamItemFromExamData, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcExam.ExamItemModel> GetExamItemFromExamDataAsync(global::GrpcExam.GetExamItem request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExamItemFromExamDataAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcExam.ExamItemModel> GetExamItemFromExamDataAsync(global::GrpcExam.GetExamItem request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetExamItemFromExamData, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcExam.ExamResponse CheckIfQuestionExistsInExam(global::GrpcExam.ExamRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckIfQuestionExistsInExam(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcExam.ExamResponse CheckIfQuestionExistsInExam(global::GrpcExam.ExamRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CheckIfQuestionExistsInExam, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcExam.ExamResponse> CheckIfQuestionExistsInExamAsync(global::GrpcExam.ExamRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckIfQuestionExistsInExamAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcExam.ExamResponse> CheckIfQuestionExistsInExamAsync(global::GrpcExam.ExamRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CheckIfQuestionExistsInExam, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcExam.ExamQuestionsResponse GetExamQuestions(global::GrpcExam.GetExamItem request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExamQuestions(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcExam.ExamQuestionsResponse GetExamQuestions(global::GrpcExam.GetExamItem request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetExamQuestions, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcExam.ExamQuestionsResponse> GetExamQuestionsAsync(global::GrpcExam.GetExamItem request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetExamQuestionsAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcExam.ExamQuestionsResponse> GetExamQuestionsAsync(global::GrpcExam.GetExamItem request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetExamQuestions, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ExamGrpcClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ExamGrpcClient(configuration);
      }
    }

  }
}
#endregion