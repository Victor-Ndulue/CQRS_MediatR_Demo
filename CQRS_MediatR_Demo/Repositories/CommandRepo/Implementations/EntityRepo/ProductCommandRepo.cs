using AutoMapper;
using CQRS_MediatR_Demo.Data;
using CQRS_MediatR_Demo.Dtos.Requests;
using CQRS_MediatR_Demo.Dtos.Responses;
using CQRS_MediatR_Demo.Models.Entities;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Implementations.CommonRepo;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.IEntityRepo;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Implementations.EntityRepo;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR_Demo.Repositories.CommandRepo.Implementations.EntityRepo;

public class ProductCommandRepo : CommandRepoBase<Product>, IProductRepoCommand
{
    private readonly IMapper _mapper;
    private readonly ProductQueryRepo _productQueryRepo;
    public ProductCommandRepo(DataContext dataContext, IMapper mapper, ProductQueryRepo productQueryRepo) : 
        base(dataContext)
    {
        _mapper = mapper;
        _productQueryRepo = productQueryRepo;
    }

    public async Task<ProductResponseDto> AddProductAsync(ProductCreationDto requestDto)
    {
        var mapRequestToProduct = _mapper.Map<Product>(requestDto);
        var product = await CreateAsync(mapRequestToProduct);
        var mapProductToResponse = _mapper.Map<ProductResponseDto>(product);

        return mapProductToResponse;
    }

    public async Task<ProductResponseDto> UpdateProductAsync(ProductUpdateDto requestDto)
    {
        var productToUpdate = await _productQueryRepo.
            FindByCondition(p => p.Name.Equals(requestDto.OldName)).
            SingleOrDefaultAsync();
        var mapRequestToProduct = _mapper.Map(requestDto, productToUpdate);
        var product = await UpdateAsync(mapRequestToProduct);
        var mapProductToResponse = _mapper.Map<ProductResponseDto>(product);

        return mapProductToResponse;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        try
        {
            var productToDelete = await _productQueryRepo
                .FindByCondition(p => p.Id == id)
                .SingleOrDefaultAsync();
            await DeleteAsync(productToDelete);
            return true;
        } catch { return false; }
    }
}
