﻿using System;
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


        public void btnAddGadget_Click(object sender, RoutedEventArgs e)
        {
            Gadget_hinzufügen window = new Gadget_hinzufügen();
            if (window.ShowDialog() == true)
            {
                MainWindow main = (MainWindow)Window.GetWindow(this.Parent);
                // Update DataGrid
                main.RefreshDataGrid(); 
                
                              
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

        
    }
}
