using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.ViewModel;

namespace EntityFraemworkPetProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new MainWindowViewModel();
            DataContext = _mainWindowViewModel;
            //OrdersGridView
        }

        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.MenuItemAddClick();
        }

        private void MenuItemOrdersClick(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.MenuItemOrdersClick();
        }

        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.MenuItemDeleteClick();
        }


    }
}
