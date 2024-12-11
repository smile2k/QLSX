﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLSX.Main.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        IRegionManager _regionManager;
        public MainWindowView(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;

             // Register view with region.
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(QLSX.Module.Main.Views.MainView));
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(QLSX.Module.Products.Views.ProductsView));
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(QLSX.Module.Products.Views.EditProductView));
        }
    }
}
