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

        private ObservableCollection<Item> _data;
        public ObservableCollection<Item> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }


        public MainViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;

            // Sample data
            Data = new ObservableCollection<Item>
            {
                new Item { Id = 1, Name = "John Doe", Age = 30 },
                new Item { Id = 2, Name = "Jane Smith", Age = 25 },
                new Item { Id = 3, Name = "Alice Johnson", Age = 35 },
            };

            this.ShowDashboardTabCommand = new DelegateCommand(ShowDashboardTab);
            this.ShowProductsTabCommand = new DelegateCommand(ShowProductsTab);
            this.ShowFactoryTabCommand = new DelegateCommand(ShowFactoryTab);
            this.ShowStepTabCommand  = new DelegateCommand(ShowStepTab);
            this.ShowDetailTabCommand = new DelegateCommand(ShowDetailTab);
            this.EditCommand = new DelegateCommand<object>(EditItem);
            this.DeleteCommand = new DelegateCommand<object>(DeleteItem);
        }

        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public ICommand ShowDashboardTabCommand { get; set; }
        public ICommand ShowProductsTabCommand { get; set; }
        public ICommand ShowFactoryTabCommand { get; set; }
        public ICommand ShowStepTabCommand { get; set; }
        public ICommand ShowDetailTabCommand { get; set; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

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

        private void EditItem(object obj)
        {
            if (obj is Item item)
            {
                // Logic to edit item
            }
        }

        private void DeleteItem(object obj)
        {
            if (obj is Item item)
            {
                Data.Remove(item);
            }
        }
    }
}
