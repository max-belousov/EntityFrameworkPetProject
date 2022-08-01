using System.Windows;
using EntityFraemworkPetProject.ViewModel;

namespace EntityFraemworkPetProject.View
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerView.xaml
    /// </summary>
    public partial class AddCustomerView : Window
    {
        public AddCustomerView()
        {
            InitializeComponent();
            AddCustomerVM = new AddCustomerViewModel(this);
            DataContext = AddCustomerVM;
        }
        public AddCustomerViewModel AddCustomerVM { get; set; }
    }
}
