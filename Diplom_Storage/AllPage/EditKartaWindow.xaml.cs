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

namespace Diplom_Storage.AllPage
{
    /// <summary>
    /// Логика взаимодействия для EditKartaWindow.xaml
    /// </summary>
    public partial class EditKartaWindow : Window
    {
        private Product Product;
        DiplomNikiforovEntities context = DiplomNikiforovEntities.GetContext();
        private int ProdID;
        public EditKartaWindow(int selectedId)
        {
            InitializeComponent();
            ProdID = selectedId;
            Product = context.Product.FirstOrDefault(x => x.ID_PROD == ProdID);
            var Tcategory = context.Category.ToList();
            tname.Text = Product.Name;
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
            Product.Name = tname.Text;
            Product.Category = (Category)ComboBoxTcategory.SelectedItem;
            Product.Seria = (Seria)ComboBoxSeria.SelectedItem;
            Product.SUPP = (SUPP)ComboBoxSupp.SelectedItem;
            context.SaveChanges();

            MessageBox.Show("Изменения сохранены!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
