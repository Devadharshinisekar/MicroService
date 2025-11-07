
using System.ComponentModel;
using AutoMapper;
using EcomDomain.Aggregate;
using EcomDomain.IRepository;
using EcomInfrastucture.DataContext;
using Microsoft.EntityFrameworkCore;
namespace EcomInfrastucture.Repository.ReadRepository;

public class ProductRepository : IProductRepository
{
    private readonly EcomDbContext _ecomDbContext;
    private readonly IMapper _mapper;
    public ProductRepository(EcomDbContext ecomDbContext,IMapper mapper)
    {
        _ecomDbContext = ecomDbContext;
        _mapper = mapper;
        
    }
    public async Task<List<Product>> GetAllProducts()
    {
        var products = await _ecomDbContext.Products.ToListAsync();
        
        return _mapper.Map<List<Product>>(products);
    } 

    public async Task<Product> GetProductById(int productid)
    {
        var product = await _ecomDbContext.Products.FindAsync(productid);
        return _mapper.Map<Product>(product);
    }

}
