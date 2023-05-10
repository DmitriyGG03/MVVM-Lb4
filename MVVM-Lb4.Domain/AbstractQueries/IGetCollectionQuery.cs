using MVVM_Lb4.Domain.Models;

namespace MVVM_Lb4.Domain.AbstractQueries;

public interface IGetCollectionQuery<T>
{
    Task<List<T>> Execute(object? param = null);
}