using System;
using System.Data.Entity;
using System.Windows;
using EntityFraemworkPetProject.Model;

namespace EntityFraemworkPetProject
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal MSSQLOnlineShopdbEntities DbContext { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContext = new MSSQLOnlineShopdbEntities();
            try
            {
                DbContext.Customer.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить базу данных. Ошибка: {ex.Message}",
                    "Ошибка загрузки базы данных", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            DbContext.Dispose();
        }
    }
}
