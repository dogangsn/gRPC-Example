// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Grpc.Net.Client;
using grpcMessageClient;
using grpcServer;


var channel = GrpcChannel.ForAddress("http://localhost:5023");
var messageClient = new Message.MessageClient(channel);

MessageResponse response = await messageClient.SendMessageAsync(new MessageRequest {
    Message = "Merhaba",
    Name = "Gunes"
});
Console.WriteLine(response.Message);

// var greetClient = new Greeter.GreeterClient(channel);
// HelloReply result =  await greetClient.SayHelloAsync(new HelloRequest{
//     Name = "Dogan Gunes'den selamlar"
// });

//Console.WriteLine(result.Message);




