﻿using System;
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
using CajaDiseño.SR;

namespace CajaDiseño.MVVM.View
{
    /// <summary>
    /// Interaction logic for ConfiguracionView.xaml
    /// </summary>
    public partial class ConfiguracionView : UserControl
    {
        public ConfiguracionView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtMoneda_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Ingresar_Moneda_Click(object sender, RoutedEventArgs e)
        {
            WindowTiposMonedas windowTiposMonedas = new WindowTiposMonedas();

            windowTiposMonedas.Show();
        }

    }
}
