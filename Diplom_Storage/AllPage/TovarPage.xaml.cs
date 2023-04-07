using Diplom_Storage.AppData;
using System;
using System.Collections.Generic;
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
using static Diplom_Storage.AllPage.AddTovar;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для TovarPage.xaml
    /// </summary>
    public partial class TovarPage : Page
    {
        public TovarPage()
        {
            InitializeComponent();
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            string searchQuery = searchBox.Text;
            int searchID;
            bool isNumeric = int.TryParse(searchQuery, out searchID);
            var query = from p in context.Product
                        join c in context.Category on p.Category_ID equals c.ID_Catregory
                        join s in context.Seria on p.Seria_ID equals s.ID_SERIA
                        where p.Name.Contains(searchQuery)
                        || c.Name.Contains(searchQuery)
                        || s.Name.Contains(searchQuery)
                        || p.ID_PROD == searchID
                        select new { ID = p.ID_PROD, Категория = c.Name, Название = p.Name, Серия = s.Name};
            TovarTabl.ItemsSource = query.ToList();
        }

        private void PlusUser_Click(object sender, RoutedEventArgs e)
        {
            AddTovar addTovar = new AddTovar();
            addTovar.ShowDialog();
            RefreshDataGrid();
        }
        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = TovarTabl.SelectedItem;
            if (selectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                    var context = DiplomNikiforovEntities.GetContext();
                    
                    var TovarBrak = context.BRAK.SingleOrDefault(p => p.Product_ID == selectedId);
                    if (TovarBrak != null)
                    {
                        context.BRAK.Remove(TovarBrak);
                        context.SaveChanges();
                    }

                    var SkladTovar = context.SKLAD.SingleOrDefault(p => p.Product_ID == selectedId);
                    if (SkladTovar != null)
                    {
                        context.SKLAD.Remove(SkladTovar);
                        context.SaveChanges();
                    }

                    var ZakazTovar = context.Zakaz.SingleOrDefault(p => p.ProductID == selectedId);
                    if (ZakazTovar != null)
                    {
                        context.Zakaz.Remove(ZakazTovar);
                        context.SaveChanges();
                    }

                    var PriemTovar = context.Priem.SingleOrDefault(p => p.Product_ID == selectedId);
                    if (PriemTovar != null)
                    {
                        context.Priem.Remove(PriemTovar);
                        context.SaveChanges();
                    }

                    var StockOpTovar = context.stock_operations.SingleOrDefault(p => p.product_id == selectedId);
                    if (StockOpTovar != null)
                    {
                        context.stock_operations.Remove(StockOpTovar);
                        context.SaveChanges();
                    }

                    var Tovar = context.Product.SingleOrDefault(p => p.ID_PROD == selectedId);
                    if (Tovar != null)
                    {
                        context.Product.Remove(Tovar);
                        context.SaveChanges();
                    }

                    var query = from p in context.Product
                                join c in context.Category on p.Category_ID equals c.ID_Catregory
                                join s in context.Seria on p.Seria_ID equals s.ID_SERIA
                                select new { ID = p.ID_PROD, Категория = c.Name, Название = p.Name, Серия = s.Name};
                    TovarTabl.ItemsSource = query.ToList();
                    UserBlock.Fill = Brushes.Transparent;
                    BackBackUP.Fill = Brushes.Transparent;
                    TovarName.Text ="";
                }
            }
        }
        private void AddTovar_TovarAdded(object sender, EventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from p in context.Product
                        join c in context.Category on p.Category_ID equals c.ID_Catregory
                        join s in context.Seria on p.Seria_ID equals s.ID_SERIA
                        select new { ID = p.ID_PROD, Категория = c.Name, Название = p.Name, Серия = s.Name};
            TovarTabl.ItemsSource = query.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DiplomNikiforovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
                var query = from p in context.Product
                            join c in context.Category on p.Category_ID equals c.ID_Catregory
                            join s in context.Seria on p.Seria_ID equals s.ID_SERIA
                            select new { ID = p.ID_PROD, Категория = c.Name, Название = p.Name, Серия = s.Name};
                TovarTabl.AutoGenerateColumns = false;
                TovarTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "ID", Binding = new Binding("ID") });
                TovarTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Название", Binding = new Binding("Название") });
                TovarTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Категория", Binding = new Binding("Категория") });
                TovarTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Серия", Binding = new Binding("Серия") });
                TovarTabl.Columns.Add(new MaterialDesignThemes.Wpf.DataGridTextColumn { Header = "Состояние", Binding = new Binding("Состояние") });
                TovarTabl.ItemsSource = query.ToList();
            }
        }

        private void UserTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = TovarTabl.SelectedItem;

            if (selectedItem != null)
            {
                var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                var context = DiplomNikiforovEntities.GetContext();
                var tovar = context.Product.Single(p => p.ID_PROD == selectedId);
                DataContext = tovar;
                if (tovar != null && tovar.Photo != null)
                {
                    // Обновляю UserBlock с помощью полученной фотографии
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = new MemoryStream(tovar.Photo);
                    bitmap.EndInit();
                    UserBlock.Fill = new ImageBrush(bitmap);
                    BackBackUP.Fill = new ImageBrush(bitmap);
                    TovarName.Text = tovar.Name;
                }
                else
                {
                    // Если фотография нет
                    UserBlock.Fill = null;
                    TovarName.Text = tovar.Name;
                }
            }
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            //Использовать код для кнопок редактирования, не потерять
            var selectedItem = TovarTabl.SelectedItem;
            if (selectedItem != null)
            {
                var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                EditKartaWindow secondForm = new EditKartaWindow(selectedId);
                secondForm.Closed += RedactForm_Closed;
                secondForm.ShowDialog();
            }
        }
        private void RedactForm_Closed(object sender, EventArgs e)
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from p in context.Product
                        join c in context.Category on p.Category_ID equals c.ID_Catregory
                        join s in context.Seria on p.Seria_ID equals s.ID_SERIA
                        select new { ID = p.ID_PROD, Категория = c.Name, Название = p.Name, Серия = s.Name};
            TovarTabl.ItemsSource = query.ToList();
        }
        private void KartTovara_Click(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            var frame = window.FindName("FrmRole1") as Frame;
            if (frame != null)
            {
                frame.Navigate(new TovarPage());
            }
            var selectedItem = TovarTabl.SelectedItem;
            if (selectedItem != null)
            {
                var selectedId = (int)selectedItem.GetType().GetProperty("ID").GetValue(selectedItem);
                frame.Navigate(new KartaTovara(selectedId));

            }
        }
        private void RefreshDataGrid()
        {
            DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
            var query = from p in context.Product
                        join c in context.Category on p.Category_ID equals c.ID_Catregory
                        join s in context.Seria on p.Seria_ID equals s.ID_SERIA
                        select new { ID = p.ID_PROD, Категория = c.Name, Название = p.Name, Серия = s.Name};
            TovarTabl.ItemsSource = query.ToList();
        }
    }
}
