using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
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
    /// Interaction logic for GadgetControl.xaml
    /// </summary>
    public partial class GadgetControl : UserControl
    {
        LibraryAdminService service;
        public GadgetControl()
        {
            InitializeComponent();

            String ServerUrl = "http://localhost:8080";
            service = new LibraryAdminService(ServerUrl);
        }


        public void btnAddGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget_hinzufügen window = new Gadget_hinzufügen();
            if (window.ShowDialog() == true)
            {
                MainWindow main = (MainWindow)Window.GetWindow(this.Parent);
                main.RefreshDataGrid();               
            }
        }


        private void btnEditGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget_bearbeiten window = new Gadget_bearbeiten();
            window.Owner = (MainWindow)Window.GetWindow(this);
            // Übernehme Werte aus ausgewähltem Item
            if (dataGridView.SelectedItem != null)
            {
                Gadget gadget = (Gadget)dataGridView.SelectedItem;
                window.tbID.Text = gadget.InventoryNumber;
                window.tbManufacturer.Text = gadget.Manufacturer;
                window.tbName.Text = gadget.Name;
                window.tbPrice.Text = gadget.Price.ToString();
                window.cbCondition.SelectedItem = gadget.Condition;
            }
            // Speichere änderungen
            if (window.ShowDialog() == true)
            {
                Console.WriteLine(dataGridView.CurrentCell.Item.ToString());
                MainWindow main = (MainWindow)Window.GetWindow(this);
                // Update DataGrid
                main.RefreshDataGrid();
            }
        }

        private void btnDeleteGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget gadget = (Gadget)dataGridView.SelectedItem;
            service.DeleteGadget(gadget);
            MainWindow main = (MainWindow)Window.GetWindow(this);
            // Update DataGrid
            main.RefreshDataGrid();
        }

        private void filterInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.filterGadgets(filterInput.Text);
        }
    }
}
