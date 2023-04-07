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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Linq;
using static Diplom_Storage.AllPage.PageLogin;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32;
using System.Data.Entity;
using System.Drawing;
using Diplom_Storage.WindowForRole;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для UserKabinet.xaml
    /// </summary>
    public partial class UserKabinet : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public UserKabinet()
        {
            InitializeComponent();
            string json = File.ReadAllText("userSettings.json");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(json);
            int idUser = userSettings.IdUser;
            var user = context.users.FirstOrDefault(x => x.ID_USERS == idUser);
            var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUser);
            string loginus = user.login;
            LoginUser.Text = loginus;
            DataContext = userForm;
            if (user != null && userForm != null)
            {
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
                    Ava.Fill = new ImageBrush(image);
                    BackBack.Fill = new ImageBrush(image);
                }
            }
        }
        public static byte[] BitmapImageToByteArray(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
        private void Ava_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string json = File.ReadAllText("userSettings.json");
            UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(json);
            int idUser = userSettings.IdUser;
            var user = context.users.FirstOrDefault(x => x.ID_USERS == idUser);
            var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUser);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {

                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                    bitmapImage.EndInit();
                    if (user != null)
                    {
                        userForm.photo = BitmapImageToByteArray(bitmapImage);
                        context.SaveChanges();
                    }

                    Ava.Fill = new ImageBrush(bitmapImage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}");
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditUserKab editWindow = new EditUserKab();
            editWindow.ShowDialog();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
