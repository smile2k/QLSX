using QLSX.Based.Common.Events;
using QLSX.Module.Products.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Products.ViewModels
{
    public class EditProductViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        
        private ObservableCollection<EditProductData> _editProductDataTable;
        public ObservableCollection<EditProductData> EditProductDataTable
        {
            get { return _editProductDataTable; }
            set { SetProperty(ref _editProductDataTable, value); }
        }

        private ObservableCollection<string> _statusOptions;
        public ObservableCollection<string> StatusOptions
        {
            get => _statusOptions;
            set => SetProperty(ref _statusOptions, value);
        }

        public EditProductViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {

            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;

            StatusOptions = new ObservableCollection<string> { "Done", "Inprogress", "None", "Missing" };
            EditProductDataTable = new ObservableCollection<EditProductData>
            {
                new EditProductData { Step = 1, StepName = "Lấy vải", ExpectDay = DateTime.Now.AddDays(1), ActualDay = DateTime.Now.AddDays(3), Status = ProductionStatus.Done.ToString() },
                new EditProductData { Step = 2, StepName = "May", ExpectDay = DateTime.Now.AddDays(3), ActualDay = DateTime.Now.AddDays(5), Status = ProductionStatus.Inprogress.ToString()  },
                new EditProductData { Step = 3, StepName = "Thêu", ExpectDay = DateTime.Now.AddDays(5), ActualDay = DateTime.Now.AddDays(9), Status = ProductionStatus.Done.ToString() },
            };


            this.BackToProductCommand = new DelegateCommand(BackToProduct);
        }

        public ICommand BackToProductCommand { get; }
    

        private void BackToProduct()
        {
            var payload = new EventPayload<string>
            {
                Id = "001_ChangePageHeader",
                Data = "Sản phẩm"
            };

            _eventAggregator.GetEvent<GenericEvent<string>>().Publish(payload);

            _regionManager.RequestNavigate("ContentRegion", "ProductsView");
        }

        private void SaveEdittedProduct()
        {


        }
    }
}
