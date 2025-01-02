using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urwave.Application.Exceptions;
using Urwave.Application.Resources;
using Urwave.Application.Services.Core;
using Urwave.Core.Entities;
using Urwave.DataAccess.Repositories.Core;
using Urwave.DataAccess.UnitOfWork;

namespace Urwave.Application.Services.Implementation;
public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ProductService(IProductRepository productRepository,IMapper mapper,IUnitOfWork unitOfWork)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<ProductResource> AddProduct(ProductRequest productRequst)
    {
        var product = mapper.Map<Product>(productRequst);
        product = await productRepository.AddAsync(product);
        await unitOfWork.CommitAsync();

        return mapper.Map<ProductResource>(product);
    }
    public async Task<ProductResource> GetProduct(int id)
    {
        var product = await productRepository.GetById(id);
        if (product == null) throw new NotFoundException($"Product with ID {id} not found.");

        return mapper.Map<Product, ProductResource>(product);
    }

    public async Task<List<ProductResource>> GetProducts()
    {
        var products = await productRepository.GetAllAsync();
        return mapper.Map<List<Product>, List<ProductResource>>(products);
    }

    public async Task<ProductResource> UpdateProduct(int id, ProductRequest productRequst)
    {
        var product = await productRepository.GetById(id);
        if (product == null) throw new NotFoundException($"Product with ID {id} not found.");

        mapper.Map(productRequst,product);
        await unitOfWork.CommitAsync();

        product = await productRepository.GetById(id);

        return mapper.Map<Product, ProductResource>(product);
    }
    public async Task DeleteProduct(int id)
    {
        var product = await productRepository.GetById(id);
        if (product == null) throw new NotFoundException($"Product with ID {id} not found.");

        product = productRepository.Delete(product);
        await unitOfWork.CommitAsync();
    }

}
