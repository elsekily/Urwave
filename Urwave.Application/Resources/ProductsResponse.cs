namespace Urwave.Application.Resources;

public class ProductsResponse : ApiResponse
{
    public ProductsResponse(bool isSuccess, string message, List<ProductResource> products)
        : base(isSuccess, message)
    {
        Data = products;
    }
    public List<ProductResource> Data { get; set; }
}
