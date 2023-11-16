using CQRS_MediatR_Demo.Dtos.Responses;
using MediatR;

namespace CQRS_MediatR_Demo.Queries.ProductQueries;

public record GetProductListQuery : IRequest<IEnumerable<ProductResponseDto>>
{}
