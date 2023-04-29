
namespace MVVM_Lb4.Domain.AbstractCommands
{
    public interface ICreateCommand<T>
    {
        Task Execute(T group);
    }
}
