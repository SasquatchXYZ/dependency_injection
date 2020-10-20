using System;
using System.ComponentModel;
using System.Windows.Input;
using ProductManagement.Domain;
using ProductManagement.PresentationLogic.UICommands;

namespace ProductManagement.PresentationLogic.ViewModels
{
    public class EditProductViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly IProductRepository _productRepository;

        private Action _whenDone;

        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

        public Product Model { get; private set; }

        public ICommand SaveProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand CancelCommand { get; }

        public EditProductViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

            SaveProductCommand = new RelayCommand(SaveProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void Initialize(Action whenDone, object model)
        {
            if (!(model is Product)) throw new ArgumentException("model should be a Product");

            Guid productId = ((Product) model).Id;
            _whenDone = whenDone ?? throw new ArgumentNullException(nameof(whenDone));
            Model = _productRepository.GetById(productId);

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Model"));
        }

        private void SaveProduct()
        {
            _productRepository.Update(Model);
            _whenDone();
        }

        private void DeleteProduct()
        {
            _productRepository.Delete(Model.Id);
            _whenDone();
        }

        private void Cancel() => _whenDone();
    }
}