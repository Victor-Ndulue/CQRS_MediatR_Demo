namespace CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.ICommonRepo;

public interface ICommandRepoBase<T>
{
    Task<T> CreateAsync(T item);
    Task<T> UpdateAsync(T item);
    Task DeleteAsync(T item);
}
