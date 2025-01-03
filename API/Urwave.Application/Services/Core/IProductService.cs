using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urwave.Application.Resources;

namespace Urwave.Application.Services.Core;
public interface IProductService
{
    Task<List<ProductResource>> GetProducts();
    Task<ProductResource> GetProduct(int id);
    Task<ProductResource> AddProduct(ProductRequest productRequst);
    Task<ProductResource> UpdateProduct(int id, ProductRequest productRequst);
    Task DeleteProduct(int id);

}