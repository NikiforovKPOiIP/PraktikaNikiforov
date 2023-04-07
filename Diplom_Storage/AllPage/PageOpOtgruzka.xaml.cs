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
    /// Логика взаимодействия для PageOpOtgruzka.xaml
    /// </summary>
    public partial class PageOpOtgruzka : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public PageOpOtgruzka()
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
                        where o.ID_OPTYPE == 2
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
                            join u in context.users on s.user_id equals u.ID_USERS
                            where o.ID_OPTYPE == 2
                            select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
                OperTabl.AutoGenerateColumns = false;
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                OperTabl.ItemsSource = query.ToList();
            }
        }

        private void Otgruz_Click(object sender, RoutedEventArgs e)
        {
            AddOtgruz addOpWindow = new AddOtgruz();
            addOpWindow.Closed += addOpWindow_Closed;
            addOpWindow.ShowDialog();
        }
        private void addOpWindow_Closed(object sender, EventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var query = from s in context.stock_operations
                        join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                        join p in context.Product on s.product_id equals p.ID_PROD
                        join u in context.users on s.user_id equals u.ID_USERS
                        where o.ID_OPTYPE == 2
                        select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
            OperTabl.ItemsSource = query.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Database.ExecuteSqlCommand("DELETE FROM stock_operations WHERE operation_type_ID = 2");
                MessageBox.Show("Таблица успешно очищена");
                var query = from s in context.stock_operations
                            join o in context.stock_operation_types on s.operation_type_ID equals o.ID_OPTYPE
                            join p in context.Product on s.product_id equals p.ID_PROD
                            join u in context.users on s.user_id equals u.ID_USERS
                            where o.ID_OPTYPE == 2
                            select new { ID = s.ID_STOKOP, Дата = s.operation_date, Товар = p.Name, Тип = o.name, Количество = s.quantity, Ответственный = u.login };
                OperTabl.AutoGenerateColumns = false;
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Тип", Binding = new Binding("Тип") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                OperTabl.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
