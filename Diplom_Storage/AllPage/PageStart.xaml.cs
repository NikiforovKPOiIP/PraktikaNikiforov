﻿using Diplom_Storage.AppData;
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
    /// Логика взаимодействия для PageStart.xaml
    /// </summary>
    public partial class PageStart : Page
    {
        public PageStart()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageLogin());
        }

    }
}
