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

            Console.WriteLine(this.ToString());
            DataContext = this;
            Ausleihe.DataContext = this;
            Gadget.DataContext = this;
            GadgetList = new ObservableCollection<Gadget>();
            LoanList = new ObservableCollection<Loan>();

            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            String ServerUrl = "http://localhost:8080";
            var service = new LibraryAdminService(ServerUrl);
            List<Gadget> gadgets = service.GetAllGadgets();
            GadgetList.Clear();
            gadgets.ForEach(GadgetList.Add);

            List<Loan> loans = service.GetAllLoans();
            LoanList.Clear();
            loans.ForEach(LoanList.Add);
           //GadgetList = new ObservableCollection<Gadget>(gadgets); 
            // LoanList = new ObservableCollection<Loan>(loans);
        }

    }


}
