using Airlanes.View;
using System.Windows;
using System.Windows.Input;

namespace Airlanes.ViewModel
{
    public class MainWindowViewModel
    {
        private Window window;
        public MainWindowViewModel(Window window)
        {
            this.window = window;
            OpenCapitanViewCommand=new Commands(OpenCapitanView);
            OpenPassengerViewCommand = new Commands(OpenPassengerView);
            OpenPlaneViewCommand = new Commands(OpenPlaneView);
            OpenRouteViewCommand = new Commands(OpenRouteView);
            OpenFlightViewCommand = new Commands(OpenFlightView);
        }
        private void OpenCapitanView(object obj)
        {
            CapitanView airlanesView = new CapitanView();
            airlanesView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            airlanesView.Show();
            window.Close();
        }

        public void OpenPassengerView(object obj)
        {
            PassengerView view = new();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            window.Close();
        }

        public void OpenPlaneView(object obj)
        {
            PlaneView view = new();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            window.Close();
        }

        public void OpenRouteView(object obj)
        {
            RouteView view = new();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            window.Close();
        }

        public void OpenFlightView(object obj)
        {
            FlightView view = new();
            view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            view.Show();
            window.Close();
        }

        public ICommand OpenFlightViewCommand { get; private set; }

        public ICommand OpenCapitanViewCommand {  get; private set; }

        public ICommand OpenPassengerViewCommand { get; private set; }

        public ICommand OpenPlaneViewCommand { get; private set; }

        public ICommand OpenRouteViewCommand { get; private set; }

    }
}
