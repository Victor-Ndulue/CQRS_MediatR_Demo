using AutoMapper;
using CQRS_MediatR_Demo.Data;
using CQRS_MediatR_Demo.Dtos.Responses;
using CQRS_MediatR_Demo.Models.Entities;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Implementations.CommonRepo;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.IEntityRepo;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR_Demo.Repositories.QueryRepo.Implementations.EntityRepo;

public class ProductQueryRepo : QueryRepoBase<Product>, IProductQueryRepo
{
    private readonly IMapper _mapper;
    public ProductQueryRepo(DataContext dataContext, IMapper mapper) : base(dataContext)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductResponseDto>> FindProductByNameAsync(string productName)
    {
        var products = await FindByCondition(p=>p.Name.Contains(productName)).ToListAsync();
        var mapProductsToResponse = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        return mapProductsToResponse;
    }

    public Task<ProductResponseDto> FindProductByIdAsync(int id)
    {
        var product = FindByCondition(p=>p.Id == id);
        var mapProductToResponse = _mapper.Map<ProductResponseDto>(product);
        return Task.FromResult(mapProductToResponse);
    }

    public async Task<IEnumerable<ProductResponseDto>> FindproductsByDescriptionAsync(string description)
    {
        var products = await FindByCondition(p=>p.Description.Contains(description)).ToListAsync();
        var mapProductsToResponse = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        return mapProductsToResponse;
    } 

    public async Task<IEnumerable<ProductResponseDto>> FindAllProductsAsync()
    {
        var products = await FindAll().ToListAsync();
        var mapProductsToResponse = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        return mapProductsToResponse;
    }
}
