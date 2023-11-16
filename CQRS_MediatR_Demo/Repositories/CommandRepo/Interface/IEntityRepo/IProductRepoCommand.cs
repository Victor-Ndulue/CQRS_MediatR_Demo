using CQRS_MediatR_Demo.Dtos.Requests;
using CQRS_MediatR_Demo.Dtos.Responses;
using CQRS_MediatR_Demo.Models.Entities;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.ICommonRepo;

namespace CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.IEntityRepo;

public interface IProductRepoCommand : ICommandRepoBase<Product>
{
    Task<ProductResponseDto> AddProductAsync(ProductCreationDto requestDto);
    Task<ProductResponseDto> UpdateProductAsync(ProductUpdateDto requestDto);
    Task<bool> DeleteProductAsync(int id);
}
