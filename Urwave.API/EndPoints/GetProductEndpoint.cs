using FastEndpoints;
using Urwave.Application.Resources;
using Urwave.Application.Services.Core;

namespace Urwave.API.EndPoints;

public class GetProductEndpoint : EndpointWithoutRequest<ApiResponse>
{
    private readonly IProductService productService;

    public GetProductEndpoint(IProductService productService)
    {
        this.productService = productService;
    }
    public override void Configure()
    {
        Get("/products/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");

        var product = await productService.GetProduct(id);
        await SendAsync(new ProductResponse(true, "", product));
    }
}