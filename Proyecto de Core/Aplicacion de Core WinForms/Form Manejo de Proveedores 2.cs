using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion_de_Core_WinForms.SR;

namespace Aplicacion_de_Core_WinForms
{
    public partial class Form_Manejo_de_Proveedores_2 : Form
    {
        public Form_Manejo_de_Proveedores_2(Empleado empleado,Proveedores proveedor = null)
        {
            InitializeComponent();
        }
        string dir_proyecto = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;
        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();

        private void Form_Manejo_de_Proveedores_Inicial_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            timerHora.Start();
            labelFecha.Text = DateTime.Now.ToString("dddd d 'de' MMMM, yyyy");
            btn_manejo_empleado.Image = Properties.Resources.empleado__4_;
            btn_manejo_empleado.ImageAlign = ContentAlignment.MiddleLeft;
            pb_foto_empleado.Image = Properties.Resources.unsplash_qt82DHID50M;
            pb_foto_empleado.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_atras.Image = Properties.Resources.btn_atras;
            btn_atras.ImageAlign = ContentAlignment.MiddleLeft;
            btn_manejo_prodctos.Image = Properties.Resources.produccion__2_;
            btn_manejo_prodctos.ImageAlign = ContentAlignment.MiddleLeft;
            btn_manejo_proveedores.Image = Properties.Resources.proveedor;
            btn_manejo_proveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btn_compras_proveedores.Image = Properties.Resources.entrega_de_pedidos;
            btn_compras_proveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btn_reportes_negocio.Image = Properties.Resources.estadistica_inferencial;
            btn_reportes_negocio.ImageAlign = ContentAlignment.MiddleLeft;

            labelHora.Text = DateTime.Now.ToString("HH:mm:ss");
            
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void botonPersonalizado3_Click(object sender, EventArgs e)
        {
            Proveedores prov = new Proveedores();
            prov.nombre = txbNombre.Texts;
            prov.rnc = txbrnc.Texts;
            prov.email = txbemail.Texts;
            prov.direccion = txbdireccion.Texts;
            prov.telefono = txbtelefono.Texts;
            prov.activo = chbxActivo.Checked;

            if (ws.RegistrarProveedores(prov))
            {
                MessageBox.Show("Proveedor Almacenado Correctamemte");
            }
            else
            {
                MessageBox.Show("Error al Almacenar");
            }
            this.Dispose();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
