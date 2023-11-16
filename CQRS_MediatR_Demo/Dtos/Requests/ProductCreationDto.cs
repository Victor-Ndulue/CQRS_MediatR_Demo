namespace CQRS_MediatR_Demo.Dtos.Requests;

public record ProductCreationDto 
{
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}
