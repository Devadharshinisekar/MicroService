using AutoMapper;
using EcomApplication.Product.Commands;
using EcomDomain.IRepository;

namespace EcomApplication.Product.CommandHandelers;

public class ProductCommandHandler : IProductCommandHandler
{
    private readonly IProductRepository _productRepository;
    private readonly IProductAggregateRepository _productAggregateRepository;
    private readonly IMapper _mapper;
    public ProductCommandHandler(IProductRepository productRepository,IProductAggregateRepository productAggregateRepository,IMapper mapper)
    {
        _productRepository = productRepository;
        _productAggregateRepository = productAggregateRepository;
        _mapper = mapper;
    }
    public async Task<string> AddProduct(CreateProductCommand command)
    {
        var productDetail = await _productRepository.GetProductById(command.ProductCore.ProductId);
        if (productDetail != null)
        {
            throw new Exception("Product Already Exits");
        }
        productDetail = EcomDomain.Aggregate.Product.AddProduct(command.ProductCore, _mapper);
        return await _productAggregateRepository.AddProduct(productDetail);
    }

    public async Task<string> UpdateProduct(UpdateProductCommand command)
    {
        var existingProduct = await _productRepository.GetProductById(command.ProductCore.ProductId);
        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }
        var updatedProduct = existingProduct.UpdateProduct(command.ProductCore, _mapper);
        return await _productAggregateRepository.UpdateProduct(updatedProduct);
    }
    

}
