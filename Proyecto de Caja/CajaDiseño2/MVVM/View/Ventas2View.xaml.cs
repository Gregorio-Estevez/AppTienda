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
    /// Interaction logic for Ventas2View.xaml
    /// </summary>
    public partial class Ventas2View : UserControl
    {

        Detalles_Fact_Compras[] _compras = new Detalles_Fact_Compras[] { };
        List<VentasDGV> venta = new List<VentasDGV>();
        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();
        decimal impuesto=0;

        public Ventas2View()
        {
            InitializeComponent();
        }

        private void ComboBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            WindowMetodoPago windowMetodoPago = new WindowMetodoPago();

            windowMetodoPago.Show();
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            WindowMetodoPago windowMetodoPago = new WindowMetodoPago();

            windowMetodoPago.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Met_Pagos pagos = new Met_Pagos();
            pagos = (Met_Pagos)comboboxVentas.SelectedItem;
            switch (pagos.descripcion)
            {
                case "Efectivo":
                    WindowMetodoPago windowMetodoPago = new WindowMetodoPago();
                    windowMetodoPago.Show();
                    break;
            }
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

        private void txtCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        private void BTN_Agregar_Click(object sender, RoutedEventArgs e)
        {

            // Crea un nuevo objeto Detalles_Fact_Compras a partir de los datos de los cuadros de texto
            if (TXB_Precio.Text != "")
            {
                Detalles_Fact_Compras detalle = new Detalles_Fact_Compras();
                detalle.producto = new Productos();
                detalle.producto = (Productos)cb_producto.SelectedItem;
                detalle.cant_producto = int.Parse(TXB_Cantidad.Text);
                detalle.descuento = detalle.producto.descuento;
                _compras.Append(detalle);

                VentasDGV vnt = new VentasDGV
                {
                    id_producto = detalle.producto.id_producto,
                    precio = detalle.producto.precio,
                    nombre_prood = detalle.producto.nombre,
                    cantprod = detalle.cant_producto
                };
                venta.Add(vnt);

                DG_VentasProducto.ItemsSource = venta;
                DG_VentasProducto.Items.Refresh();
                CalcularSubtotal(detalle);
            }




            //Factura factura = new Factura();
            //factura.metpago = new Met_Pagos();
            //factura.tipo_compra = new Tipo_Compra();
            //Met_Pagos metpagos = new Met_Pagos();
            //Tipo_Compra tipoCompra = new Tipo_Compra();
            //metpagos = (Met_Pagos)comboboxVentas.SelectedItem;
            //factura.metpago = metpagos;
            //factura.tipo_compra = tipoCompra;



        }

        private void CalcularSubtotal(Detalles_Fact_Compras producto)
        {
            decimal calc,subtotal;
            if (TXB_Subtotal.Text == "") calc = 0;
            else calc = decimal.Parse(TXB_Subtotal.Text);
            calc += producto.cant_producto * producto.producto.precio * (1 - producto.descuento);
            TXB_Subtotal.Text = calc.ToString();
            if (TXB_Descuento.Text == "") calc = 0;
            else calc = decimal.Parse(TXB_Descuento.Text);
            calc += producto.producto.precio*producto.cant_producto*producto.descuento;
            TXB_Descuento.Text = calc.ToString();
            calc = 0;
            if (TXB_Total.Text == "") calc = 0;
            else calc = decimal.Parse(TXB_Total.Text);
            calc += producto.cant_producto * producto.producto.precio * (1 - producto.descuento) *(1+ 0.18m);
            TXB_Total.Text = calc.ToString();
            impuesto += producto.cant_producto * producto.producto.precio * (1 - producto.descuento) * ( 0.18m);
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ObtenerProductosResponses productos = new ObtenerProductosResponses();
            productos = ws.ObtenerProductos(true);
            cb_producto.ItemsSource = productos.productos;
            cb_producto.DisplayMemberPath = "nombre";
            ObtenerClientePorIDResponses clientes = new ObtenerClientePorIDResponses();
            clientes = ws.ObtenerClientePorID(2);
            List<Cliente> clt = new List<Cliente>();
            clt.Add(clientes.cliente);
            cb_cliente.ItemsSource = clt;
            cb_cliente.DisplayMemberPath = "nombre";
            ObtenerMetPagoResponses metPago = new ObtenerMetPagoResponses();
            metPago = ws.ObtenerMetPago(true);
            comboboxVentas.ItemsSource = metPago.metodos_pago;
            comboboxVentas.DisplayMemberPath = "descripcion";

        }

        private void cb_producto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Productos prod = new Productos();
            prod = (Productos)cb_producto.SelectedItem;
            string precio = "RD$" + prod.precio.ToString();
            TXB_Precio.Text = precio;
        }

        private void BTN_Imprimir_Click(object sender, RoutedEventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente = (Cliente)cb_cliente.SelectedItem;
            Met_Pagos met_Pagos = new Met_Pagos();
            met_Pagos = (Met_Pagos)comboboxVentas.SelectedItem;
            Empleado emp = new Empleado();
            emp  =(Empleado) Application.Current.Properties["emp"];

            Factura factura = new Factura();
            factura.metpago = met_Pagos;
            factura.cliente = cliente;
            factura.empleado = emp;
            factura.nombre_cliente = cliente.nombre;
            factura.total_descuento = decimal.Parse(TXB_Descuento.Text);
            factura.subtotal_servicio = decimal.Parse(TXB_Subtotal.Text);
            factura.monto_total = decimal.Parse(TXB_Total.Text);
            factura.entrega_domicilio = false;
            factura.tipo_compra = new Tipo_Compra() { id_tipo_compra = 2};
            factura.vencimiento_fact = DateTime.Now.AddDays(30);
            factura.ncf = "1234567";
            factura.sucursal = emp.sucursal;
            factura.impuestos = impuesto;
            factura.servicio = new Servicios() { id_servicio = 1 };


            RegistrarNuevaFacturaResponses respuesta = new RegistrarNuevaFacturaResponses();
            respuesta = ws.RegistrarNuevaFactura(factura);
            if (respuesta.estado)
            {
                MessageBox.Show("Se guardo la factura. Pasaremos a los detalles");

                if (ws.RegistrarDetallesNuevaFacturaCompras(_compras))
                {
                    MessageBox.Show("Se guardó correctamente");
                }
                else
                {
                    MessageBox.Show("No se guardó");
                }
            }
            else { MessageBox.Show("No se pudo guardar la factura"); }
        }
    }
}
