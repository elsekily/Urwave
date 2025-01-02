using FastEndpoints;
using System.Net;
using Urwave.API.Validations;
using Urwave.Application.Resources;
using Urwave.Application.Services.Core;
using Urwave.Core.Entities;

namespace Urwave.API.EndPoints;

public class CreateProductEndpoint : Endpoint<ProductRequest, ApiResponse>
{
    private readonly IProductService productService;

    public CreateProductEndpoint(IProductService productService)
    {
        this.productService = productService;
    }
    public override void Configure()
    {
        Post("/products");
        AllowAnonymous();
        Validator<ProductRequestValidator>();
    }

    public override async Task HandleAsync(ProductRequest request, CancellationToken ct)
    {
        var product = await productService.AddProduct(request);
        
        await SendAsync(new ProductResponse(true,"",product),
            (int)HttpStatusCode.Created
            ,ct);
    }
}