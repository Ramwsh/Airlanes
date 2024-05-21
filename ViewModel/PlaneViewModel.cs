using Airlanes.Model.Entities;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airlanes.ViewModel
{
    internal class PlaneViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(propertyName, new PropertyChangedEventArgs(propertyName));

        private Window _currentWindow;

        private int _boardNumber;

        private string _model;

        private DateTime _serviceLife;

        private bool _readyOrNot;

        private ObservableCollection<Plane> _planes;

        private Plane _selectedPlane;

        public int BoardNumber
        {
            get => _boardNumber;
            set
            {
                _boardNumber = value;
                OnPropertyChanged(nameof(_boardNumber));
            }
        }

        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(nameof(_model));
            }
        }

        public DateTime ServiceLife
        {
            get => _serviceLife;
            set
            {
                _serviceLife = value;
                OnPropertyChanged(nameof(_serviceLife));
            }
        }

        public bool ReadyOrNot
        {
            get => _readyOrNot;
            set
            {
                _readyOrNot = value;
                OnPropertyChanged(nameof(_readyOrNot));
            }
        }

        public ObservableCollection<Plane> Planes
        {
            get => _planes;
            set
            {
                _planes = value;
                OnPropertyChanged(nameof(_planes));
            }
        }

        public Plane SelectedPlane
        {
            get => _selectedPlane;
            set
            {
                _selectedPlane = value;
                OnPropertyChanged(nameof(_selectedPlane));
                if (_selectedPlane != null)
                {                    
                    BoardNumber = _selectedPlane.BoardNumber;
                    Model = _selectedPlane.Model;
                    ServiceLife = _selectedPlane.ServiceLife;
                    ReadyOrNot = _selectedPlane.ReadyOrNot;
                    OnPropertyChanged(nameof(BoardNumber));
                    OnPropertyChanged(nameof(Model));
                    OnPropertyChanged(nameof(ServiceLife));
                    OnPropertyChanged(nameof(ReadyOrNot));
                    OnPropertyChanged(nameof(_boardNumber));
                    OnPropertyChanged(nameof(_model));
                    OnPropertyChanged(nameof(_serviceLife));
                    OnPropertyChanged(nameof(_readyOrNot));
                }
            }
        }

        public ICommand CreatePlaneCommand { get; private set; }
        public ICommand DeletePlaneCommand { get; private set; }
        public ICommand UpdatePlaneCommand { get; private set; }

        public PlaneViewModel(Window window)
        {
            _currentWindow = window;
            Controller<Plane> controller = new Controller<Plane>();
            Planes = new ObservableCollection<Plane>(controller.Read());
            CreatePlaneCommand = new Commands(CreatePlane);
            DeletePlaneCommand = new Commands(DeletePlane);
            UpdatePlaneCommand = new Commands(UpdatePlane);
            Console.WriteLine(Planes.Count());
            Console.WriteLine(_planes.Count());
        }

        private void CreatePlane(object obj)
        {
            if (_boardNumber != default && !string.IsNullOrEmpty(_model) && _serviceLife != default)
            {
                Plane newPlane = new() { BoardNumber = _boardNumber, Model = _model, ServiceLife = _serviceLife, ReadyOrNot = _readyOrNot };
                Controller<Plane> controller = new Controller<Plane>();
                controller.Create(newPlane);
                Planes.Add(newPlane);
            }
        }

        private void DeletePlane(object obj)
        {
            if (_selectedPlane != null)
            {
                Controller<Plane> controller = new Controller<Plane>();
                controller.Delete(_selectedPlane);
                Planes.Remove(_selectedPlane);
            }
        }

        private void UpdatePlane(object obj)
        {
            if (_selectedPlane != null)
            {
                Plane updatedPlane = new() { BoardNumber = _selectedPlane.BoardNumber, Model = _model, ServiceLife = _serviceLife, ReadyOrNot = _readyOrNot };
                Controller<Plane> controller = new();
                controller.Update(updatedPlane.BoardNumber, updatedPlane);
                int index = Planes.IndexOf(_selectedPlane);
                Planes[index] = updatedPlane;
            }
        }
    }
}
