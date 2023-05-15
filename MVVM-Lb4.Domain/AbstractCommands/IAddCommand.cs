namespace MVVM_Lb4.Domain.AbstractCommands
{
    public interface IAddCommand<T>
    {
        Task Execute(T group);
    }
}
