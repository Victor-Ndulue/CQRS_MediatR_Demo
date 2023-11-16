using System.Linq.Expressions;

namespace CQRS_MediatR_Demo.Repositories.QueryRepo.Interface.ICommonRepo;

public interface IQueryRepoBase<T>
{
    IQueryable<T> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
}
