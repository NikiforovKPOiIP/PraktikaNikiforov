using Diplom_Storage.AppData;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для UserKabinet2.xaml
    /// </summary>
    public partial class UserKabinet2 : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        private int idUser;
        public UserKabinet2(int selectedId)
        {
            InitializeComponent();
            idUser = selectedId;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();

                byte[] photo = BitmapImageToByteArray(image);

                var userForm = context.user_form.FirstOrDefault(x => x.User_ID == idUser);
                if (userForm != null)
                {
                    userForm.photo = photo;
                    context.SaveChanges();
                    Ava.Fill = new ImageBrush(image);
                    BackBack.Fill = new ImageBrush(image);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditUserKab2 editWindow = new EditUserKab2(idUser);
            editWindow.ShowDialog();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
