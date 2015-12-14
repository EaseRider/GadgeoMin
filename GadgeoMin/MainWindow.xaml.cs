using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using ch.hsr.wpf.gadgeothek.windowControl;

namespace GadgeoMin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CustomWindow
    {
        public ObservableCollection<Gadget> GadgetList { get; set; }
        public ObservableCollection<Loan> LoanList { get; set; }
        public LibraryAdminService service;
        //
        private List<Gadget> AllGadgets = new List<Gadget>();
        private List<Loan> AllLoans = new List<Loan>();

        public MainWindow()
        {
            InitializeComponent();

            //DataContext = this;
            Ausleihe.DataContext = this;
            Gadget.DataContext = this;

            GadgetList = new ObservableCollection<Gadget>();
            LoanList = new ObservableCollection<Loan>();

            String ServerUrl = "http://localhost:8080";
            service = new LibraryAdminService(ServerUrl);

            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            AllGadgets = service.GetAllGadgets();
            GadgetList.Clear();
            if (AllGadgets != null) { 
            AllGadgets.ForEach(GadgetList.Add);

            AllLoans = service.GetAllLoans();
            LoanList.Clear();
            AllLoans.ForEach(LoanList.Add);
            } else
            {
                MessageBox.Show("Keine Verbindung zum Server gefunden!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
        }
        }

        public void filterLoans(String filter)
        {
            LoanList.Clear();
            if (filter.Length > 0)
            {
                filter = filter.ToUpper();
               AllLoans.Where(loan => {
                   return loan.Gadget.Name.ToUpper().Contains(filter)
                        || loan.Gadget.Manufacturer.ToUpper().Contains(filter)
                        || loan.Customer.Name.ToUpper().Contains(filter);
               }).ToList().ForEach(LoanList.Add);
            }
            else
            {
                AllLoans.ForEach(LoanList.Add);
            }   
}
        
        public void filterGadgets(String filter)
        {
            GadgetList.Clear();
            if (filter.Length > 0)
            {
                filter = filter.ToUpper();
                AllGadgets.Where(gadget => {
                    return gadget.Name.ToUpper().Contains(filter)
                         || gadget.Manufacturer.ToUpper().Contains(filter)
                         || gadget.Price.ToString().ToUpper().Contains(filter)
                         || gadget.InventoryNumber.ToUpper().Contains(filter)
                         || gadget.Condition.ToString().ToUpper().Contains(filter);
                }).ToList().ForEach(GadgetList.Add);
            }
            else
            {
                AllGadgets.ForEach(GadgetList.Add);
            }
        }

    }
}
