using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.View;

namespace EntityFraemworkPetProject.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Customer _selectedCustomer;
        public MainWindowViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            Database = new MSSQLOnlineShopdbEntities();
            Database.Customer.Load();
            Customers = Database.Customer.Local;
        }

        public Customer SelectedCustomer
        {
            get => this._selectedCustomer;

            set
            {
                this._selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
                if (_selectedCustomer != null)
                {
                    var c = Database.Customer.Find(_selectedCustomer.Id);
                    c = value;
                    Database.SaveChanges();
                }
            }
        }

        public ObservableCollection<Customer> Customers { get; set; }

        public MSSQLOnlineShopdbEntities Database { get; set; }

        public void MenuItemAddClick()
        {
            var addCustomerView = new AddCustomerView();
            addCustomerView.ShowDialog();
            if (!addCustomerView.AddCustomerVM.Result) return;
            Database.AddCustomer(addCustomerView.AddCustomerVM.Customer);
        }
        public void MenuItemOrdersClick()
        {
            var orderView = new OrdersWindow(SelectedCustomer.Email);
            orderView.ShowDialog();
        }

        public void MenuItemDeleteClick()
        {
            if (SelectedCustomer != null) Database.DeleteCustomer(SelectedCustomer);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
