using Diplom_Storage.AppData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using System.Xml.Linq;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для AddToUser.xaml
    /// </summary>
    public partial class AddToUser : Window
    {
        public delegate void UserAddedEventHandler(object sender, EventArgs e);
        public event UserAddedEventHandler UserAdded;
        public AddToUser()
        {
            InitializeComponent();
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            RoleComboBox.ItemsSource = DiplomNikiforovEntities.GetContext().roles.ToList();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveUserButton_Click(object sender, RoutedEventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            users newUser = new users();
            newUser.login = LoginTextBox.Text;
            newUser.password = PasswordTextBox.Text;
            string roleName = ((roles)RoleComboBox.SelectedItem).name;
            if (context.users.Any(u => u.login == newUser.login))
            {
                MessageBox.Show("Пользователь с таким логином уже существует!");
                return;
            }
            int roleId = context.roles.FirstOrDefault(r => r.name == roleName)?.ID_ROLE ?? 0;
            newUser.role_id = roleId;
            context.users.Add(newUser);
            context.SaveChanges();

            user_form newUserForm = new user_form();
            newUserForm.User_ID = newUser.ID_USERS;
            context.user_form.Add(newUserForm);
            context.SaveChanges();

            context.Entry(newUser).State = EntityState.Modified;
            context.Entry(newUserForm).State = EntityState.Modified;

            UserAdded?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
