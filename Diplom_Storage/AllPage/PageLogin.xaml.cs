using Diplom_Storage.AppData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Diplom_Storage;
using Diplom_Storage.WindowForRole;
using Newtonsoft.Json;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageStart());
        }
        public class UserSettings
        {
            public int IdUser { get; set; }
        }
        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new DiplomNikiforovEntities())

                {
                    var userObj = AppConnect.modelOdb.users.FirstOrDefault(x => x.login == txbLogin.Text && x.password == psbPass.Password);
                    if (userObj == null)
                    {
                        MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        var userSettings = new UserSettings { IdUser = userObj.ID_USERS};
                        string json = JsonConvert.SerializeObject(userSettings);
                        File.WriteAllText("userSettings.json", json);
                        switch (userObj.role_id)
                        {

                            case 1:
                                MessageBox.Show("Здравствуйте, Заведующий склада " + userObj.login + "!",
                                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                Role1 First = new Role1(userObj.login, userObj.password, userObj.role_id);
                                First.Show();
                                break;
                            case 2:
                                MessageBox.Show("Здравствуйте, ревизор " + userObj.login + "!",
                                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                Role1 First2 = new Role1(userObj.login, userObj.password, userObj.role_id);
                                First2.Show();
                                break;
                            case 3:
                                MessageBox.Show("Здравствуйте, Администратор " + userObj.login + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                Role1 First3 = new Role1(userObj.login, userObj.password, userObj.role_id);
                                First3.Show();;
                                break;
                            default:
                                MessageBox.Show("Ошибка при авторизации: неизвестная роль пользователя!",
                                "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
                        }
                        Application.Current.MainWindow.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при авторизации: " + ex.Message, "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}