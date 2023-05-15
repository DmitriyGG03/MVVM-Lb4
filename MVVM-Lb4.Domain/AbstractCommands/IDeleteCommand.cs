namespace MVVM_Lb4.Domain.AbstractCommands
{
    public interface IDeleteCommand<T>
    {
        Task Execute(Guid id);
    }
}
