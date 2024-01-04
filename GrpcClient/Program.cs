// See https://aka.ms/new-console-template for more information
using Grpc.Net.Client;
using GrpcService;

var channel = GrpcChannel.ForAddress("http://localhost:5281");
var client = new Sample.SampleClient(channel);
//var response = client.GetFullName(new SampleRequest { FirstName = "John", LastName = "Thomas" });
var response = await client.GetFullNameAsync(new SampleRequest { FirstName = "John", LastName = "Thomas" });
Console.WriteLine(response.FullName);

var productClient = new Product.ProductClient(channel);
var response2 = await productClient.SaveProductAsync(new ProductModel { ProductName = "Macbook Pro", ProductCode = "P1001", Price = 5000 });
Console.WriteLine($"{response2.StatusCode} | {response2.IsSuccessful}");

var response3 = await productClient.GetProductsAsync(new Google.Protobuf.WellKnownTypes.Empty());
foreach (var product in response3.Products)
{
    Console.WriteLine($"{product.ProductName} | {product.ProductCode} | {product.Price}");
}
await channel.ShutdownAsync();
Console.ReadLine();


