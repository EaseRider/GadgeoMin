using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
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
                mainWindow = (MainWindow)Window.GetWindow(this.Parent);
                // Update DataGrid
                mainWindow.RefreshDataGrid(); 
                
                              
            }
        }


        private void btnEditGadget_Click(object sender, RoutedEventArgs e)
        {
            
            if (dataGridView.SelectedItem != null)
            {
                Gadget_bearbeiten window = new Gadget_bearbeiten();
                window.Owner = (MainWindow)Window.GetWindow(this);
                // Übernehme Werte aus ausgewähltem Item
                Gadget gadget = (Gadget)dataGridView.SelectedItem;
                window.tbID.Text = gadget.InventoryNumber;
                window.tbManufacturer.Text = gadget.Manufacturer;
                window.tbName.Text = gadget.Name;
                window.tbPrice.Text = gadget.Price.ToString();
                window.cbCondition.SelectedItem = gadget.Condition;

                // Speichere änderungen
                if (window.ShowDialog() == true)
                {
                    Console.WriteLine(dataGridView.CurrentCell.Item.ToString());
                    MainWindow main = (MainWindow)Window.GetWindow(this);
                    // Update DataGrid
                    main.RefreshDataGrid();
                }
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
            mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.filterGadgets(filterInput.Text);
        }
    }
}
