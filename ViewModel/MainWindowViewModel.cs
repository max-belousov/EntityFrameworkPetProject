using System.Collections.ObjectModel;
using System.Data.Entity;
using EntityFraemworkPetProject.Command;
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.View;

namespace EntityFraemworkPetProject.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private Customer _selectedCustomer = null!;
        private RelayCommand _menuItemAdd = null!;
        private RelayCommand _menuItemOrders = null!;
        private RelayCommand _menuItemDelete = null!;
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
                OnPropertyChanged();
                if (_selectedCustomer != null)
                {
                    Database.Customer.Find(_selectedCustomer.Id);
                    Database.SaveChanges();
                }
            }
        }

        public ObservableCollection<Customer> Customers { get; set; }

        public MSSQLOnlineShopdbEntities Database { get; set; }
        
        public RelayCommand MenuItemAdd
        {
            get
            {
                return _menuItemAdd ??= new RelayCommand(obj =>
                {
                    var addCustomerView = new AddCustomerView();
                    addCustomerView.ShowDialog();
                    if (!addCustomerView.AddCustomerVM.Result) return;
                    Database.AddCustomer(addCustomerView.AddCustomerVM.Customer);
                });
            }
        }
        public RelayCommand MenuItemOrders
        {
            get
            {
                return _menuItemOrders ??= new RelayCommand(obj =>
                {
                    var orderView = new OrdersWindow(SelectedCustomer.Email);
                    orderView.ShowDialog();
                });
            }
        }
        public RelayCommand MenuItemDelete
        {
            get
            {
                return _menuItemDelete ??= new RelayCommand(obj =>
                {
                    if (SelectedCustomer != null) Database.DeleteCustomer(SelectedCustomer);
                });
            }
        }

    }
}
