using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
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
using System.IO;
using static Diplom_Storage.AllPage.PageLogin;
using Diplom_Storage.AppData;
using System.Windows.Navigation;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для EditUserKab.xaml
    /// </summary>
    public partial class EditUserKab : Window
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public EditUserKab()
        {
            InitializeComponent();

            string json = File.ReadAllText("userSettings.json");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(json);
            int idUser = userSettings.IdUser;
            var user = context.users.FirstOrDefault(x => x.ID_USERS == idUser);
            var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUser);
            DataContext = userForm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string json = File.ReadAllText("userSettings.json");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(json);
            int idUser = userSettings.IdUser;
            var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUser);
            userForm.first_name = fname.Text;
            userForm.last_name = lname.Text;
            userForm.patronymic = patron.Text;
            userForm.phone = phoneus.Text;
            userForm.email = mail.Text;
            userForm.date_of_birth = dr.SelectedDate;
            context.SaveChanges();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
        }
    }
}
