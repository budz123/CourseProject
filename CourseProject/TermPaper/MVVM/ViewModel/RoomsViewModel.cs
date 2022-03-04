using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper.MVVM.ViewModel
{
    internal class RoomsViewModel : ObservableObject
    {

        public RelayCommand RoomsAddViewCommand { get; set; }
        public RelayCommand RoomsDeleteViewCommand { get; set; }
        public RelayCommand RoomsEditViewViewCommand { get; set; }


        public RoomsAddViewModel RoomsAddVM { get; set; }
        public RoomsDeleteViewModel RoomsDeleteVM { get; set; }
        public RoomsEditViewModel RoomsEditVM { get; set; }


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
        public RoomsViewModel()
        {

            RoomsAddVM = new RoomsAddViewModel();
            RoomsDeleteVM = new RoomsDeleteViewModel();
            RoomsEditVM = new RoomsEditViewModel();
            CurrentView = RoomsAddVM;

            RoomsAddViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomsAddVM;
            });
            RoomsDeleteViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomsDeleteVM;
            });
            RoomsEditViewViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomsEditVM;
            });
        }
    }
}
