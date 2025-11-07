namespace EcomInfrastucture.Repository.WriteRepository;
using AutoMapper;
using EcomDomain.Aggregate;
using EcomDomain.IRepository;
using EcomInfrastucture.DataContext;
using EcomInfrastucture.DataModels;
using Microsoft.EntityFrameworkCore;

public class ProductAggregateRepository : IProductAggregateRepository
{
    private readonly EcomDbContext _ecomDbContext;
    private readonly IMapper _mapper;
    public ProductAggregateRepository(EcomDbContext ecomDbContext,IMapper mapper)
    {
        _ecomDbContext = ecomDbContext;
        _mapper = mapper;
    }
    public async Task<string> AddProduct(Product productAggregate)
    {
        try
        {
            var mappedResult = _mapper.Map<Product, ProductDataModel>(productAggregate);
            var addProduct = await _ecomDbContext.AddAsync(mappedResult);
            await _ecomDbContext.SaveChangesAsync();
            return "Added Successfully";
        }
        catch(Exception ex)
        {
            throw new Exception("Something went wrong!");
        }
    }

    public async Task<string> UpdateProduct(Product productAggregate)
    {
        _ecomDbContext.ChangeTracker.Clear();
        var mappedResult =
        _mapper.Map<Product, ProductDataModel>(productAggregate);
        var updateProduct = _ecomDbContext.Update(mappedResult);
        await _ecomDbContext.SaveChangesAsync();
        return "Updated Successfully";
    }

}
