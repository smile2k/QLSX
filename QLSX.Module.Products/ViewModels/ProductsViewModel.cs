using QLSX.Based.Common.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Products.ViewModels
{
    public class ProductsViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        private ObservableCollection<Item> _data;
        public ObservableCollection<Item> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
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

        public ProductsViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;

            Data = new ObservableCollection<Item>
            {
                new Item { Id = 1, Sku = "AH123", ProductName = "Áo thu đông", Factory = "Thanh trì", Status = "Đã xong" },
                new Item { Id = 2, Sku = "AH123", ProductName = "Áo thu đông", Factory = "Chương Mỹ", Status = "Đã xong"  },
                new Item { Id = 3, Sku = "AK456", ProductName = "Áo khoác", Factory = "Thanh Trì", Status = "Đang sản xuất" },
                new Item { Id = 4, Sku = "BH190", ProductName = "Áo cộc", Factory = "", Status = "Chờ xếp xưởng" },
                new Item { Id = 5, Sku = "HO999", ProductName = "Áo len", Factory = "Yên Xá", Status = "Đã xong" },
            };

            this.EditCommand = new DelegateCommand<object>(EditItem);
            this.DeleteCommand = new DelegateCommand<object>(DeleteItem);
            this.CreateProductCommand = new DelegateCommand(CreateProduct);
            this.FilterProductCommand = new DelegateCommand(FilterProduct);

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
            if (obj is Item item)
            {
                Data.Remove(item);
            }
        }

        private void CreateProduct()
        {

        }
        private void FilterProduct()
        {

        }

    }
}
