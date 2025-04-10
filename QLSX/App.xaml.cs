using System.Configuration;
using System.Data;
using System.Windows;
using Prism.Mvvm;
using Prism.Ioc;
using Prism.Unity;
using QLSX.Services.Implementations;
using QLSX.Services.Interfaces;
using QLSX.Module.Main.Views;
using QLSX.Module.Main.ViewModels;

namespace QLSX.MainWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
         protected override Window CreateShell()
         {
            // Return the main window of the application. 
            return Container.Resolve<Main.Views.MainWindowView>();
         }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Service.
            containerRegistry.RegisterSingleton<IDataHandlerService, DataHandlerService>();
            containerRegistry.RegisterDialog<CustomPopup, CustomPopupViewModel>();

            // Register View for Navigation.
            containerRegistry.RegisterForNavigation<QLSX.Module.Products.Views.ProductsView>();
            containerRegistry.RegisterForNavigation<QLSX.Module.Products.Views.EditProductView>();
            containerRegistry.RegisterForNavigation<QLSX.Module.Factory.Views.FactoryView>();
            containerRegistry.RegisterForNavigation<QLSX.Module.Workflow.Views.WorkflowView>();
            containerRegistry.RegisterForNavigation<QLSX.Module.Workflow.Views.ProcessView>();
            containerRegistry.RegisterForNavigation<QLSX.Module.Workflow.Views.EditProcessView>();
            containerRegistry.RegisterForNavigation<QLSX.Module.Workflow.Views.StepView>();
            containerRegistry.RegisterForNavigation<QLSX.Module.Workflow.Views.EditStepView>();


            // Register EventAggregator.
            containerRegistry.RegisterSingleton<IEventAggregator, EventAggregator>();

        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            // Register View with ViewModel
            ViewModelLocationProvider.Register<QLSX.Module.Main.Views.MainView, QLSX.Module.Main.ViewModels.MainViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Products.Views.ProductsView, QLSX.Module.Products.ViewModels.ProductsViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Products.Views.EditProductView, QLSX.Module.Products.ViewModels.EditProductViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Factory.Views.FactoryView, QLSX.Module.Factory.ViewModels.FactoryViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Workflow.Views.WorkflowView, QLSX.Module.Workflow.ViewModels.WorkflowViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Main.Views.CustomPopup, QLSX.Module.Main.ViewModels.CustomPopupViewModel>();

            ViewModelLocationProvider.Register<QLSX.Module.Workflow.Views.ProcessView, QLSX.Module.Workflow.ViewModels.ProcessViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Workflow.Views.EditProcessView, QLSX.Module.Workflow.ViewModels.EditProcessViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Workflow.Views.StepView, QLSX.Module.Workflow.ViewModels.StepViewModel>();
            ViewModelLocationProvider.Register<QLSX.Module.Workflow.Views.EditStepView, QLSX.Module.Workflow.ViewModels.EditStepViewModel>();
        }
    }

}
