using QLSX.Based.Common.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Step.ViewModels
{
    public class StepViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;
        
        public class ProcessData
        {
            public int ID { get; set; }
            public string ProcessName { get; set; }
            public int Action { get; set; }
        }

        public class StepData
        {
            public int ID { get; set; }
            public string StepName { get; set; }
            public float ExecuteTime { get; set; }
            public DateTime CreatedTime { get; set; }
            public DateTime UpdatedTime { get; set; }
            public int Action { get; set; }
        }

        private ObservableCollection<ProcessData> _processSource;
        public ObservableCollection<ProcessData> ProcessSource
        {
            get => _processSource;
            set => SetProperty(ref _processSource, value);
        }
        
        private ObservableCollection<StepData> _stepSource;
        public ObservableCollection<StepData> StepSource
        {
            get => _stepSource;
            set => SetProperty(ref _stepSource, value);
        }

    
        public StepViewModel(IRegionManager regionManager, IEventAggregator eventAggregator,
                            IDialogService dialogService) 
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;
            this._dialogService = dialogService;

            ProcessSource = new ObservableCollection<ProcessData>
            {
                new ProcessData { ID = 1, ProcessName = "Áo ngủ"},
                new ProcessData { ID = 2, ProcessName = "Quần đùi" },
                new ProcessData { ID = 3, ProcessName = "Mũ" },
                new ProcessData { ID = 4, ProcessName = "Áo phông" },
                new ProcessData { ID = 5, ProcessName = "Áo sơ mi" },
            };

            this.EditCommand = new DelegateCommand<object>(EditItem);
            this.DeleteCommand = new DelegateCommand<object>(DeleteItem);
            this.AddStepCommand = new DelegateCommand(AddStep);
            this.SaveStepCommand = new DelegateCommand(SaveStep);

        }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddStepCommand { get; }
        public ICommand SaveStepCommand { get; }

        private void EditItem(object obj)
        {
            //if (obj is ProcessData item)
            //{
            //    var payload = new EventPayload<string>
            //    {
            //        Id = "001_ChangePageHeader",
            //        Data = "Quy trình > Sửa"
            //    };

            //    _eventAggregator.GetEvent<GenericEvent<string>>().Publish(payload);
            //    _regionManager.RequestNavigate("ContentRegion", "EditProductView");
            //}
        }

        private void DeleteItem(object obj)
        {
            _dialogService.ShowDialog("CustomPopup", new DialogParameters { { "Message", "Bạn có chắc chắn muốn xóa sản phẩm không?" } },
            result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    if (obj is ProcessData item)
                    {
                        ProcessSource.Remove(item);
                    }

                }
            });
        }

        private void SaveStep()
        {
            try
            {
                _dialogService.ShowDialog("CustomPopup", new DialogParameters { { "Message", "Bạn có chắc chắn muốn xóa sản phẩm không?" } },
                result =>
                {
                    if (result.Result == ButtonResult.OK)
                    {
                        //Logic to save step to Database.

                    }
                });
            }
            catch { }
        }

        private void AddStep()
        {
            try
            {
                StepData step = new StepData
                {
                    ID = StepSource.Count + 1,
                    StepName = "",
                    ExecuteTime = 0,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                };
                StepSource.Add(step);

            }
            catch { }
        }

    }
}
