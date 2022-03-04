using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermPaper.MVVM.ViewModel
{
    internal class ReservationsViewModel : ObservableObject
    {
        public RelayCommand ReservationsAddViewCommand { get; set; }
        public RelayCommand ReservationsDeleteViewCommand { get; set; }
        public RelayCommand ReservationsEditViewViewCommand { get; set; }


        public ReservationsAddViewModel ReservationsAddVM { get; set; }
        public ReservationsDeleteViewModel ReservationsDeleteVM { get; set; }
        public ReservationsEditViewModel ReservationsEditVM { get; set; }


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
        public ReservationsViewModel()
        {

            ReservationsAddVM = new ReservationsAddViewModel();
            ReservationsDeleteVM = new ReservationsDeleteViewModel();
            ReservationsEditVM = new ReservationsEditViewModel();
            CurrentView = ReservationsAddVM;

            ReservationsAddViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReservationsAddVM;
            });
            ReservationsDeleteViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReservationsDeleteVM;
            });
            ReservationsEditViewViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReservationsEditVM;
            });


        }

    }
}
