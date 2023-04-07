using Diplom_Storage.AppData;
using Diplom_Storage.WindowForRole;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
using System.IO;
using static Diplom_Storage.AllPage.PageLogin;
using DocumentFormat.OpenXml.InkML;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для PageSklad.xaml
    /// </summary>
    public partial class PageSklad : Page
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public PageSklad()
        {
            InitializeComponent();
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from p in context.Product
                        join s in context.SKLAD on p.ID_PROD equals s.Product_ID
                        join c in context.Category on p.Category_ID equals c.ID_Catregory
                        select new { ID = s.ID_SKLAD, Название = p.Name, Количество = s.Kolvo, Категория = c.Name, };
            SkladTabl.AutoGenerateColumns = false;
            SkladTabl.Columns.Add(new DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
            SkladTabl.Columns.Add(new DataGridTextColumn { Header = "Название", Binding = new Binding("Название") });
            SkladTabl.Columns.Add(new DataGridTextColumn { Header = "Категория", Binding = new Binding("Категория") });
            SkladTabl.Columns.Add(new DataGridTextColumn { Header = "Количество", Binding = new Binding("Количество") });
            SkladTabl.ItemsSource = query.ToList();
            var editColumn = new DataGridTemplateColumn();
        }
        private bool IsProductAlreadyOrdered(int productId)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            return context.Zakaz.Any(z => z.ProductID == productId);
        }
        private void SkladTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var selectedItem = SkladTabl.SelectedItem as dynamic;
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from p in context.Product
                        join s in context.SKLAD on p.ID_PROD equals s.Product_ID
                        join c in context.Category on p.Category_ID equals c.ID_Catregory
                        where p.Name.Contains(searchBox.Text)
                              || s.Kolvo.ToString().Contains(searchBox.Text)
                              || c.Name.Contains(searchBox.Text)
                        select new { ID = s.ID_SKLAD, Название = p.Name, Количество = s.Kolvo, Категория = c.Name };
            SkladTabl.ItemsSource = query.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var productsToOrder = from p in context.Product
                                  join s in context.SKLAD on p.ID_PROD equals s.Product_ID
                                  join c in context.Category on p.Category_ID equals c.ID_Catregory
                                  join m in context.MinimalKolvo on c.MinimalKolvoId equals m.ID_Minimal
                                  where s.Kolvo < m.Kol_vo
                                  select p;

            foreach (var product in productsToOrder)
            {
                if (!IsProductAlreadyOrdered(product.ID_PROD))
                {
                    var newOrder = new Zakaz
                    {
                        ProductID = product.ID_PROD,
                        Kolvo = 1,
                        Date = DateTime.Now,
                        Status = 2
                    };
                    context.Zakaz.Add(newOrder);
                }
            }
            context.SaveChanges();
            var productsToRemove = from p in context.Product
                                   join s in context.SKLAD on p.ID_PROD equals s.Product_ID
                                   join c in context.Category on p.Category_ID equals c.ID_Catregory
                                   join m in context.MinimalKolvo on c.MinimalKolvoId equals m.ID_Minimal
                                   where s.Kolvo > m.Kol_vo
                                   select p;
            foreach (var product in productsToRemove)
            {
                var order = context.Zakaz.FirstOrDefault(z => z.ProductID == product.ID_PROD);
                if (order != null)
                {
                    context.Zakaz.Remove(order);
                }
            }
            context.SaveChanges();
        }   
    }
}
