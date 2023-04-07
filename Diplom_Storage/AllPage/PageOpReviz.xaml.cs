using Diplom_Storage.AppData;
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

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для PageOpReviz.xaml
    /// </summary>
    public partial class PageOpReviz : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public PageOpReviz()
        {
            InitializeComponent();
        }

        private void OperTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var query = from s in context.stock_operations
                        join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                        join p in context.Product on s.product_id equals p.ID_PROD
                        join u in context.users on s.user_id equals u.ID_USERS
                        where p.Name.Contains(searchBox.Text)
                        || o.name.Contains(searchBox.Text)
                        || u.login.Contains(searchBox.Text)
                        select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
            OperTabl.ItemsSource = query.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var query = from s in context.stock_operations
                            join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                            join p in context.Product on s.product_id equals p.ID_PROD
                            group s by new { s.operation_type_ID, p.Name, o.name } into g
                            select new
                            {
                                ID = g.Key.operation_type_ID,
                                Тип = g.Key.name,
                                Товар = g.Key.Name,
                                Количество = g.Sum(s => s.quantity)
                            };
                OperTabl.ItemsSource = query.ToList();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
  
        }

        private void Chek_Click(object sender, RoutedEventArgs e)
        {
            CheckShipmentVsReceipt();

            // обновить таблицу
            DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var query = from s in context.stock_operations
                        join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                        join p in context.Product on s.product_id equals p.ID_PROD
                        group s by new { s.operation_type_ID, p.Name, o.name } into g
                        select new
                        {
                            ID = g.Key.operation_type_ID,
                            Тип = g.Key.name,
                            Товар = g.Key.Name,
                            Количество = g.Sum(s => s.quantity)
                        };
            OperTabl.ItemsSource = query.ToList();
        }

        private void CheckShipmentVsReceipt()
        {
            var products = context.Product.ToList();
            int errorCount = 0;

            foreach (var product in products)
            {
                var shipment = context.stock_operations
                    .Where(s => s.product_id == product.ID_PROD && s.operation_type_ID == 2)
                    .Sum(s => s.quantity);
                var receipt = context.stock_operations
                    .Where(s => s.product_id == product.ID_PROD && s.operation_type_ID == 1)
                    .Sum(s => s.quantity);

                if (shipment > receipt)
                {
                    MessageBox.Show($"Количество отгрузки товара '{product.Name}' больше, чем количество приемки!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    errorCount++;
                }
            }

            if (errorCount == 0)
            {
                MessageBox.Show("Авторевизия прошла успешно. Ошибок не обнаружено.");
            }
            else
            {
                MessageBox.Show($"Авторевизия прошла успешно. Количество ошибок: {errorCount}.");
            }
        }
    }
}
