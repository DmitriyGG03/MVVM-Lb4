using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM_Lb4.Domain.Models.Base;

public class ModelBase
{
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}