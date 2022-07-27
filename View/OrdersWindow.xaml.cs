﻿using System;
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
using System.Windows.Shapes;
using EntityFraemworkPetProject.ViewModel;

namespace EntityFraemworkPetProject.View
{
    /// <summary>
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private readonly OrdersWindowViewModel _viewModel;
        public OrdersWindow(string key)
        {
            InitializeComponent();
            _viewModel = new OrdersWindowViewModel(key);
            OrdersGridView.DataContext = _viewModel;
            //var e = OrdersGridView.ItemsSource;
            //var c = _viewModel.Orders.ToBindingList();
            //OrdersGridView.ItemsSource = _viewModel.Orders.ToBindingList();
            //OrdersGridView.SelectedItem = _viewModel.SelectedOrders;
        }


        private void OrderDeleteClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OrderDeleteClick();
        }

        private void OrderAddClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OrderAddClick();
        }
    }
}