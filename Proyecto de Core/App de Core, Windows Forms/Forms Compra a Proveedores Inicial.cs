using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_de_Core__Windows_Forms
{
    public partial class Forms_Compra_a_Proveedores_Incial : Form
    {
        public Forms_Compra_a_Proveedores_Incial()
        {
            InitializeComponent();
        }

        private void Forms_Compra_a_Proveedores_Incial_Load(object sender, EventArgs e)
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

            List<CLASEPRUEBA> lista = new List<CLASEPRUEBA>();
            for (int i = 0; i < 20; i++)
            {
                CLASEPRUEBA prueba = new CLASEPRUEBA() { Cod_Envio = 1,Producto_Ordenado = "A",Precio_Unit = "AB",Cant_Ordenada = "SAS",Proveedor = 3,Estado = "A"};
                lista.Add(prueba);
            }
            dataGridView1.DataSource = lista;
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void roundedGroupBox82_Enter(object sender, EventArgs e)
        {

        }

        private void botonPersonalizado2_Click(object sender, EventArgs e)
        {

        }
    }
}
