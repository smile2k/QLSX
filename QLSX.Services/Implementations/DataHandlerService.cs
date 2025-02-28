using QLSX.Module.Main.ViewModels;
using QLSX.Module.Main.Views;
using QLSX.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLSX.Services.Implementations
{
    public class DataHandlerService : IDataHandlerService
    {
        private readonly IRegionManager _regionManager;
        private readonly IContainerProvider _containerProvider;

        public DataHandlerService(IRegionManager regionManager, IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _containerProvider = containerProvider;
        }


    }
}
