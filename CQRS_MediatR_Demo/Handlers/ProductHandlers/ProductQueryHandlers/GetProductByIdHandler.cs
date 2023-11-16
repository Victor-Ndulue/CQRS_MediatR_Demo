using CQRS_MediatR_Demo.Dtos.Responses;
using CQRS_MediatR_Demo.Queries.ProductQueries;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.IEntityRepo;
using MediatR;

namespace CQRS_MediatR_Demo.Handlers.ProductHandlers.ProductQueryHandlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponseDto>
{
    private readonly IProductQueryRepo _productQueryRepo;

    public GetProductByIdHandler(IProductQueryRepo productQueryRepo)
    {
        _productQueryRepo = productQueryRepo;
    }

    public async Task<ProductResponseDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productQueryRepo.FindProductByIdAsync(request.Id);
    }
}
