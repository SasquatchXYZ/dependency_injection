using System;
using System.ComponentModel;
using System.Windows.Input;
using ProductManagement.Domain;
using ProductManagement.PresentationLogic.UICommands;

namespace ProductManagement.PresentationLogic.ViewModels
{
    public class NewProductViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly IProductRepository _productRepository;

        private Action _whenDone;

        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

        public Product Model { get; private set; }

        public ICommand CancelCommand { get; }
        public ICommand SaveProductCommand { get; }

        public NewProductViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

            SaveProductCommand = new RelayCommand(SaveProduct);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void Initialize(Action whenDone, object model)
        {
            _whenDone = whenDone ?? throw new ArgumentNullException(nameof(whenDone));
            Model = new Product {Id = Guid.NewGuid()};
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Model"));
        }

        private void Cancel() => _whenDone();

        private void SaveProduct()
        {
            _productRepository.Insert(Model);
            _whenDone();
        }
    }
}