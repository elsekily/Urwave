using System.ComponentModel.DataAnnotations;

namespace Urwave.Application.Resources;

public class ProductResponse : ApiResponse
{
    public ProductResponse(bool isSuccess, string message, ProductResource product)
        : base(isSuccess, message)
    {
        Data = product;
    }
    public ProductResource Data { get; set; }
}