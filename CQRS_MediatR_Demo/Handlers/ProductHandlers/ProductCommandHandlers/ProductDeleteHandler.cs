using CQRS_MediatR_Demo.Commands.ProductCommands;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.IEntityRepo;
using MediatR;

namespace CQRS_MediatR_Demo.Handlers.ProductHandlers.ProductCommandHandlers;

public class ProductDeleteHandler : IRequestHandler<ProductDeleteCommand, bool>
{
    private readonly IProductRepoCommand _productRepoCommand;

    public ProductDeleteHandler(IProductRepoCommand productRepoCommand)
    {
        _productRepoCommand = productRepoCommand;
    }

    public async Task<bool> Handle
        (ProductDeleteCommand request, CancellationToken cancellationToken)
    {
        return await _productRepoCommand.DeleteProductAsync(request.ProductId);
    }
}
