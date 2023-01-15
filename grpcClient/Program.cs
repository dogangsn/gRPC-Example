// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Grpc.Net.Client;
using grpcMessageClient;
using grpcServer;


var channel = GrpcChannel.ForAddress("http://localhost:5023");
var messageClient = new Message.MessageClient(channel);

//Unary
// MessageResponse response = await messageClient.SendMessageAsync(new MessageRequest {
//     Message = "Merhaba",
//     Name = "Gunes"
// });
// Console.WriteLine(response.Message);

//Server Stream
var response = messageClient.SendMessage(new MessageRequest {
    Message = "Merhaba",
    Name = "Gunes"
});
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
while(await response.ResponseStream.MoveNext(cancellationTokenSource.Token))
{
    Console.WriteLine(response.ResponseStream.Current.Message);
}
 
// var greetClient = new Greeter.GreeterClient(channel);
// HelloReply result =  await greetClient.SayHelloAsync(new HelloRequest{
//     Name = "Dogan Gunes'den selamlar"
// });

//Console.WriteLine(result.Message);




