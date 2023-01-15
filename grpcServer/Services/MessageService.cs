using Grpc.Core;
using grpcMessageServer;
using grpcServer;

namespace grpcServer.Services;

public class MessageService : Message.MessageBase
{

    public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        Console.WriteLine($"Message : {request.Message } | Name : { request.Name }");

        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(200);
            responseStream.WriteAsync(new MessageResponse {
                Message = "Merhana " + i
            }); 
        }

    }

    
    // public override async Task<MessageResponse> SendMessage(MessageRequest request, ServerCallContext context)
    // {
    //     Console.WriteLine($"Message : { request.Message } | Name : { request.Name }");
    //     return new MessageResponse
    //     {
    //         Message = "Mesaj Başarıyla alınmıştır... "
    //     };
    // }
 
}
