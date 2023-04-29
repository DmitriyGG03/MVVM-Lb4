
namespace MVVM_Lb4.Domain.AbstractCommands
{
    public interface IUpdateCommand<T>
    {
        Task Execute(T youTubeViewer);
    }
}
