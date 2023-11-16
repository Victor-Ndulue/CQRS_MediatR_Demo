using CQRS_MediatR_Demo.Data;
using CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.ICommonRepo;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CQRS_MediatR_Demo.Repositories.QueryRepo.Implementations.CommonRepo;

public class QueryRepoBase<T> : IQueryRepoBase<T> where T : class
{
    private readonly DataContext _dataContext;
    private readonly DbSet<T> _tData;
    public QueryRepoBase(DataContext dataContext)
    {
        _dataContext = dataContext;
        _tData = _dataContext.Set<T>();
    }

    public IQueryable<T> FindAll()
    {
        var query = _tData;
        return query;
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        var query = _tData;
        return query.Where(expression);
    }
}
