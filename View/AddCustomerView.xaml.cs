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
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.ViewModel;

namespace EntityFraemworkPetProject.View
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Window
    {
        public AddCustomerView()
        {
            InitializeComponent();
            AddCustomerVM = new AddCustomerViewModel();
            DataContext = AddCustomerVM;
        }

        
        public AddCustomerViewModel AddCustomerVM { get; set; }
        private void okButton(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text != "" && txtSecondName.Text != "" && txtThirdName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
            {
                var c = new Customer
                {
                    FirstName = txtFirstName.Text,
                    SecondName = txtSecondName.Text,
                    ThirdName = txtThirdName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text
                };
                AddCustomerVM.Customer = c;
                AddCustomerVM.Result = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void cancelButton(object sender, RoutedEventArgs e)
        {
            AddCustomerVM.Result = false;
            this.Close();
        }
    }
}
