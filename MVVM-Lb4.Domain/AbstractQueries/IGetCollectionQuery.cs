namespace MVVM_Lb4.Domain.AbstractQueries;

public interface IGetCollectionQuery<T>
{
    Task<IEnumerable<T>> Execute();
}