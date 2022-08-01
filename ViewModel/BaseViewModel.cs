using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EntityFraemworkPetProject.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public virtual void UpdateAllProperty()
        {
        }
    }
}
