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
    /// Логика взаимодействия для PageBrak.xaml
    /// </summary>
    public partial class PageBrak : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public PageBrak()
        {
            InitializeComponent();
        }
        private void OperTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                var query = from b in context.BRAK
                            join p in context.Product on b.Product_ID equals p.ID_PROD
                            join u in context.users on b.USER_ID equals u.ID_USERS
                            join s in context.Status on b.Status_ID equals s.ID_STATUS
                            where p.Name.Contains(searchBox.Text)
                            || s.name.Contains(searchBox.Text)
                            || u.login.Contains(searchBox.Text)
                            select new { ID = b.ID_BRAK, Дата = b.DataOtgruz, Товар = p.Name, Статус = s.name, Количество = b.quanity, Ответственный = u.login };
                OperTabl.ItemsSource = query.ToList();
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var query = from b in context.BRAK
                            join p in context.Product on b.Product_ID equals p.ID_PROD
                            join u in context.users on b.USER_ID equals u.ID_USERS
                            join s in context.Status on b.Status_ID equals s.ID_STATUS
                            select new { ID = b.ID_BRAK, Дата = b.DataOtgruz, Товар = p.Name,Статус = s.name, Количество = b.quanity, Ответственный = u.login };
                OperTabl.AutoGenerateColumns = false;
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Дата", Binding = new Binding("Дата") { StringFormat = "yyyy.MM.dd" } });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Статус", Binding = new Binding("Статус") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Ответственный", Binding = new Binding("Ответственный") });
                OperTabl.ItemsSource = query.ToList();
            }
        }
        private void BrakCreate_Click(object sender, RoutedEventArgs e)
        {
            AddBrak addOpWindow = new AddBrak();
            addOpWindow.Closed += addOpWindow_Closed;
            addOpWindow.ShowDialog();
        }
        private void addOpWindow_Closed(object sender, EventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            var query = from b in context.BRAK
                        join p in context.Product on b.Product_ID equals p.ID_PROD
                        join u in context.users on b.USER_ID equals u.ID_USERS
                        join s in context.Status on b.Status_ID equals s.ID_STATUS
                        select new { ID = b.ID_BRAK, Дата = b.DataOtgruz, Товар = p.Name, Статус = s.name, Количество = b.quanity, Ответственный = u.login };
            OperTabl.ItemsSource = query.ToList();
        }
    }
}
