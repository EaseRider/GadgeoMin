using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
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
        public ObservableCollection<Gadget> GadgetList { get; set; }
        public ObservableCollection<Loan> LoanList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
                
            DataContext = this;
            Ausleihe.DataContext = this;
            Gadget.DataContext = this;

            reloadLists();
        }

        public void reloadLists()
        {
            String ServerUrl = "http://localhost:8080";
            var service = new LibraryAdminService(ServerUrl);
            List<Gadget> gadgets = service.GetAllGadgets();
            List<Loan> loans = service.GetAllLoans();
            GadgetList = new ObservableCollection<Gadget>(gadgets);
            LoanList = new ObservableCollection<Loan>(loans);
        }

    }


}
