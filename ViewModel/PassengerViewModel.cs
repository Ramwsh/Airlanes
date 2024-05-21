using Airlanes.Model.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airlanes.ViewModel
{
    internal class PassengerViewModel : INotifyPropertyChanged
    {
        private Window _currentWindow;

        private int _numberOfPasrport;

        public int NumberOfPasport
        {
            get => _numberOfPasrport;
            set
            {
                _numberOfPasrport = value;
                OnPropertyChanged(nameof(NumberOfPasport));
            }
        }

        private string _fiop;

        public string Fiop
        {
            get => _fiop;
            set
            {
                _fiop = value;
                OnPropertyChanged(nameof(Fiop));
            }
        }        

        private string _address;

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _phone;

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private ObservableCollection<Passanger> _passengers;

        public ObservableCollection<Passanger> Passengers
        {
            get => _passengers;
            set
            {
                _passengers = value;
                OnPropertyChanged(nameof(Passengers));
            }
        }

        private Passanger _selectedPassenger;

        public Passanger SelectedPassenger
        {
            get => _selectedPassenger;
            set
            {
                _selectedPassenger = value;
                OnPropertyChanged(nameof(SelectedPassenger));                                
                if (_selectedPassenger != null)
                {                    
                    NumberOfPasport = _selectedPassenger.NumberOfPassport;
                    Fiop = _selectedPassenger.FIOp;
                    Address = _selectedPassenger.Address;
                    Phone = _selectedPassenger.Phone;                    
                }
            }
        }

        public PassengerViewModel(Window window)
        {
            _currentWindow = window;
            Passengers = new ObservableCollection<Passanger>(new Controller<Passanger>().Read());            
            CreatePassengerCommand = new Commands(CreatePassenger);
            UpdatePassengerCommand = new Commands(UpdatePassenger);
            DeletePassengerCommand = new Commands(DeletePassenger);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ICommand CreatePassengerCommand { get; private set; }

        public ICommand DeletePassengerCommand { get; private set; }

        public ICommand UpdatePassengerCommand { get; private set; }

        private void CreatePassenger(object obj)
        {
            if (_numberOfPasrport != default && _fiop != null && _phone != null && _address != null)
            {
                Passanger passenger = new() { NumberOfPassport = _numberOfPasrport, FIOp = _fiop, Address = _address, Phone = _phone };
                Controller<Passanger> controller = new Controller<Passanger>();
                controller.Create(passenger);
                Passengers.Add(passenger);
            }
        }

        private void DeletePassenger(object obj)
        {
            if (_selectedPassenger != null)
            {
                Controller<Passanger> controller = new();
                controller.Delete(_selectedPassenger);                
                Passengers.Remove(_selectedPassenger);
            }
        }

        private void UpdatePassenger(object obj)
        {
            if (_selectedPassenger != null)
            {
                Passanger updatedPassanger = new Passanger() { NumberOfPassport = _selectedPassenger.NumberOfPassport, FIOp = _fiop, Address = _address, Phone = _phone };
                Controller<Passanger> controller = new();
                controller.Update(updatedPassanger.NumberOfPassport, updatedPassanger);
                int index = _passengers.IndexOf(_selectedPassenger);
                Passengers[index] = updatedPassanger;
            }
        }
    }
}
