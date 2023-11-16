namespace CQRS_MediatR_Demo.Dtos.Requests;

public record ProductUpdateDto 
{
    public string OldName { get; init; }
    public string NewName { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}