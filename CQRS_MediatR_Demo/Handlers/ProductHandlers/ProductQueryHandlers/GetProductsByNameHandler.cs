using CQRS_MediatR_Demo.Dtos.Responses;
using CQRS_MediatR_Demo.Queries.ProductQueries;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.IEntityRepo;
using MediatR;

namespace CQRS_MediatR_Demo.Handlers.ProductHandlers.ProductQueryHandlers;

public class GetProductsByNameHandler : IRequestHandler<GetProductsByNameQuery, IEnumerable<ProductResponseDto>>
{
    private readonly IProductQueryRepo _productQueryRepo;

    public GetProductsByNameHandler(IProductQueryRepo productQueryRepo)
    {
        _productQueryRepo = productQueryRepo;
    }

    public async Task<IEnumerable<ProductResponseDto>> Handle
        (GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        return await _productQueryRepo.FindProductByNameAsync(request.ProductName);
    }
}
