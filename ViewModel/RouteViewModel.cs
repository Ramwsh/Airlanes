using Airlanes.Model.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airlanes.ViewModel;

internal class RouteViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private Window _currentWindow;
    private int _numberOfRoute;
    private string _departureAirpoint;
    private string _destinationAirport;
    private double _price;
    private int _flightDuration;
    private ObservableCollection<Route> _routes;
    private Route _selectedRoute;    

    public RouteViewModel(Window window)
    {
        _currentWindow = window;
        Controller<Route> controller = new Controller<Route>();
        Routes = new ObservableCollection<Route>(controller.Read());
        CreateRouteCommand = new Commands(CreateRoute);
        DeleteRouteCommand = new Commands(DeleteRoute);
        UpdateRouteCommand = new Commands(UpdateRoute);
    }

    public ICommand CreateRouteCommand { get; private set; }
    public ICommand DeleteRouteCommand { get; private set; }
    public ICommand UpdateRouteCommand { get; private set; }


    public int NumberOfRoute
    {
        get => _numberOfRoute;
        set
        {
            _numberOfRoute = value;
            OnPropertyChanged(nameof(NumberOfRoute));   
        }
    }

    public string DepartureAirport
    {
        get => _departureAirpoint;
        set
        {
            _departureAirpoint = value;
            OnPropertyChanged(nameof(DepartureAirport));
        }
    }

    public string DestinationAirport
    {
        get => _destinationAirport;
        set
        {
            _destinationAirport = value;
            OnPropertyChanged(nameof(DestinationAirport));
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    public int FlightDuration
    {
        get => _flightDuration;
        set
        {
            _flightDuration = value;
            OnPropertyChanged(nameof(FlightDuration));
        }
    }        

    public ObservableCollection<Route> Routes
    {
        get => _routes;
        set
        {
            _routes = value;
            OnPropertyChanged(nameof(Routes));
        }
    }    

    public Route SelectedRoute
    {
        get => _selectedRoute;
        set
        {
            _selectedRoute = value;
            OnPropertyChanged(nameof(SelectedRoute));
            if (_selectedRoute != null)
            {
                NumberOfRoute = _selectedRoute.NumberOfRoute;
                DepartureAirport = _selectedRoute.DepartureAirport;
                DestinationAirport = _selectedRoute.DestinationAirport;
                Price = _selectedRoute.Price;
                FlightDuration = _selectedRoute.FlightDuration;
            }
        }
    }

    private void CreateRoute(object obj)
    {
        if (!string.IsNullOrEmpty(_departureAirpoint) && !string.IsNullOrEmpty(_destinationAirport) && _flightDuration != default && _numberOfRoute != null && _price != default)
        {
            Route route = new() 
            { 
                DepartureAirport = _departureAirpoint,
                DestinationAirport = _destinationAirport,
                FlightDuration = _flightDuration,
                NumberOfRoute = _numberOfRoute,
                Price = _price
            };
            Controller<Route> controller = new();
            controller.Create(route);
            Routes.Add(route);
        }
    }    

    private void DeleteRoute(object obj)
    {
        if (_selectedRoute != null)
        {
            Controller<Route> controller = new();
            controller.Delete(_selectedRoute);
            Routes.Remove(_selectedRoute);
        }
    }

    private void UpdateRoute(object obj)
    {
        if (_selectedRoute != null)
        {
            Route updatedRoute = new Route()
            {
                NumberOfRoute = _selectedRoute.NumberOfRoute,
                DepartureAirport = _departureAirpoint,
                DestinationAirport = _destinationAirport,
                FlightDuration = _flightDuration,
                Price = _price
            };
            Controller<Route> controller = new();
            controller.Update(_selectedRoute.NumberOfRoute, updatedRoute);
            int index = Routes.IndexOf(_selectedRoute);
            Routes[index] = updatedRoute;
        }
    }
}
