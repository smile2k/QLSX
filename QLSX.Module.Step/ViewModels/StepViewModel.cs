using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Module.Step.ViewModels
{
    public class StepViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
    
        public StepViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) 
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;

        }

    }
}
