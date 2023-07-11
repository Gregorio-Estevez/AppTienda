using CajaDiseño.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace CajaDiseño.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand MenuViewCommand { get; set; }

        public RelayCommand VentasViewCommand { get; set; }

        public RelayCommand ComprasViewCommand { get; set; }

        public RelayCommand ReparacionesViewCommand { get; set; }

        public RelayCommand Ventas2ViewCommand { get; set; }

        public RelayCommand Compras2ViewCommand { get; set; }

        public RelayCommand Menu2ViewCommand { get; set; }

        public RelayCommand RetiroViewCommand { get; set; }

        public RelayCommand ConfiguracionViewCommand { get; set; }
        


        public ProductosViewModel MenuVM { get; set; }

        public ReportesViewModel VentasVM { get; set; }

        public EnviosViewModel ComprasVM { get; set; }

        public ReparacionesViewModel ReparacionesVM { get; set; }

        public Ventas2ViewModel Ventas2VM { get; set; }

        public Compras2ViewModel Compras2VM { get; set; }

        public Menu2ViewModel Menu2VM { get; set; }

        public RetiroViewModel RetiroVM { get; set; }

        public ConfiguracionViewModel ConfiguracionVM { get; set; }



        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                  _currentView = value;
                OnPropertyChanged();
                 }
        }


        public MainViewModel()
        {
            MenuVM = new ProductosViewModel();
            VentasVM = new ReportesViewModel();
            ComprasVM = new EnviosViewModel();
            ReparacionesVM = new ReparacionesViewModel();
            Ventas2VM = new Ventas2ViewModel();
            Compras2VM = new Compras2ViewModel();
            Menu2VM = new Menu2ViewModel();
            RetiroVM = new RetiroViewModel();
            ConfiguracionVM = new ConfiguracionViewModel();
            CurrentView = Menu2VM;

            MenuViewCommand = new RelayCommand(o =>
            {
                CurrentView = MenuVM;
            });

            VentasViewCommand = new RelayCommand(o =>
            {
                CurrentView = VentasVM;
            });

            ComprasViewCommand = new RelayCommand(o =>
            {
                CurrentView = ComprasVM;
            });

            ReparacionesViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReparacionesVM;
            });

            Ventas2ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Ventas2VM;
            });

            Compras2ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Compras2VM;
            });

            Menu2ViewCommand = new RelayCommand(o =>
            {
                CurrentView = Menu2VM;
            });

            RetiroViewCommand = new RelayCommand(o =>
            {
                CurrentView = RetiroVM;
            });

            ConfiguracionViewCommand = new RelayCommand(o =>
            {
                CurrentView = ConfiguracionVM;
            });


        }
    }

 
}


