using Diplom_Storage.AppData;
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
using static Diplom_Storage.AllPage.PageLogin;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Window
    {
        private users user;
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public EditUserPage(int selectedId)
        {
            InitializeComponent();
            int idUser = selectedId;
            user = context.users.FirstOrDefault(x => x.ID_USERS == idUser);
            Logntxb.Text = user.login;
            PassUser.Text = user.password;
            var roles = context.roles.ToList();
            RoleComboBox.ItemsSource = roles;
            RoleComboBox.DisplayMemberPath = "name";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Logntxb.Text;
            string password = PassUser.Text;
            var role = RoleComboBox.SelectedItem as roles;
            // Проверка, что логин и пароль не совпадают с теми, что уже есть в базе
            if (context.users.Any(u => u.login == login && u.ID_USERS != user.ID_USERS) ||
                context.users.Any(u => u.password == password && u.ID_USERS != user.ID_USERS))
            {
                MessageBox.Show("Логин или пароль уже существуют в базе данных!");
                return;
            }
            if (role == null)
            {
                MessageBox.Show("Выберите роль пользователя!");
                return;
            }
            user.login = login;
            user.password = password;
            user.roles = role;
            context.SaveChanges();

            MessageBox.Show("Изменения сохранены!");
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
