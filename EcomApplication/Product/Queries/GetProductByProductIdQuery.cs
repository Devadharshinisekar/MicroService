namespace EcomApplication.Product.Queries;

public class GetProductByProductIdQuery
{
    public GetProductByProductIdQuery(int productid)
    {
        ProductId = productid;
    }
 public int ProductId { get; set; }
}
