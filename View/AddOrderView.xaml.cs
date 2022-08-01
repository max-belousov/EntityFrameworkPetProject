using System.Windows;
using EntityFraemworkPetProject.ViewModel;

namespace EntityFraemworkPetProject.View
{
    /// <summary>
    /// Логика взаимодействия для AddOrderView.xaml
    /// </summary>
    public partial class AddOrderView : Window
    {
        public AddOrderView(string? key)
        {
            InitializeComponent();
            AddOrderVM = new AddOrdersViewModel(key, this);
            DataContext = AddOrderVM;
        }
        public AddOrdersViewModel AddOrderVM { get; set; }
    }
}
