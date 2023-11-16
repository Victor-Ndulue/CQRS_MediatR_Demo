using CQRS_MediatR_Demo.Dtos.Responses;
using CQRS_MediatR_Demo.Models.Entities;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.ICommonRepo;

namespace CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.IEntityRepo;

public interface IProductQueryRepo : IQueryRepoBase<Product>
{
    Task<IEnumerable<ProductResponseDto>> FindProductByNameAsync(string productName);
    Task<ProductResponseDto> FindProductByIdAsync(int id);
    Task<IEnumerable<ProductResponseDto>> FindproductsByDescriptionAsync(string description);
    Task<IEnumerable<ProductResponseDto>> FindAllProductsAsync();
}
