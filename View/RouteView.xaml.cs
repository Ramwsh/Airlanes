using Airlanes.ViewModel;
using System.Windows;

namespace Airlanes.View
{    
    public partial class RouteView : Window
    {
        public RouteView()
        {
            InitializeComponent();
            DataContext = new RouteViewModel(this);
        }
    }
}
