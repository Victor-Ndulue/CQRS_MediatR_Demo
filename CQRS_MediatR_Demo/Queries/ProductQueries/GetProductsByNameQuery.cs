using CQRS_MediatR_Demo.Dtos.Responses;
using MediatR;

namespace CQRS_MediatR_Demo.Queries.ProductQueries;

public record GetProductsByNameQuery: IRequest<IEnumerable<ProductResponseDto>> 
{
    public string ProductName { get; init; }
}
