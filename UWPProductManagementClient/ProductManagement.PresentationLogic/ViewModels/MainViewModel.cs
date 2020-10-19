using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using ProductManagement.Domain;
using ProductManagement.PresentationLogic.UICommands;

namespace ProductManagement.PresentationLogic.ViewModels
{
    public class MainViewModel : IViewModel, INotifyPropertyChanged
    {
        private readonly INavigationService _navigationService;
        private readonly IProductRepository _productRepository;

        public MainViewModel(INavigationService navigationService, IProductRepository productRepository)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));

            AddProductCommand = new RelayCommand(AddProduct);
            EditProductCommmand = new RelayCommand(EditProduct);
        }

        public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };
        public IEnumerable<Product> Model { get; private set; }

        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommmand { get; }

        public void Initialize(Action whenDone, object model) => LoadProducts();

        private void LoadProducts()
        {
            Model = _productRepository.GetAll();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Model"));
        }

        private void AddProduct()
        {
            _navigationService.NavigateTo<NewProductViewModel>(whenDone: GoBack);
        }

        private void EditProduct(object product)
        {
            _navigationService.NavigateTo<EditProductViewModel>(whenDone: GoBack, model: product);
        }

        private void GoBack()
        {
            _navigationService.NavigateTo<MainViewModel>();
        }
    }
}