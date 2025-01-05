using QLSX.Module.Factory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Factory.ViewModels
{
    public class FactoryViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        private ObservableCollection<FactoryData> _factorySource;
        public ObservableCollection<FactoryData> FactorySource
        {
            get => _factorySource;
            set => SetProperty(ref _factorySource, value);
        }

        private DateTime? _startDate;        
        public DateTime? StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }
        
        private DateTime? _endDate;        
        public DateTime? EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public FactoryViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) 
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;

            StartDate = DateTime.Today.AddMonths(-1);
            EndDate = DateTime.Today;

            FactorySource = new ObservableCollection<FactoryData>
            {
                new FactoryData { ID = 1, FactoryName = "Thanh trì", CompletedQuantity = 120, InprogressQuantity = 120},
                new FactoryData { ID = 2, FactoryName = "Chương Mỹ", CompletedQuantity = 200, InprogressQuantity = 120},
                new FactoryData { ID = 3, FactoryName = "Thanh Trì", CompletedQuantity = 500, InprogressQuantity = 120},
                new FactoryData { ID = 4, FactoryName = "Thanh Trì", CompletedQuantity = 300, InprogressQuantity = 120},
                new FactoryData { ID = 5, FactoryName = "Yên Xá",    CompletedQuantity = 200, InprogressQuantity = 120},
            };

            this.SearchCompletedProductCommand = new DelegateCommand<object>(SearchCompletedProduct);
            this.SearchInprogressProductCommand = new DelegateCommand<Object>(SearchInprogressProduct);
        }

        public ICommand SearchCompletedProductCommand { get; }
        public ICommand SearchInprogressProductCommand { get; }


        private void SearchCompletedProduct(object param)
        {
            var factory = param as FactoryData;
            if (factory != null)
            {
                string queryString = "";
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("CompletedProduct", queryString);

                _regionManager.RequestNavigate("ContentRegion", "ProductsView", navigationParameters);
            }
        }

        private void SearchInprogressProduct(object param)
        {
            var factory = param as FactoryData;
            if (factory != null)
            {
                string queryString = "";
                var navigationParameters = new NavigationParameters();
                navigationParameters.Add("InprogressProduct", queryString);

                _regionManager.RequestNavigate("ContentRegion", "ProductsView", navigationParameters);
            }
        }
    }
}
