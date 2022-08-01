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
    /// Логика взаимодействия для AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : Window
    {
        //private string _key;
        public AddOrderView(string key)
        {
            InitializeComponent();
            AddOrderVM = new AddOrdersViewModel(key, this);
            DataContext = AddOrderVM;
            //DataContext = new AddOrdersViewModel(key, this);
            //_key = key;
        }


        public AddOrdersViewModel AddOrderVM { get; set; }
        //private void okButton(object sender, RoutedEventArgs e)
        //{
        //    if (txtItemName.Text != "" && txtItemCode.Text != "")
        //    {
        //        var o = new Orders
        //        {
        //            ItemName = txtItemName.Text,
        //            ItemCode = txtItemCode.Text,
        //            Email = _key
        //        };
        //        AddOrderVM.Orders = o;
        //        AddOrderVM.Result = true;
        //        this.Close();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Не все поля заполнены");
        //    }
        //}

        //private void cancelButton(object sender, RoutedEventArgs e)
        //{
        //    AddOrderVM.Result = false;
        //    this.Close();
        //}
    }
}
