using Diplom_Storage.AppData;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для PageZakaz.xaml
    /// </summary>
    public partial class PageZakaz : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public PageZakaz()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                var query = from z in context.Zakaz
                            join p in context.Product on z.ProductID equals p.ID_PROD
                            join s in context.Status on z.Status equals s.ID_STATUS
                            select new { ID = z.ID_Zakaz, Товар = p.Name, Количество = z.Kolvo, Статус = s.name };
                OperTabl.AutoGenerateColumns = false;
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Статус", Binding = new Binding("Статус") });
                OperTabl.ItemsSource = query.ToList();
            }
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OperTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Zakaz");
                MessageBox.Show("Таблица успешно очищена");
                var query = from z in context.Zakaz
                            join p in context.Product on z.ProductID equals p.ID_PROD
                            select new { ID = z.ID_Zakaz, Товар = p.Name, Количество = z.Kolvo };
                OperTabl.AutoGenerateColumns = false;
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                OperTabl.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var zakaz in context.Zakaz)
                {
                    zakaz.Status = 3;
                }
                context.SaveChanges();
                var query = from z in context.Zakaz
                            join p in context.Product on z.ProductID equals p.ID_PROD
                            join s in context.Status on z.Status equals s.ID_STATUS
                            select new { ID = z.ID_Zakaz, Товар = p.Name, Количество = z.Kolvo, Статус = s.name };
                OperTabl.AutoGenerateColumns = false;
                OperTabl.Columns.Clear();
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Товар", Binding = new Binding("Товар") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
                OperTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Статус", Binding = new Binding("Статус") });
                OperTabl.ItemsSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
