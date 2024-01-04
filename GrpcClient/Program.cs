﻿// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcService;

var channel = GrpcChannel.ForAddress("http://localhost:5281");
var client = new Sample.SampleClient(channel);
//var response = client.GetFullName(new SampleRequest { FirstName = "John", LastName = "Thomas" });
var response = await client.GetFullNameAsync(new SampleRequest { FirstName = "John", LastName = "Thomas" });
Console.WriteLine(response.FullName);

var productClient = new Product.ProductClient(channel);
var stockDate = DateTime.SpecifyKind(new DateTime(2022,2,1), DateTimeKind.Utc);
var response2 = await productClient.SaveProductAsync(new ProductModel { ProductName = "Macbook Pro", ProductCode = "P1001", Price = 5000, StockDate = Timestamp.FromDateTime(stockDate) });
Console.WriteLine($"{response2.StatusCode} | {response2.IsSuccessful}");

var response3 = await productClient.GetProductsAsync(new Google.Protobuf.WellKnownTypes.Empty());
foreach (var product in response3.Products)
{
    Console.WriteLine($"{product.ProductName} | {product.ProductCode} | {product.Price} | {product.StockDate.ToDateTime().ToString("dd-MM-yyyy")}");
}
await channel.ShutdownAsync();
Console.ReadLine();


