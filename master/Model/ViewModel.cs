using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace master.Model
{
    internal class ViewModel : INotifyPropertyChanged
    {

        #region common
        private View _view;
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ViewModel(View view)
        {
            _view = view;
        }

        #endregion common

        #region ICommand

        public class RelayCommand : ICommand
        {
            private readonly Action _execute;

            public RelayCommand(Action execute)
            {
                _execute = execute;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object parameter) => true;

            public void Execute(object parameter) => _execute();
        }
        private ICommand _changeString1Command;
        private ICommand _changeString2Command;
        public ICommand ChangeString1Command => _changeString1Command ??= new RelayCommand(ChangeString1);
        public ICommand ChangeString2Command => _changeString2Command ??= new RelayCommand(ChangeString2);


        #endregion ICommand

        #region string
        public string String11
        {
            get => _view.String1;
            set
            {
                _view.String1 = value;
                OnPropertyChanged(nameof(String11));
            }
        }

        public string String22
        {
            get => _view.String2;
            set
            {
                _view.String2 = value;
                OnPropertyChanged(nameof(String22));
            }
        }
        #endregion string

        #region Function
        #region Button
        private void ChangeString1()
        {
            String11 = "test1";
        }

        private void ChangeString2()
        {
            String22 = "test2";
        }
        #endregion Button
        #endregion Function
    }
}
