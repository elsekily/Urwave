using FastEndpoints;
using System.Net;
using Urwave.Application.Resources;
using Urwave.Application.Services.Core;

namespace Urwave.API.EndPoints;

public class DeleteProductEndpoint : EndpointWithoutRequest<ApiResponse>
{
    private readonly IProductService productService;

    public DeleteProductEndpoint(IProductService productService)
    {
        this.productService = productService;
    }

    public override void Configure()
    {
        Delete("/products/{id:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");
        await productService.DeleteProduct(id);
        
        await SendAsync(new ApiResponse(true,"Product deleted successfully."), (int)HttpStatusCode.Accepted, ct);
    }
}