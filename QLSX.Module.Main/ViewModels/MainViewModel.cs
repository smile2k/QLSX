using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Main.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private string _pageHeader= "Dashboard";
        public string PageHeader
        {
            get { return _pageHeader; }
            set { SetProperty(ref _pageHeader, value); }
        }


        public MainViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;

            // Sample data

            this.SelectTabCommand = new DelegateCommand<object>(SelectTab);
            this.ShowDashboardTabCommand = new DelegateCommand(ShowDashboardTab);
            this.ShowProductsTabCommand = new DelegateCommand(ShowProductsTab);
            this.ShowFactoryTabCommand = new DelegateCommand(ShowFactoryTab);
            this.ShowStepTabCommand  = new DelegateCommand(ShowStepTab);
            this.ShowDetailTabCommand = new DelegateCommand(ShowDetailTab);
        }


        public ICommand SelectTabCommand { get; set; }
        public ICommand ShowDashboardTabCommand { get; set; }
        public ICommand ShowProductsTabCommand { get; set; }
        public ICommand ShowFactoryTabCommand { get; set; }
        public ICommand ShowStepTabCommand { get; set; }
        public ICommand ShowDetailTabCommand { get; set; }


        private void SelectTab(object option)
        {

            switch (option.ToString())
            {
                case "Dashboard":
                    {
                        PageHeader = "Dashboard";
                        break;
                    }
                case "Products":
                    {
                        PageHeader = "Products";
                        _regionManager.RequestNavigate("ContentRegion", "ProductsView");
                        break;
                    }
            }
        }
        private void ShowDashboardTab()
        {

        }
        private void ShowProductsTab()
        {

        }
        private void ShowFactoryTab()
        {

        }
        private void ShowStepTab()
        {

        }
        private void ShowDetailTab()
        {

        }

    }
}
