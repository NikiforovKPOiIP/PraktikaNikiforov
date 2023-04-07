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
using static Diplom_Storage.AllPage.KartaTovara;
using System.Runtime.Remoting.Contexts;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для AddPriem.xaml
    /// </summary>
    public partial class AddPriem : Window
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public AddPriem()
        {
            InitializeComponent();
            var productName = context.Product.ToList();
            ProductComboBox.ItemsSource = productName;
            ProductComboBox.DisplayMemberPath = "Name";
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
                    var operationType = context.stock_operation_types.FirstOrDefault(o => o.ID_OPTYPE == 1);
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
                        sklad.Kolvo += quantity;
                    }
                    else
                    {
                        sklad = new SKLAD
                        {
                            Product_ID = product.ID_PROD,
                            Kolvo = quantity,
                            Status_ID = 1// здесь 
                        };

                        context.SKLAD.Add(sklad);
                    }
                    context.SaveChanges();
                }
                MessageBox.Show("Запись успешно сохранена.");
            }
        }
    }
}
