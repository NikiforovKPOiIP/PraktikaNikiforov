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

namespace Diplom_Storage
{
    /// <summary>
    /// Логика взаимодействия для AddToSklad.xaml
    /// </summary>
    public partial class AddToSklad : Window
    {
        public int AddedQuantity { get; set; }

        public AddToSklad(int selectedId, int selectedQuantity)
        {
            InitializeComponent();
            IdLabel.Content = selectedId.ToString();
            QuantityLabel.Content = selectedQuantity.ToString();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AddQuantityTextBox.Text, out int addedQuantity))
            {
                AddedQuantity = addedQuantity;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Введите корректное число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
