using CQRS_MediatR_Demo.Data;
using CQRS_MediatR_Demo.Repositories.CommandRepo.Interface.ICommonRepo;

namespace CQRS_MediatR_Demo.Repositories.CommandRepo.Implementations.CommonRepo;

public class CommandRepoBase<T> : ICommandRepoBase<T> where T : class
{
    private readonly DataContext _dataContext;
    public CommandRepoBase(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// A method that creates an object T in the database and returns the created object details
    /// </summary>
    /// <param name="item">An object of type <T> created in the database</param>
    /// <returns>The <T> object</returns>
    public async Task<T> CreateAsync(T item)
    {
        var result = await _dataContext.AddAsync(item);
        await _dataContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task DeleteAsync(T item)
    {
        _dataContext.Remove(item);
        await _dataContext.SaveChangesAsync();
    }

    /// <summary>
    /// A method to update an object in the database
    /// </summary>
    /// <param name="item">object update for an existing object in the db</param>
    /// <returns>The object updated</returns>
    public async Task<T> UpdateAsync(T item)
    {
         var result = _dataContext.Update(item);
        await _dataContext.SaveChangesAsync();
        return result.Entity;
    }
}
