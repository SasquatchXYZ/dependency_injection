using System;
using Windows.UI.Xaml.Controls;
using ProductManagement.PresentationLogic.ViewModels;

namespace ProductManagement.UWPClient
{
    public sealed partial class NewProductPage : Page
    {
        public NewProductPage(NewProductViewModel vm)
        {
            if (vm == null) throw new ArgumentNullException(nameof(vm));

            this.InitializeComponent();

            this.DataContext = vm;
        }
    }
}