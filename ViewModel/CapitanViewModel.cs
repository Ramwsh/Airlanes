using Airlanes.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Airlanes.ViewModel
{
    class CapitanViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Capitan> _capitans;
        public ObservableCollection<Capitan> Capitans
        {
            get 
            { 
                return _capitans;
            }
            set
            {
                _capitans = value;
                OnPropertyChanged(nameof(_capitans));
            }
        }
        private string? _FIOc;
        public string CapitanName
        {
            get
            {
                return _FIOc;
            }
            set
            {
                _FIOc = value;
                OnPropertyChanged(_FIOc);
            }
        }
        private string? telephone;
        public string Phone
        {
            get
            {
                return telephone;
            }
            set
            {
                telephone = value;
                OnPropertyChanged(telephone);
            }
        }
        private string? address;
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged(address);
            }
        }
        private int raid;
        public int Raid
        {
            get
            {
                return raid;
            }
            set
            {
                raid = value;
            }
        }
        private string? _PersonalNumber;
        public string? PersonalNum
        {
            get
            {
                return _PersonalNumber;
            }
            set
            {
                _PersonalNumber = value;
                OnPropertyChanged(nameof(_PersonalNumber));
            }
        }
        public CapitanViewModel()
        {
            CreateCommand = new Commands(CreateCapitan);
            _capitans=new ObservableCollection<Capitan>(new Controller<Capitan>().Read());
            DeleteCommand = new Commands(DeleteCapitan);
            UpdateCommand = new Commands(UpdateCapitan);
        }
        private Capitan selectedCapitanItem;
        public Capitan SelectedCapitanItem
        {
            get
            {
                return selectedCapitanItem;
            }
            set
            {
                selectedCapitanItem = value;
                OnPropertyChanged(nameof(selectedCapitanItem));
                if(selectedCapitanItem != null)
                {
                    CapitanName = selectedCapitanItem.FIOc;
                    PersonalNum = selectedCapitanItem.PersonalNumber.ToString();
                    Raid = selectedCapitanItem.Raid;
                    Address = selectedCapitanItem.Address;
                    Phone = selectedCapitanItem.Telephone;
                    OnPropertyChanged(nameof(CapitanName));
                    OnPropertyChanged(nameof(PersonalNum));
                    OnPropertyChanged(nameof(Raid));
                    OnPropertyChanged(nameof(Address));
                    OnPropertyChanged(nameof(Phone));
                    Console.WriteLine(selectedCapitanItem.Raid);
                    Console.WriteLine(selectedCapitanItem.PersonalNumber);
                    Console.WriteLine(selectedCapitanItem.Telephone);
                    Console.WriteLine(selectedCapitanItem.Address);
                    Console.WriteLine(selectedCapitanItem.FIOc);
                }
                
            }
        }
        public ICommand CreateCommand
        {
            get; private set;
        }
        public ICommand DeleteCommand
        {
            get; private set;
        }
        public ICommand UpdateCommand
        {
            get; private set;
        }
        private void CreateCapitan(object param)
        {
            if (!string.IsNullOrEmpty(_PersonalNumber) && !string.IsNullOrEmpty(_FIOc) && !string.IsNullOrEmpty(telephone) && !string.IsNullOrEmpty(address) && raid != default)
            {
                Capitan capitanToAdd = new Capitan()
                {
                    PersonalNumber = Convert.ToInt32(_PersonalNumber),
                    FIOc = _FIOc,
                    Address = address,
                    Telephone = telephone,
                    Raid = raid
                };
                Console.WriteLine($"Личный номер: {capitanToAdd.PersonalNumber}");
                Console.WriteLine($"Имя: {capitanToAdd.FIOc}");
                Console.WriteLine($"Адрес: {capitanToAdd.Address}");
                Console.WriteLine($"Телефон: {capitanToAdd.Telephone}");
                Console.WriteLine($"Налёт: {capitanToAdd.Raid}");
                Controller<Capitan> controller = new Controller<Capitan>();
                controller.Create(capitanToAdd);
                Capitans.Add(capitanToAdd);
            }
        }
        private void DeleteCapitan(object param)
        {
            if(selectedCapitanItem != null)
            {
                Controller<Capitan> controller = new Controller<Capitan>();
                controller.Delete(selectedCapitanItem);
                Capitans.Remove(selectedCapitanItem);
            }
        }

        private void UpdateCapitan(object param)
        {
            if (selectedCapitanItem != null)
            {
                Capitan updatedcapitan = new Capitan()
                {
                    PersonalNumber = selectedCapitanItem.PersonalNumber,
                    FIOc = _FIOc,
                    Address = address,
                    Telephone = telephone,
                    Raid = raid
                };
                Controller<Capitan> controller = new Controller<Capitan>();
                controller.Update(selectedCapitanItem.PersonalNumber,updatedcapitan);
                Capitans.Remove(selectedCapitanItem);
                Capitans.Add(updatedcapitan);
            }
        }
    }
}
