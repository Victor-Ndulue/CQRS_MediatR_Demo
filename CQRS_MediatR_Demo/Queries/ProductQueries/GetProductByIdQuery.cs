using CQRS_MediatR_Demo.Dtos.Responses;
using MediatR;

namespace CQRS_MediatR_Demo.Queries.ProductQueries;

public record GetProductByIdQuery : IRequest<ProductResponseDto> 
{
    public int Id { get; init; }
}
