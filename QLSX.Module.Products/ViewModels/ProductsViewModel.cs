﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Products.ViewModels
{
    public class ProductsViewModel : BindableBase
    {

        private readonly IRegionManager _regionManager;
        private ObservableCollection<Item> _data;
        public ObservableCollection<Item> Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        public ProductsViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            Data = new ObservableCollection<Item>
            {
                new Item { Id = 1, Name = "John Doe", Age = 30 },
                new Item { Id = 2, Name = "Jane Smith", Age = 25 },
                new Item { Id = 3, Name = "Alice Johnson", Age = 35 },
            };

            this.EditCommand = new DelegateCommand<object>(EditItem);
            this.DeleteCommand = new DelegateCommand<object>(DeleteItem);

        }
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }


        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }



        private void EditItem(object obj)
        {
            if (obj is Item item)
            {
                _regionManager.RequestNavigate("ContentRegion", "EditProductView");
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