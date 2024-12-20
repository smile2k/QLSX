using QLSX.Module.Products.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSX.Module.Products.ViewModels
{
    public class EditProductViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        
        private ObservableCollection<EditProductData> _editProductDataTable;
        public ObservableCollection<EditProductData> EditProductDataTable
        {
            get { return _editProductDataTable; }
            set { SetProperty(ref _editProductDataTable, value); }
        }

        private ObservableCollection<string> _statusOptions;
        public ObservableCollection<string> StatusOptions
        {
            get => _statusOptions;
            set => SetProperty(ref _statusOptions, value);
        }

        public EditProductViewModel(IRegionManager regionManager)
        {

            this._regionManager = regionManager;

            StatusOptions = new ObservableCollection<string> { "Done", "Inprogress", "None", "Missing" };
            EditProductDataTable = new ObservableCollection<EditProductData>
            {
                new EditProductData { Step = 1, StepName = "Lấy vải", ExpectDay = DateTime.Now.AddDays(1), ActualDay = DateTime.Now.AddDays(3), Status = ProductionStatus.Done.ToString() },
                new EditProductData { Step = 2, StepName = "May", ExpectDay = DateTime.Now.AddDays(3), ActualDay = DateTime.Now.AddDays(5), Status = ProductionStatus.Inprogress.ToString()  },
                new EditProductData { Step = 3, StepName = "Thêu", ExpectDay = DateTime.Now.AddDays(5), ActualDay = DateTime.Now.AddDays(9), Status = ProductionStatus.Done.ToString() },
            };


        }

    
    }
}
