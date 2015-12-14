using System;
using System.Windows;
using System.Windows.Controls;

namespace GadgeoMin
{
    /// <summary>
    /// Interaction logic for GadgetControl.xaml
    /// </summary>
    public partial class GadgetControl : UserControl
    {
        private MainWindow mainWindow;

        public GadgetControl()
        {
            InitializeComponent();
        }


        public void btnAddGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget_hinzufügen window = new Gadget_hinzufügen();
            if (window.ShowDialog() == true)
            {
                mainWindow = (MainWindow)Window.GetWindow(this.Parent);
                // Update DataGrid
                mainWindow.RefreshDataGrid(); 
                
                              
            }
        }

        private void btnEditGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget_bearbeiten window = new Gadget_bearbeiten();
            window.Owner = (MainWindow)Window.GetWindow(this);
            
            if (window.ShowDialog() == true)
            {
                Console.WriteLine(dataGridView.CurrentCell.Item.ToString());
                MainWindow main = (MainWindow)Window.GetWindow(this);
                // Update DataGrid
                main.RefreshDataGrid();
            }
        }

        private void filterInput_TextChanged(object sender, TextChangedEventArgs e)
        { 
            mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.filterGadgets(filterInput.Text);
        }
    }
}
