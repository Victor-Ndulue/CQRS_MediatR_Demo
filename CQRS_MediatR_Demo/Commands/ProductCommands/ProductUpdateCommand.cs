using CQRS_MediatR_Demo.Dtos.Requests;
using CQRS_MediatR_Demo.Dtos.Responses;
using MediatR;

namespace CQRS_MediatR_Demo.Commands.ProductCommands;

public record ProductUpdateCommand: IRequest<ProductResponseDto> 
{
    public ProductUpdateDto ProductUpdateDto { get; init; }
}
