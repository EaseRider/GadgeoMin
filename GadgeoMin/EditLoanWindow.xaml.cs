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
    /// Interaction logic for editLoanWindow.xaml
    /// </summary>
    public partial class editLoanWindow : Window
    {
        public editLoanWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            String ServerUrl = "http://localhost:8080";
            var service = new LibraryAdminService(ServerUrl);

            Customer customer = service.GetCustomer(tbStudentID.Text);
            DateTime time = DateTime.Now;
            String gadgetID = tbGadgetID.Text;
            
            
            
            Loan loan = new Loan(
                tbLoanID.Text, 
                service.GetGadget(gadgetID), 
                service.GetCustomer(tbStudentID.Text), 
                time, 
                time.AddDays(30)
                );

            service.AddLoan(loan);

            this.DialogResult = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
