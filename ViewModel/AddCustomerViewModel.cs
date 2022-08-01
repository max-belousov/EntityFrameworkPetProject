using System.Windows;
using EntityFraemworkPetProject.Command;
using EntityFraemworkPetProject.Model;
using EntityFraemworkPetProject.View;

namespace EntityFraemworkPetProject.ViewModel
{
    public class AddCustomerViewModel : BaseViewModel
    {
        private RelayCommand _okButtonCommand = null!;
        private RelayCommand _cancelButtonCommand = null!;
        public AddCustomerViewModel(AddCustomerView window)
        {
            Window = window;
        }
        public Customer Customer { get; set; } = null!;
        public bool Result { get; set; }
        public AddCustomerView Window { get; set; }
        public RelayCommand OkButtonCommand
        {
            get
            {
                return _okButtonCommand ??= new RelayCommand(obj =>
                {
                    if (Window.txtFirstName.Text != "" && Window.txtSecondName.Text != "" && Window.txtThirdName.Text != "" && Window.txtPhone.Text != "" && Window.txtEmail.Text != "")
                    {
                        var c = new Customer
                        {
                            FirstName = Window.txtFirstName.Text,
                            SecondName = Window.txtSecondName.Text,
                            ThirdName = Window.txtThirdName.Text,
                            Phone = Window.txtPhone.Text,
                            Email = Window.txtEmail.Text
                        };
                        Customer = c;
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
