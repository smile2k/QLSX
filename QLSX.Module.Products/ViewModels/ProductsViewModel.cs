using Microsoft.EntityFrameworkCore;
using QLSX.Based.Common.Events;
using QLSX.Based.Common.Models;
using QLSX.Services.Data;
using QLSX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Products.ViewModels
{
    public class ProductsViewModel : BindableBase, INavigationAware
    {

        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;
        private readonly IDBService _dbService;

        private readonly AppDbContext _context = new AppDbContext();

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        private string _skuTxb ="";
        public string SkuTxb
        {
            get => _skuTxb;
            set => SetProperty(ref _skuTxb, value);
        }

        private string _factoryTxb ="";
        public string FactoryTxb
        {
            get => _factoryTxb;
            set => SetProperty(ref _factoryTxb, value);
        }

        private string _stepTxb ="";
        public string StepTxb
        {
            get => _stepTxb;
            set => SetProperty(ref _stepTxb, value);
        }

        private string _statusTxb ="";
        public string StatusTxb
        {
            get => _statusTxb;
            set => SetProperty(ref _statusTxb, value);
        }

        public ProductsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator,
                                IDialogService dialogService, IDBService dbService)
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;
            this._dialogService = dialogService;
            this._dbService = dbService;

            this.EditCommand = new DelegateCommand<object>(EditItem);
            this.DeleteCommand = new DelegateCommand<object>(DeleteItem);
            this.CreateProductCommand = new DelegateCommand(CreateProduct);
            this.FilterProductCommand = new DelegateCommand(FilterProduct);

            InitProductDataGrid();
        }
        public class Item
        {
            public int Id { get; set; }
            public string Sku { get; set; }
            public string ProductName { get; set; }
            public string Factory { get; set; }
            public string Status { get; set; }
            public int Action { get; set; }
        }


        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand CreateProductCommand { get; }
        public ICommand FilterProductCommand { get; }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters.ContainsKey("CompletedProduct"))
            {
                var queryString = navigationContext.Parameters["CompletedProduct"] as string;  
                
                // Call Query
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;    
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        private void EditItem(object obj)
        {
            if (obj is Item item)
            {
                var payload = new EventPayload<string>
                {
                    Id = "001_ChangePageHeader",
                    Data = "Sản phẩm > Sửa"
                };

                _eventAggregator.GetEvent<GenericEvent<string>>().Publish(payload);
                _regionManager.RequestNavigate("ContentRegion", "EditProductView");
            }
        }

        private void DeleteItem(object obj)
        {
            _dialogService.ShowDialog("CustomPopup", new DialogParameters { { "Message", "Bạn có chắc chắn muốn xóa sản phẩm không?" } },
            result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    if (obj is Product item)
                    {
                        Products.Remove(item);
                    }

                }
            });
        }

        private async void InitProductDataGrid()
        {
            Products = await _dbService.GetAllProductsAsync();
        }

        private void CreateProduct()
        {

        }

        private void FilterProduct()
        {

        }

    }
}
