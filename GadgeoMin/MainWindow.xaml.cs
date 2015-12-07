using ch.hsr.wpf.gadgeothek.domain;
using ch.hsr.wpf.gadgeothek.service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace GadgeoMin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

            DataContext = this;
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
            AllGadgets.ForEach(GadgetList.Add);

            AllLoans = service.GetAllLoans();
            LoanList.Clear();
            AllLoans.ForEach(LoanList.Add);
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
            } else
            {
                AllLoans.ForEach(LoanList.Add);
            }   
}
        
    }
}
