using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EntityFraemworkPetProject.Command;
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.View;

namespace EntityFraemworkPetProject.ViewModel
{
    public class AddOrdersViewModel : BaseViewModel
    {
        private RelayCommand _okButtonCommand;
        private RelayCommand _cancelButtonCommand;
        public AddOrdersViewModel(string key, AddOrderView window)
        {
            Key = key;
            Window = window;
            Database = new MSSQLOnlineShopdbEntities();
        }
        public MSSQLOnlineShopdbEntities Database { get; set; }
        public string Key { get; set; }

        public AddOrderView Window { get; set; }
        public Orders Orders  { get; set; }
        public bool Result { get; set; }
        public RelayCommand OkButtonCommand
        {
            get
            {
                return _okButtonCommand ??= new RelayCommand(obj =>
                {
                    if (Window.txtItemName.Text != "" && Window.txtItemCode.Text != "")
                    {
                        var o = new Orders
                        {
                            ItemName = Window.txtItemName.Text,
                            ItemCode = Window.txtItemCode.Text,
                            Email = Key
                        };
                        Orders = o;
                        Result = true;
                        Window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполнены");
                    }
                });
            }
        }
        public RelayCommand CancelButtonCommand
        {
            get
            {
                return _cancelButtonCommand ??= new RelayCommand(obj =>
                {
                    Result = false;
                    Window.Close();
                });
            }
        }
    }
}
