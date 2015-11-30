﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ch.hsr.wpf.gadgeothek.domain.Gadget> gadgetList = new ObservableCollection<ch.hsr.wpf.gadgeothek.domain.Gadget>();
        public ObservableCollection<ch.hsr.wpf.gadgeothek.domain.Gadget> GadgetList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            

            DataContext = this;

        }
    }
}
