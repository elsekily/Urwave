using Azure;
using FastEndpoints;
using Urwave.Application.Resources;
using Urwave.Application.Services.Core;
using Urwave.Core.Entities;

namespace Urwave.API.EndPoints;
public class GetProductsEndpoint : EndpointWithoutRequest<ApiResponse>
{
    private readonly IProductService productService;

    public GetProductsEndpoint(IProductService productService)
    {
        this.productService = productService;
    }
    public override void Configure()
    {
        Get("/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var products = await productService.GetProducts();
        await SendAsync(new ProductsResponse(true, "", products));
    }
}