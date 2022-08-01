using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using EntityFraemworkPetProject.Command;
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.View;

namespace EntityFraemworkPetProject.ViewModel
{
    internal class OrdersWindowViewModel : BaseViewModel
    {
        private Orders _selectedOrders = null!;
        private static string? _key;
        private RelayCommand _addCommand = null!;
        private RelayCommand _deleteCommand = null!;

        public OrdersWindowViewModel(string? key)
        {
            Orders = new ObservableCollection<Orders>();
            Database = new MSSQLOnlineShopdbEntities();
            _key = key;
            DatabaseLoading();
        }
        public Orders SelectedOrders
        {
            get => this._selectedOrders;

            set
            {
                this._selectedOrders = value;
                OnPropertyChanged();
                if (_selectedOrders != null)
                {
                    Database?.Orders.Find(_selectedOrders.Id);
                    Database?.SaveChanges();
                }
            }
        }

        public ObservableCollection<Orders> Orders { get; set; }

        public static MSSQLOnlineShopdbEntities? Database { get; set; }
        private void DatabaseLoading()
        {
            Database.Orders.Where(o => o.Email == _key).Load();
            Orders = Database.Orders.Local;
        }

        public RelayCommand OrderAdd
        {
            get
            {
                return _addCommand ??= new RelayCommand(obj =>
                {
                    var addOrderView = new AddOrderView(_key);
                    addOrderView.ShowDialog();
                    if (!addOrderView.AddOrderVM.Result) return;
                    Database.AddOrder(addOrderView.AddOrderVM.Orders);
                });
            }
        }
        public RelayCommand OrderDelete
        {
            get
            {
                return _deleteCommand ??= new RelayCommand(obj =>
                {
                    if (SelectedOrders != null) Database?.DeleteOrder(SelectedOrders);
                });
            }
        }
    }
}
