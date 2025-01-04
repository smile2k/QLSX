using QLSX.Module.Factory.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public FactoryViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) 
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;

            FactorySource = new ObservableCollection<FactoryData>
            {
                new FactoryData { ID = 1, FactoryName = "Thanh trì", CompletedQuantity = 120, InprogressQuantity = 120},
                new FactoryData { ID = 2, FactoryName = "Chương Mỹ", CompletedQuantity = 200, InprogressQuantity = 120},
                new FactoryData { ID = 3, FactoryName = "Thanh Trì", CompletedQuantity = 500, InprogressQuantity = 120},
                new FactoryData { ID = 4, FactoryName = "Thanh Trì", CompletedQuantity = 300, InprogressQuantity = 120},
                new FactoryData { ID = 5, FactoryName = "Yên Xá",    CompletedQuantity = 200, InprogressQuantity = 120},
            };

        }
    }
}
