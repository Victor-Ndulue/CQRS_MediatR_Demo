namespace CQRS_MediatR_Demo.Dtos.Responses;

public record ProductResponseDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}