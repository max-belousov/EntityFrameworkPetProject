using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.View;

namespace EntityFraemworkPetProject.ViewModel
{
    internal class OrdersWindowViewModel : INotifyPropertyChanged
    {
        private Orders _selectedOrders;
        private readonly string _key;
        public OrdersWindowViewModel(string key)
        {
            Orders = new ObservableCollection<Orders>();
            Database = new MSSQLOnlineShopdbEntities();
            _key = key;
            Database.Orders.Where(o => o.Email == _key).Load();
            Orders = Database.Orders.Local;
        }
        public Orders SelectedOrders
        {
            get => this._selectedOrders;

            set
            {
                this._selectedOrders = value;
                OnPropertyChanged("SelectedOrders");
                if (_selectedOrders != null)
                {
                    var c = Database.Orders.Find(_selectedOrders.Id);
                    c = value;
                    Database.SaveChanges();
                }
            }
        }

        public ObservableCollection<Orders> Orders { get; set; }

        public MSSQLOnlineShopdbEntities Database { get; set; }

        public void OrderAddClick()
        {
            var addOrderView = new AddOrderView(_key);
            addOrderView.ShowDialog();
            if (!addOrderView.AddOrderVM.Result) return;
            Database.AddOrder(addOrderView.AddOrderVM.Orders);
        }

        public void OrderDeleteClick()
        {
            if (SelectedOrders != null) Database.DeleteOrder(SelectedOrders);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
