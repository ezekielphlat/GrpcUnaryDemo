// See https://aka.ms/new-console-template for more information
using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcService;
using System.Runtime.CompilerServices;

namespace GrpcClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //var channel = GrpcChannel.ForAddress("http://localhost:5281");
            //var client = new Sample.SampleClient(channel);
            ////var response = client.GetFullName(new SampleRequest { FirstName = "John", LastName = "Thomas" });
            //var response = await client.GetFullNameAsync(new SampleRequest { FirstName = "John", LastName = "Thomas" });
            //Console.WriteLine(response.FullName);

            //var productClient = new Product.ProductClient(channel);
            //var stockDate = DateTime.SpecifyKind(new DateTime(2022, 2, 1), DateTimeKind.Utc);
            //var response2 = await productClient.SaveProductAsync(new ProductModel { ProductName = "Macbook Pro", ProductCode = "P1001", Price = 5000, StockDate = Timestamp.FromDateTime(stockDate) });
            //Console.WriteLine($"{response2.StatusCode} | {response2.IsSuccessful}");

            //var response3 = await productClient.GetProductsAsync(new Google.Protobuf.WellKnownTypes.Empty());
            //foreach (var product in response3.Products)
            //{
            //    Console.WriteLine($"{product.ProductName} | {product.ProductCode} | {product.Price} | {product.StockDate.ToDateTime().ToString("dd-MM-yyyy")}");
            //}
            //await channel.ShutdownAsync();

          await  ServerStreamingDemo();
            Console.ReadLine();


        }
        private static async Task ServerStreamingDemo()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5281");
            var client = new StreamDemo.StreamDemoClient(channel);
            var response = client.ServerStreamingDemo(new Test { TestMessage = "Test" });
            while (await response.ResponseStream.MoveNext(CancellationToken.None))
            {
                var value = response.ResponseStream.Current.TestMessage;
                Console.WriteLine("value in stream {0}",value);
            }
            Console.WriteLine("Server streaming completed");
            await channel.ShutdownAsync();


        }
    }
}





