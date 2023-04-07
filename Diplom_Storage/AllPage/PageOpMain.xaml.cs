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
    /// Логика взаимодействия для PageOpMain.xaml
    /// </summary>
    public partial class PageOpMain : Page
    {
        public PageOpMain()
        {
            InitializeComponent();

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Priemka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);
            var frame = window.FindName("FrmRole1") as Frame;
            if (frame != null)
            {
                frame.Navigate(new PageOperation());
            }
        }

        private void Otgruzka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);
            var frame = window.FindName("FrmRole1") as Frame;
            if (frame != null)
            {
                frame.Navigate(new PageOpOtgruzka());
            }
        }

        private void Revizia_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);
            var frame = window.FindName("FrmRole1") as Frame;
            if (frame != null)
            {
                frame.Navigate(new PageOpReviz());
            }
        }

        private void Brak_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var window = Window.GetWindow(this);
            var frame = window.FindName("FrmRole1") as Frame;
            if (frame != null)
            {
                frame.Navigate(new PageBrak());
            }
        }
    }
}
