using Airlanes.ViewModel;
using System.Windows;

namespace Airlanes.View
{    
    public partial class CapitanView : Window
    {
        public CapitanView()
        {
            InitializeComponent();
            DataContext = new CapitanViewModel();
        }
    }
}
