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
using CajaDiseño.SR;

namespace CajaDiseño.MVVM.View
{
    public partial class EnviosView : UserControl
    {
        private EnvioService envioService;

        public EnviosView(EnvioService envioService)
        {
            InitializeComponent();
            this.envioService = envioService;
            DG_Envio.ItemsSource = envioService.ObtenerEnvios(0, true);
        }

        public class Envios
        {
            public int ID_envio { get; set; }
            public Cliente Cliente { get; set; }
            public Factura Factura { get; set; }
            public string Direccion_envio { get; set; }
            public bool Entregado { get; set; }
            public bool Entrega_en_sucursal { get; set; }
        }

        public class EnvioService
        {
            public List<Envios> ObtenerEnvios(int idFactura, bool soloNoEntregados)
            {
                using (var servicioWeb = new WebServiceCoreSoapClient())
                {
                    var respuesta = servicioWeb.ObtenerEnvios(soloNoEntregados);

                    List<Envios> envios = respuesta.Envios.Where(e => e.factura.id_factura == idFactura).Select(p => new Envios()
                    {
                        ID_envio = p.id_envio,
                        Cliente = new Cliente(),
                        Factura = new Factura(),
                        Direccion_envio = p.direccion_envio,
                        Entregado = p.entregado,
                        Entrega_en_sucursal = p.entrega_en_sucursal
                    }).ToList();
                    return envios;
                }
            }
        }

        private void BTN_Buscar_Click(object sender, RoutedEventArgs e)
        {
            int codigoFactura;
            if (int.TryParse(TXB_CodigoFactura.Text, out codigoFactura))
            {
                var envioEncontrado = envioService.ObtenerEnvios(0, true).FirstOrDefault(p => p.Factura.id_factura == codigoFactura);
                if (envioEncontrado != null)
                {
                    DG_Envio.ItemsSource = new List<Envios>() { envioEncontrado };
                }
                else
                {
                    DG_Envio.ItemsSource = new List<Envios>();
                    MessageBox.Show("No se encontró ningún envio con el ID especificado.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un número válido como ID de factura.");
            }
        }
        private void TXB_CodigoFactura_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TXB_Telefono_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TXB_Cliente_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
