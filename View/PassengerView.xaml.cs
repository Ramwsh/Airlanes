using Airlanes.ViewModel;
using System.Windows;

namespace Airlanes.View
{    
    public partial class PassengerView : Window
    {
        public PassengerView()
        {
            InitializeComponent();
            DataContext = new PassengerViewModel(this);
        }
    }
}
