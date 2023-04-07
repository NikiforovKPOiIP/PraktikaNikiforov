using Diplom_Storage.AllPage;
using Diplom_Storage.AppData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;
using static Diplom_Storage.AllPage.PageLogin;
using System.Diagnostics;

namespace Diplom_Storage.WindowForRole
{
    /// <summary>
    /// Логика взаимодействия для Role1.xaml
    /// </summary>
    public partial class Role1 : Window
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public Role1(string login, string password, int role_id)
        {
            InitializeComponent();
            string json = File.ReadAllText("userSettings.json");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(json);
            int idUser = userSettings.IdUser;
            var user = context.users.FirstOrDefault(x => x.ID_USERS == idUser);
            var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUser);
            var roleForm = context.roles.FirstOrDefault(x => x.ID_ROLE == idUser);
            AppFrame.frameMain = FrmRole1;
            UserName.Text = login;
            var roleUser = user.roles.name;
            UserRole.Text = roleUser;
            if (userForm.photo != null)
            {
                BitmapImage image = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(userForm.photo))
                {
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = stream;
                    image.EndInit();
                }
                avarole.Fill = new ImageBrush(image);
            }

        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SkladButton_Click(object sender, RoutedEventArgs e)
        {
            FrmRole1.Navigate(new PageSklad());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            FrmRole1.Navigate(new UsersPages());
        }
        private void Acc_Click(object sender, RoutedEventArgs e)
        {
            FrmRole1.Navigate(new UserKabinet());
        }

        private void Main_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitAcc_Click(object sender, RoutedEventArgs e)
        {
            UserSettings userSettings = new UserSettings();
            string json = JsonConvert.SerializeObject(userSettings);
            File.WriteAllText("userSettings.json", json);
            var currentProcess = Process.GetCurrentProcess();
            string applicationName = currentProcess.ProcessName + ".exe";
            Process.Start(applicationName);
            this.Close();
            Application.Current.Shutdown();
        }

        private void Tovar_Click(object sender, RoutedEventArgs e)
        {
            FrmRole1.Navigate(new TovarPage());
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            FrmRole1.Navigate(new PageOpMain());
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            FrmRole1.Navigate(new PageZakaz());
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            FrmRole1.Navigate(new PageReport());
        }
    }
}
