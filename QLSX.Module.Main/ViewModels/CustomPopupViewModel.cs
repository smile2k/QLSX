using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLSX.Module.Main.ViewModels
{
    public class CustomPopupViewModel : BindableBase, IDialogAware
    {
        private TaskCompletionSource<bool> _taskCompletionSource;

        private string _message="";
        public string Message 
        {
            get => _message;
            set => SetProperty(ref _message, value); 
        }

        public ICommand ConfirmCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CustomPopupViewModel()
        {
            ConfirmCommand = new DelegateCommand(Confirm);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private void Confirm()
        {
            CloseDialog(new DialogResult(ButtonResult.OK));
        }

        private void Cancel()
        {
            CloseDialog(new DialogResult(ButtonResult.Cancel));
        }

        #region Implement Dialog
        public bool CanCloseDialog() => true;
        public void OnDialogClosed() { }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("Message");   
        }

        public DialogCloseListener RequestClose { get; }

        private void CloseDialog(DialogResult dialogResult)
        {
            RequestClose.Invoke(dialogResult);
        }

        #endregion
    }

}
