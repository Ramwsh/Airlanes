using Airlanes.ViewModel;
using System.Windows;

namespace Airlanes.View
{    
    public partial class FlightView : Window
    {
        public FlightView()
        {
            InitializeComponent();
            DataContext = new FlightViewModel(this);
        }
    }
}
