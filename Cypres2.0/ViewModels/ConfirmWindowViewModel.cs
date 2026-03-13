using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cypres2._0.ViewModels
{
    public class ConfirmWindowViewModel: BaseViewModel
    {
        private readonly Action _closeDialog;
        public string Message { get; }
        public string Title { get; }
        public bool Confirmed { get; private set; }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public ConfirmWindowViewModel(string message, string title, Action closeDialog)
        {
            Message = message;
            Title = title;
            _closeDialog = closeDialog;
            ConfirmCommand = new RelayCommand(Confirm);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Confirm()
        {
            Confirmed = true;
            _closeDialog();
        }
        private void Cancel()
        {
            Confirmed = false;
            _closeDialog();
        }
    }
}
