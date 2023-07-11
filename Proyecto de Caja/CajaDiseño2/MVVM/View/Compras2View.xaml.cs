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
using CajaDiseño.SR;

namespace CajaDiseño.MVVM.View
{
    /// <summary>
    /// Interaction logic for Compras2View.xaml
    /// </summary>
    public partial class Compras2View : UserControl
    {
        public Compras2View()
        {
            InitializeComponent();
        }

        private void txtSubtotal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtDescuento_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txTotal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Compras_Detalles_Click(object sender, RoutedEventArgs e)
        {
            WindowDetallesCompras windowDetallesCompras = new WindowDetallesCompras();

            windowDetallesCompras.Show();
        }
    }
}
