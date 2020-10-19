using System;
using System.ComponentModel;

namespace ProductManagement.PresentationLogic.ViewModels
{
    public class EditProductViewModel : IViewModel, INotifyPropertyChanged
    {
        public void Initialize(Action whenDone, object model)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}