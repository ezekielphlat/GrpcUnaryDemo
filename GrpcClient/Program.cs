// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcService.Protos;

var channel = GrpcChannel.ForAddress("http://localhost:5281");
var client = new Sample.SampleClient(channel);
//var response = client.GetFullName(new SampleRequest { FirstName = "John", LastName = "Thomas" });
var response = await client.GetFullNameAsync(new SampleRequest { FirstName = "John", LastName = "Thomas" });
Console.WriteLine(response.FullName);
Console.ReadLine();


