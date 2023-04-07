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
using System.IO;
using static Diplom_Storage.AllPage.PageLogin;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для AddBrak.xaml
    /// </summary>
    public partial class AddBrak : Window
    {
        byte[] photo;
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public AddBrak()
        {
            InitializeComponent();
            var productName = context.Product.ToList();
            ProductComboBox.ItemsSource = productName;
            ProductComboBox.DisplayMemberPath = "Name";
        }
        private byte[] GetPhoto()
        {
            byte[] photo = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                photo = File.ReadAllBytes(filename);
            }
            return photo;
        }
        private void PhotoButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] photo = GetPhoto();
            if (photo != null)
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.StreamSource = new MemoryStream(photo);
                bi.EndInit();
                PhotoImage.Source = bi;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            {
                string json = File.ReadAllText("userSettings.json");
                UserSettings userSettings = JsonConvert.DeserializeObject<UserSettings>(json);
                int idUser = userSettings.IdUser;
                string ProductName = ((Product)ProductComboBox.SelectedItem).Name; ;
                int quantity = int.Parse(QuantityTextBox.Text);
                using (var context = new DiplomNikiforovEntities())
                {
                    var product = context.Product.FirstOrDefault(p => p.Name == ProductName);
                    var operationType = context.stock_operation_types.FirstOrDefault(o => o.ID_OPTYPE == 3); // Исправление брака
                    var user = context.users.FirstOrDefault(u => u.ID_USERS == idUser);
                    var operation = new stock_operations
                    {
                        operation_type_ID = operationType.ID_OPTYPE,
                        product_id = product.ID_PROD,
                        user_id = user.ID_USERS,
                        operation_date = DateTime.Now,
                        quantity = quantity
                    };
                    context.stock_operations.Add(operation);
                    var sklad = context.SKLAD.FirstOrDefault(s => s.Product_ID == product.ID_PROD);
                    if (sklad != null)
                    {
                        sklad.Kolvo -= quantity;
                    }
                    else
                    {
                        MessageBox.Show("Товар отсутствует.");
                    }

                    var brak = new BRAK
                    {
                        Product_ID = product.ID_PROD,
                        quanity = quantity,
                        Photo = photo,
                        USER_ID = idUser,
                        DataOtgruz = DateTime.Now,
                        Status_ID = 1
                    };
                    context.BRAK.Add(brak);
                    context.SaveChanges();
                }
                MessageBox.Show("Запись успешно сохранена.");
            }
        }       
    }
}
