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
using System.Windows.Shapes;

namespace GadgeoMin
{
    /// <summary>
    /// Interaction logic for Gadget_bearbeiten.xaml
    /// </summary>
    public partial class Gadget_bearbeiten : Window
    {
        public Gadget_bearbeiten()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            String ServerUrl = "http://localhost:8080";
            var service = new LibraryAdminService(ServerUrl);

            // Create Gadget
            String value = this.tbPrice.Text;
            Double result = 0.0;
            try
            {
                result = Convert.ToDouble(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}' to a Double.", value);
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is outside the range of a Double.", value);
            }
            this.DialogResult = true;
            Gadget newGadget = new Gadget();
            newGadget.InventoryNumber = this.tbID.Text;
            newGadget.Name = this.tbName.Text;
            newGadget.Manufacturer = this.tbManufacturer.Text;
            newGadget.Price = result;
            newGadget.Condition = new ch.hsr.wpf.gadgeothek.domain.Condition();

            service.UpdateGadget(newGadget);
        }

    }
}
