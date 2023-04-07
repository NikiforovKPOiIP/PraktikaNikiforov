using Diplom_Storage.AppData;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Diplom_Storage.AllPage.PageLogin;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для UsersPages.xaml
    /// </summary>
    public partial class UsersPages : Page
    {
        public UsersPages()
        {
            InitializeComponent();
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = UserTabl.SelectedItem;
            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить этот товар?", "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                    var context = DiplomNikiforovEntities.GetContext();
                    var user = context.users.Single(p => p.ID_USERS == selectedId);
                    context.users.Remove(user);
                    context.SaveChanges();
                    // Обновляем данные в таблице UserTabl
                    UserTabl.ItemsSource = null;
                    var query = from u in context.users
                                join r in context.roles on u.role_id equals r.ID_ROLE
                                select new { ID = u.ID_USERS, Логин = u.login, Пароль = u.password, Роль = r.name };
                    UserTabl.ItemsSource = query.ToList();
                }
            }
        }
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from u in context.users
                        join r in context.roles on u.role_id equals r.ID_ROLE
                        where u.login.Contains(searchBox.Text)
                              || u.password.Contains(searchBox.Text)
                              || u.ID_USERS.ToString().Contains(searchBox.Text)
                              || r.name.Contains(searchBox.Text)
                        select new { ID = u.ID_USERS, Логин = u.login, Пароль = u.password, Роль = r.name };
            UserTabl.ItemsSource = query.ToList();
        }

        private void PlusUser_Click(object sender, RoutedEventArgs e)
        {
            AddToUser addUser = new AddToUser();
            addUser.UserAdded += AddUser_UserAdded;
            addUser.ShowDialog();
        }
        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = UserTabl.SelectedItem;
            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                    var context = DiplomNikiforovEntities.GetContext();
                    var userForm = context.user_form.Single(p => p.User_ID == selectedId);
                    context.user_form.Remove(userForm);
                    context.SaveChanges();
                    var user = context.users.Single(p => p.ID_USERS == selectedId);
                    context.users.Remove(user);
                    context.SaveChanges();
                    var query = from u in context.users
                                join r in context.roles on u.role_id equals r.ID_ROLE
                                select new { ID = u.ID_USERS, Логин = u.login, Пароль = u.password, Роль = r.name };
                    UserTabl.ItemsSource = query.ToList();
                    UserBlock.Fill = Brushes.Transparent;
                    BackBackUP.Fill = Brushes.Transparent;
                }
            }
        }
        private void AddUser_UserAdded(object sender, EventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from u in context.users
                        join r in context.roles on u.role_id equals r.ID_ROLE
                        select new { ID = u.ID_USERS, Логин = u.login, Пароль = u.password, Роль = r.name };
            UserTabl.ItemsSource = query.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
                var query = from u in context.users
                            join r in context.roles on u.role_id equals r.ID_ROLE
                            select new { ID = u.ID_USERS, Логин = u.login, Пароль = u.password, Роль = r.name };
                UserTabl.AutoGenerateColumns = false;
                UserTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                UserTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Логин", Binding = new Binding("Логин") });
                UserTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Пароль", Binding = new Binding("Пароль") });
                UserTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Роль", Binding = new Binding("Роль") });
                UserTabl.ItemsSource = query.ToList();
            }
        }

        private void UserTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = UserTabl.SelectedItem;

            if (selectedItem != null)
            {
                var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);

                var context = DiplomNikiforovEntities.GetContext();

                var user = context.users.Single(p => p.ID_USERS == selectedId);

                var userForm = context.user_form.FirstOrDefault(x => x.User_ID == selectedId);
                DataContext = userForm;
                if (userForm != null && userForm.photo != null)
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(userForm.photo);
                    bitmap.EndInit();
                    UserBlock.Fill = new ImageBrush(bitmap);
                    BackBackUP.Fill = new ImageBrush(bitmap);
                }
                else
                {
                    UserBlock.Fill = null;
                }
            }
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            //Использовать код для кнопок редактирования, не потерять
            var selectedItem = UserTabl.SelectedItem;
            if (selectedItem != null)
            {
                var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                EditUserPage secondForm = new EditUserPage(selectedId);
                secondForm.Closed += RedactForm_Closed;
                secondForm.ShowDialog();
            }
        }
        private void RedactForm_Closed(object sender, EventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from u in context.users
                        join r in context.roles on u.role_id equals r.ID_ROLE
                        select new { ID = u.ID_USERS, Логин = u.login, Пароль = u.password, Роль = r.name };
            UserTabl.ItemsSource = query.ToList(); 
        }

        private void UserCard_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var frame = window.FindName("FrmRole1") as Frame;
            if (frame != null)
            {
                frame.Navigate(new UsersPages());
            }
            var selectedItem = UserTabl.SelectedItem;
            if (selectedItem != null)
            {
                var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                frame.Navigate(new UserKabinet2(selectedId));

            }
       
        }
    }
}


