using System.Windows;
using EntityFraemworkPetProject.ViewModel;

namespace EntityFraemworkPetProject.View
{
    /// <summary>
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow(string? key)
        {
            InitializeComponent();
            DataContext = new OrdersWindowViewModel(key);
        }
    }
}
