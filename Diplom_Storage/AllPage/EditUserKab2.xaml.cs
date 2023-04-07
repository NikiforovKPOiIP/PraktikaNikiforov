using Diplom_Storage.AppData;
using Newtonsoft.Json;
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
using System.Windows.Shapes;
using static Diplom_Storage.AllPage.PageLogin;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для EditUserKab2.xaml
    /// </summary>
    public partial class EditUserKab2 : Window
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        private int idUserForEdit;
        public EditUserKab2(int idUser)
        {
            idUserForEdit = idUser; 
            InitializeComponent();
            var user = context.users.FirstOrDefault(x => x.ID_USERS == idUserForEdit);
            var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUserForEdit);
            DataContext = userForm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUserForEdit);
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

