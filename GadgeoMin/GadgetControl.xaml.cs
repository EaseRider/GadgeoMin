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
        public GadgetControl()
        {
            InitializeComponent();
        }


    private void btnAddGadget_Click(object sender, RoutedEventArgs e)
    {
        Gadget_hinzufügen gadgetHinzufügen = new Gadget_hinzufügen();
        gadgetHinzufügen.Show();
    }

    private void btnEditGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget_bearbeiten gadgetBearbeiten = new Gadget_bearbeiten();
            gadgetBearbeiten.Show();
        }
    }
}
