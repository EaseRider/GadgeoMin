using System.Windows;
using System.Windows.Controls;

namespace GadgeoMin
{
    /// <summary>
    /// Interaction logic for AusleiheControl.xaml
    /// </summary>
    public partial class AusleiheControl : UserControl
    {
        private MainWindow mainWindow;
        
        public AusleiheControl()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void filterInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.filterLoans(filterInput.Text);
        }
    }
}
