using MediatR;

namespace CQRS_MediatR_Demo.Commands.ProductCommands;

public record ProductDeleteCommand: IRequest<bool> 
{
    public int ProductId { get; init; }
}
