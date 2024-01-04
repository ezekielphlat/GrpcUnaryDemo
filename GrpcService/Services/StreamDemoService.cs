using Grpc.Core;
using System.Runtime.CompilerServices;

namespace GrpcService.Services
{
    public class StreamDemoService : StreamDemo.StreamDemoBase
    {
        private Random random;
        public StreamDemoService()
        {
            this.random = new Random();
        }
        public override async Task ServerStreamingDemo(Test request, IServerStreamWriter<Test> responseStream, ServerCallContext context)
        {
           
            for (int i = 0; i <= 20; i++)
            {
                await responseStream.WriteAsync(new Test { TestMessage = $"Message {i}" });
                var randomNumber = random.Next(1,10);
                await Task.Delay(randomNumber * 1000);
            }
        }
        public override async Task<Test> ClientStreamingDemo(IAsyncStreamReader<Test> requestStream, ServerCallContext context)
        {
            while (await requestStream.MoveNext()) { 
                Console.WriteLine(requestStream.Current.TestMessage);
            }
            Console.WriteLine("client streaming completed");
            return new Test { TestMessage = "Sample" };
        }

    }
}
