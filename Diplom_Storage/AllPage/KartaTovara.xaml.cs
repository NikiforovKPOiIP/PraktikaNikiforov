using Diplom_Storage.AppData;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для KartaTovara.xaml
    /// </summary>
    public partial class KartaTovara : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        private int idTovar;
        public KartaTovara(int selectedId)
        {
            idTovar = selectedId;
            var Tovar = context.Product.FirstOrDefault(x => x.ID_PROD == idTovar);
            InitializeComponent();
            DataContext = Tovar;
                if (Tovar.Photo != null)
                {
                    BitmapImage image = new BitmapImage();
                    using (MemoryStream stream = new MemoryStream(Tovar.Photo))
                    {
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = stream;
                        image.EndInit();
                    }
                    TovarPhoto.Fill = new ImageBrush(image);
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

        private void TovarPhotoRedact_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

                var TovarProd = context.Product.FirstOrDefault(x => x.ID_PROD == idTovar);
                if (TovarProd != null)
                {
                    TovarProd.Photo = photo;
                    context.SaveChanges();
                    TovarPhotoRedact.Fill = new ImageBrush(image);
                    // BackBack.Fill = new ImageBrush(image);
                }
            }
        }
        public class KartaProduct
        {
            public int ID_PROD { get; set; }
            public string Name { get; set; }
            public int Category_ID { get; set; }
            public int Seria_ID { get; set; }
            public int Supp_ID { get; set; }
            public int MinForOrder_ID { get; set; }
            public virtual Category Category { get; set; }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int selectedId = idTovar;
            EditKartaWindow editWindow = new EditKartaWindow(selectedId);
            editWindow.ShowDialog();
        }
    }
}
