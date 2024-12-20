using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        
        private Visibility _textVisibility = Visibility.Visible;
        public Visibility TextVisibility
        {
            get { return _textVisibility; }
            set { SetProperty(ref _textVisibility, value); }
        }
        
        private double _menuWidth = 300;
        public double MenuWidth
        {
            get { return _menuWidth; }
            set { SetProperty(ref _menuWidth, value); }
        }

        private double _iconSize = 250;
        public double IconSize
        {
            get { return _iconSize; }
            set { SetProperty(ref _iconSize, value); }
        }


        private string _expandButtonImageSource = "/QLSX.Module.Main;component/Resources/icons8-sidebar-left24.png";
        public string ExpandButtonImageSource
        {
            get { return _expandButtonImageSource; }
            set { SetProperty(ref _expandButtonImageSource, value); }
        }

        public MainViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            ExpandButtonImageSource = "/QLSX.Module.Main;component/Resources/icons8-sidebar-left24.png";
            MenuWidth = 300;
            // Sample data

            this.SelectTabCommand = new DelegateCommand<object>(SelectTab);
            this.ShowDashboardTabCommand = new DelegateCommand(ShowDashboardTab);
            this.ShowProductsTabCommand = new DelegateCommand(ShowProductsTab);
            this.ShowFactoryTabCommand = new DelegateCommand(ShowFactoryTab);
            this.ShowStepTabCommand  = new DelegateCommand(ShowStepTab);
            this.ShowDetailTabCommand = new DelegateCommand(ShowDetailTab);

            this.ExpandCommand = new DelegateCommand(ExpandMenu);
        }


        public ICommand SelectTabCommand { get; set; }
        public ICommand ShowDashboardTabCommand { get; set; }
        public ICommand ShowProductsTabCommand { get; set; }
        public ICommand ShowFactoryTabCommand { get; set; }
        public ICommand ShowStepTabCommand { get; set; }
        public ICommand ShowDetailTabCommand { get; set; }

        public ICommand ExpandCommand { get; set; }

        private void SelectTab(object option)
        {

            switch (option.ToString())
            {
                case "Dashboard":
                    {
                        PageHeader = "Bảng điều khiển";
                        break;
                    }
                case "Products":
                    {
                        PageHeader = "Sản phẩm";
                        _regionManager.RequestNavigate("ContentRegion", "ProductsView");
                        break;
                    }
            }
        }

        private void ExpandMenu()
        {
            switch (TextVisibility)
            {
                case Visibility.Visible:
                    {
                        ExpandButtonImageSource = "/QLSX.Module.Main;component/Resources/icons8-sidebar-right24.png";
                        MenuWidth = 60;
                        IconSize = 50;
                        TextVisibility = Visibility.Hidden;
                        break;
                    }

                case Visibility.Hidden:
                    {
                        ExpandButtonImageSource = "/QLSX.Module.Main;component/Resources/icons8-sidebar-left24.png";
                        MenuWidth = 320;
                        IconSize = 250;
                        TextVisibility = Visibility.Visible;
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
