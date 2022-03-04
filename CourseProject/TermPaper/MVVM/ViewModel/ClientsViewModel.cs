using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TermPaper;


namespace TermPaper.MVVM.ViewModel
{
    internal class ClientsViewModel : ObservableObject
    {
        public RelayCommand ClientsAddViewCommand { get; set; }
        public RelayCommand ClientsDeleteViewCommand { get; set; }
        public RelayCommand ClietnsEditViewViewCommand { get; set; }


        public ClientsAddViewModel ClientsAddVM { get; set; }
        public ClientsDeleteViewModel ClientsDeleteVM { get; set; }
        public ClientsEditViewModel ClietnsEditVM { get; set; }
       

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public ClientsViewModel()
        {

            ClientsAddVM = new  ClientsAddViewModel();
            ClientsDeleteVM = new ClientsDeleteViewModel();
            ClietnsEditVM = new ClientsEditViewModel();
            CurrentView = ClientsAddVM;

            ClientsAddViewCommand = new RelayCommand(o =>
            {
                CurrentView = ClientsAddVM;
            });
            ClientsDeleteViewCommand = new RelayCommand(o =>
            {
                CurrentView = ClientsDeleteVM;
            });
            ClietnsEditViewViewCommand = new RelayCommand(o =>
            {
                CurrentView = ClietnsEditVM;
            });
           

        }
    }
}
