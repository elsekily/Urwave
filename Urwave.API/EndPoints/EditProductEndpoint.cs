using FastEndpoints;
using System.Net;
using Urwave.API.Validations;
using Urwave.Application.Resources;
using Urwave.Application.Services.Core;

namespace Urwave.API.EndPoints;

public class EditProductEndpoint : Endpoint<ProductRequest, ApiResponse>
{
    private readonly IProductService productService;

    public EditProductEndpoint(IProductService productService)
    {
        this.productService = productService;
    }
    public override void Configure()
    {
        Put("/products/{id:int}");
        AllowAnonymous();
        Validator<ProductRequestValidator>();
    }

    public override async Task HandleAsync(ProductRequest request, CancellationToken ct)
    {
        var id = Route<int>("id");

        var product = await productService.UpdateProduct(id,request);
        await SendAsync(new ProductResponse(true,"",product), (int)HttpStatusCode.OK, ct);
    }
}