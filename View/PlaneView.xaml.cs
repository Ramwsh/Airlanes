using Airlanes.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Airlanes.View
{    
    public partial class PlaneView : Window
    {
        public PlaneView()
        {
            InitializeComponent();
            DataContext = new PlaneViewModel(this);
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
