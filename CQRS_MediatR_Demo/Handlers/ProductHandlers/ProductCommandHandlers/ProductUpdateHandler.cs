using CQRS_MediatR_Demo.Commands.ProductCommands;
using CQRS_MediatR_Demo.Dtos.Responses;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.IEntityRepo;
using MediatR;

namespace CQRS_MediatR_Demo.Handlers.ProductHandlers.ProductCommandHandlers;

public class ProductUpdateHandler : IRequestHandler<ProductUpdateCommand, ProductResponseDto>
{
    private readonly IProductRepoCommand _productRepoCommand;

    public ProductUpdateHandler(IProductRepoCommand productRepoCommand)
    {
        _productRepoCommand = productRepoCommand;
    }

    public async Task<ProductResponseDto> Handle
        (ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        return await _productRepoCommand.UpdateProductAsync(request.ProductUpdateDto);
    }
}
