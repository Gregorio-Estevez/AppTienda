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
using CajaDiseño.MVVM.View;

namespace CajaDiseño.MVVM.View
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public class Producto
    {
        public int ID_producto { get; set; }
        public string Nombre_Producto { get; set; }
        public decimal Precio_Unitario { get; set; }
        public string Sucursal { get; set; }
        public int Stock { get; set; }
        public Boolean Activo { get; set; }
    }

    public class ProductoService
    {
        public List<Producto> ObtenerProductos(bool condescontinuados)
        {
            using (var servicioWeb = new WebServiceCoreSoapClient())
            {
                var respuesta = servicioWeb.ObtenerProductos(condescontinuados);

                List<Producto> productos = respuesta.productos.Select(p => new Producto()
                {
                    ID_producto = p.id_producto,
                    Nombre_Producto = p.nombre,
                    Precio_Unitario = p.precio
                }).ToList();

                return productos;
            }
        }
    }
    public partial class MenuView : UserControl
    {
        private readonly ProductoService productoService = new ProductoService();

        public MenuView()
        {
            InitializeComponent();

            // Vinculamos la fuente de datos al DataGrid
            DG_Productos.ItemsSource = productoService.ObtenerProductos(true);
        }
        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();
        ObtenerProductosResponses obtenerProductosResponses = new ObtenerProductosResponses();
        private void Click_Detalles_Productos(object sender, RoutedEventArgs e)
        {
            WindowDetallesProductos windowDetallesProductos = new WindowDetallesProductos();

            windowDetallesProductos.Show();
        }
        private void BTN_Buscar_Click(object sender, RoutedEventArgs e)
        {
            int id_producto;
            if (int.TryParse(TXB_BuscarProducto.Text, out id_producto))
            {
                var productoEncontrado = productoService.ObtenerProductos(true).FirstOrDefault(p => p.ID_producto == id_producto);
                if (productoEncontrado != null)
                {
                    DG_Productos.ItemsSource = new List<Producto>() { productoEncontrado };
                }
                else
                {
                    DG_Productos.ItemsSource = new List<Producto>();
                    MessageBox.Show("No se encontró ningún producto con el ID especificado.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número válido como ID de producto.");
            }
        }

        private void DG_Productos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TXB_BuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}