using Diplom_Storage.AppData;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static Diplom_Storage.AllPage.AddToUser;

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для AddTovar.xaml
    /// </summary>
    public partial class AddTovar : Window
    {
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        public delegate void TovarAddedEventHandler(object sender, EventArgs e);
        public AddTovar()
        {
            InitializeComponent();
            var Tcategory = context.Category.ToList();
            ComboBoxTcategory.ItemsSource = Tcategory;
            ComboBoxTcategory.DisplayMemberPath = "Name";
            var TSeria = context.Seria.ToList();
            ComboBoxSeria.ItemsSource = TSeria;
            ComboBoxSeria.DisplayMemberPath = "Name";
            var TSupp = context.SUPP.ToList();
            ComboBoxSupp.ItemsSource = TSupp;
            ComboBoxSupp.DisplayMemberPath = "Name";
            var TStatus = context.MinimalKolvo.ToList();
            ComboBoxStatus.ItemsSource = TStatus;
            ComboBoxStatus.DisplayMemberPath = "Name";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = tname.Text.Trim();
            Category category = ComboBoxTcategory.SelectedItem as Category;
            Seria seria = ComboBoxSeria.SelectedItem as Seria;
            SUPP supplier = ComboBoxSupp.SelectedItem as SUPP;
            MinimalKolvo minimalKolvo = ComboBoxStatus.SelectedItem as MinimalKolvo;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Введите название товара.");
                return;
            }
            if (category == null)
            {
                MessageBox.Show("Выберите категорию.");
                return;
            }
            if (seria == null)
            {
                MessageBox.Show("Выберите серию.");
                return;
            }
            if (supplier == null)
            {
                MessageBox.Show("Выберите поставщика.");
                return;
            }
            if (minimalKolvo == null)
            {
                MessageBox.Show("Выберите статус.");
                return;
            }
            bool nameExists = context.Product.Any(t => t.Name == name);
            if (nameExists)
            {
                MessageBox.Show("Товар с таким названием уже существует.");
                return;
            }
            Product tovar = new Product
            {
                Name = name,
                Category = category,
                Seria = seria,
                SUPP = supplier,
            };

            context.Product.Add(tovar);
            context.SaveChanges();
            tname.Text = "";
            ComboBoxTcategory.SelectedIndex = -1;
            ComboBoxSeria.SelectedIndex = -1;
            ComboBoxSupp.SelectedIndex = -1;
            ComboBoxStatus.SelectedIndex = -1;
            MessageBox.Show("Товар успешно добавлен.");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

