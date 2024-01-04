using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcService.Services
{
    public class ProductService :Product.ProductBase
    {
        public override Task<ProductSaveResponse> SaveProduct(ProductModel request, ServerCallContext context)
        {
            // insert method to the database
            Console.WriteLine($"{request.ProductName} | {request.ProductCode} | {request.Price}");
            var result = new ProductSaveResponse()
            {
                StatusCode = 200,
                IsSuccessful = true,
            };
            return Task.FromResult( result );
        }
        public override Task<ProductList> GetProducts(Empty request, ServerCallContext context)
        {
             var stockDate = DateTime.SpecifyKind(new DateTime(2022, 2, 1), DateTimeKind.Utc);

            var products = new List<ProductModel>() { new ProductModel
            {
                ProductName = "Macbook pro",
                ProductCode = "1",
                Price = 1000,
                StockDate =  Timestamp.FromDateTime(stockDate),
            },
             new ProductModel
            {
                ProductName = "Macbook pro",
                ProductCode = "1",
                Price = 455,
               StockDate =  Timestamp.FromDateTime(stockDate),

            },

              new ProductModel
            {
                ProductName = "Elite book pro",
                ProductCode = "1",
                Price = 40,
                 StockDate =  Timestamp.FromDateTime(stockDate),

            },

               new ProductModel
            {
                ProductName = "Windows pro",
                ProductCode = "1",
                Price = 233,
                StockDate =  Timestamp.FromDateTime(stockDate),

            },



            };
            var result = new ProductList();
            result.Products.AddRange( products );
            return Task.FromResult( result );
           
           
        }
    }
}
