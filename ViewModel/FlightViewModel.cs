using Airlanes.Model.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airlanes.ViewModel;

internal class FlightViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private int _numberOfFlight;
    private DateTime _dateOfDeparture;
    private bool _readyOrNot;
    private int _routeNumber;
    private int _boardNumber;
    private ObservableCollection<Flight> _flights;
    private Flight _selectedFlight;
    private Window _currentWindow;

    public int NumberOfFlight
    {
        get => _numberOfFlight;
        set
        {
            _numberOfFlight = value;
            OnPropertyChanged(nameof(NumberOfFlight));
        }
    }

    public DateTime DateOfDeparture
    {
        get => _dateOfDeparture;
        set
        {
            _dateOfDeparture = value;
            OnPropertyChanged(nameof(DateOfDeparture));
        }
    }

    public bool ReadyOrNot
    {
        get => _readyOrNot;
        set
        {
            _readyOrNot = value;
            OnPropertyChanged(nameof(ReadyOrNot));
        }
    }

    public int RouteNumber
    {
        get => _routeNumber;
        set
        {
            _routeNumber = value;
            OnPropertyChanged(nameof(RouteNumber));
        }
    }

    public int BoardNumber
    {
        get => _boardNumber;
        set
        {
            _boardNumber = value;
            OnPropertyChanged(nameof(BoardNumber));
        }
    }

    public ObservableCollection<Flight> Flights
    {
        get => _flights;
        set
        {
            _flights = value;
            OnPropertyChanged(nameof(Flights));
        }
    }

    public Flight SelectedFlight
    {
        get => _selectedFlight;
        set
        {
            _selectedFlight = value;
            OnPropertyChanged(nameof(SelectedFlight));
            if (_selectedFlight != null)
            {
                NumberOfFlight = _selectedFlight.NumberOfFlight;
                DateOfDeparture = _selectedFlight.DateOfDeparture;
                ReadyOrNot = _selectedFlight.ReadyOrNot;
                RouteNumber = _selectedFlight.RouteNumber;
                BoardNumber = _selectedFlight.BoardNumber;
            }
        }
    }

    public ICommand CreateFlightCommand { get; private set; }

    public ICommand DeleteFlightCommand { get; private set; }

    public ICommand UpdateFlightCommand { get; private set; }


    public FlightViewModel(Window window)
    {
        _currentWindow = window;
        Controller<Flight> controller = new Controller<Flight>();
        Flights = new ObservableCollection<Flight>(controller.Read());
        CreateFlightCommand = new Commands(CreateFlight);
        DeleteFlightCommand = new Commands(DeleteFlight);
        UpdateFlightCommand = new Commands(UpdateFlight);
    }

    private void CreateFlight(object obj)
    {
        if (_dateOfDeparture != default && _boardNumber != default && _numberOfFlight != default && _routeNumber != default)
        {
            Flight flight = new() { BoardNumber = _boardNumber, DateOfDeparture = _dateOfDeparture, NumberOfFlight = _numberOfFlight, ReadyOrNot = _readyOrNot, RouteNumber = _routeNumber };
            Controller<Flight> controller = new Controller<Flight>();
            controller.Create(flight);
            Flights.Add(flight);
        }
    }

    private void DeleteFlight(object obj)
    {
        if (_selectedFlight != null)
        {
            Controller<Flight> controller = new();
            controller.Delete(_selectedFlight);
            Flights.Remove(_selectedFlight);
        }
    }

    private void UpdateFlight(object obj)
    {
        if (_selectedFlight != null)
        {
            Flight updatedFlight = new() { BoardNumber = _selectedFlight.BoardNumber, DateOfDeparture = _dateOfDeparture, NumberOfFlight = _numberOfFlight, RouteNumber = _routeNumber, ReadyOrNot = _readyOrNot };
            Controller<Flight> controller = new Controller<Flight>();
            controller.Update(updatedFlight.BoardNumber, updatedFlight);
            int index = Flights.IndexOf(_selectedFlight);
            Flights[index] = updatedFlight;
        }
    }

    public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
