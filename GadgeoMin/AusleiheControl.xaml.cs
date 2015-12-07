using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
