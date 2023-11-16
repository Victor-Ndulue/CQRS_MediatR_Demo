using CQRS_MediatR_Demo.Dtos.Responses;
using MediatR;

namespace CQRS_MediatR_Demo.Queries.ProductQueries;

public record GetProductsByDescriptionQuery : IRequest<IEnumerable<ProductResponseDto>> 
{
    public string Description { get; init; }
}
