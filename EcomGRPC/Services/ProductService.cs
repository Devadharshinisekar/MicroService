using EcomApplication.Product.CommandHandelers;
using EcomApplication.Product.Commands;
using EcomApplication.Product.Queries;
using EcomApplication.Product.QueryHandlers;
using EcomDomain.Aggregate;
using EcomDomain.Enities;
using EcomGRPC.Services;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace EcomGRPC.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly IProductQueryHandler _productQueryHandler;
        private readonly IProductCommandHandler _productCommandHandler;

        public ProductService(
            IProductQueryHandler productQueryHandler,
            IProductCommandHandler productCommandHandler)
        {
            _productQueryHandler = productQueryHandler;
            _productCommandHandler = productCommandHandler;
        }

        #region Product Queries

        public override async Task<GetProductByProductIdResponse> GetProductByProductId(
            GetProductByProductIdRequest request,
            ServerCallContext context)
        {
            GetProductByProductIdQuery query = new(request.ProductId);
            var product = await _productQueryHandler.GetProductById(query);

            if (product == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));

            return new GetProductByProductIdResponse
            {
                ProductId = product.ProductEntity!.ProductId,
                ProductName = product.ProductEntity!.ProductName,
                Description = product.ProductEntity!.Description,
                Quantity = product.ProductEntity!.Quantity,
                Price = product.ProductEntity!.Price
            };
        }

        public override async Task<GetAllProductsResponse> GetAllProducts(
            GetAllProductsRequest request,
            ServerCallContext context)
        {
            var products = await _productQueryHandler.GetProducts();
            var response = new GetAllProductsResponse();

           foreach (var product in products)
                {
                    var productDetails = new ProductDetails
                    {
                        ProductId = product.ProductEntity!.ProductId,
                        ProductName = product.ProductEntity.ProductName,
                        Description = product.ProductEntity.Description,
                        Quantity = product.ProductEntity.Quantity,
                    };
                    response.ProductDetails.Add(productDetails);
                }

            return response;
        }

        #endregion Product Queries

        #region Product Commands

        public override async Task<AddProductResponse> AddProduct(
            AddProductRequest request,
            ServerCallContext context)
        {
            var newProduct = new ProductEntities
            {
                ProductName = request.ProductName,
                Description = request.Description,
                Quantity = request.Quantity,
                Price = request.Price
            };
            CreateProductCommand command = new(newProduct);

            await _productCommandHandler.AddProduct(command);

            return new AddProductResponse
            {
                Message = $"Product '{newProduct.ProductName}' added successfully!"
            };
        }

        public override async Task<UpdateProductResponse> UpdateProduct(
            UpdateProductRequest request,
            ServerCallContext context)
        {
            var productEntity = new ProductEntities
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                Description = request.Description,
                Quantity = request.Quantity,
                Price = request.Price
            };
            UpdateProductCommand command = new(productEntity);
            var updated = await _productCommandHandler.UpdateProduct(command);

            return new UpdateProductResponse
            {
                Message = $"Product ID {request.ProductId} updated successfully!"
            };
        }
    //     public override async Task<StockResponse> RestockProduct(RestockRequest request, ServerCallContext context)
    // {
    //     try
    //     {
    //         var productEntity = new ProductEntities
    //         {
    //             ProductId = request.ProductId,
    //             Quantity = request.Quantity
    //         };
    //         RestockProductCommand command= new(productEntity.ProductId,productEntity.Quantity);
    //         var restock=await _productCommandHandler.RestockProduct(command);

    //         return new StockResponse
    //         {
    //             Success = true,
    //             Message = "Product restocked successfully"
    //         };
    //     }
    //     catch (Exception ex)
    //     {
    //         return new StockResponse
    //         {
    //             Success = false,
    //             Message = ex.Message
    //         };
    //     }
    // }

        #endregion Product Commands
    }
}
