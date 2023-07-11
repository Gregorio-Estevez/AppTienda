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
using Aplicacion_de_Core_WinForms.Properties;
using Aplicacion_de_Core_WinForms.SR;

namespace Aplicacion_de_Core_WinForms
{
    public partial class Form1 : Form
    {
        public Empleado emp { get; set; } = new Empleado();
        public Form1(Empleado empleado)
        {
            emp = empleado;
            InitializeComponent();
        }
        string dir_proyecto = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;
        string rutaImagen;
        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            timerHora.Start();
            labelFecha.Text = DateTime.Now.ToString("dddd d 'de' MMMM, yyyy");
            btn_manejo_empleado.Image = Resources.empleado__4_;
            btn_manejo_empleado.ImageAlign = ContentAlignment.MiddleLeft;
            pb_foto_empleado.Image = Resources.unsplash_qt82DHID50M;
            pb_foto_empleado.SizeMode = PictureBoxSizeMode.StretchImage;
            btn_atras.Image = Resources.btn_atras;
            btn_atras.ImageAlign = ContentAlignment.MiddleLeft;
            btn_manejo_prodctos.Image = Resources.produccion__2_;
            btn_manejo_prodctos.ImageAlign = ContentAlignment.MiddleLeft;
            btn_manejo_proveedores.Image = Resources.proveedor;
            btn_manejo_proveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btn_compras_proveedores.Image = Resources.entrega_de_pedidos;
            btn_compras_proveedores.ImageAlign = ContentAlignment.MiddleLeft;
            btn_reportes_negocio.Image = Resources.estadistica_inferencial;
            btn_reportes_negocio.ImageAlign = ContentAlignment.MiddleLeft;

            labelHora.Text = DateTime.Now.ToString("HH:mm:ss");
            pb_foto_empleado.Image = Image.FromFile(dir_proyecto + emp.ruta_foto);

            ObtenerEstadosResponses respuesta = ws.ObtenerEstados(true);
            cbEstado.DataSource = respuesta.estados;
            cbEstado.DisplayMember = "nombre_estado";
            ObtenerCategoriaEmpleadoResponses responses = ws.ObtenerCategoriaEmpleado(true);
            cbTipoEmpleado.DataSource = responses.categoria;
            cbTipoEmpleado.DisplayMember = "nombre_categoria";
            ObtenerSucursalesResponses resp = ws.ObtenerSucursales(true);
            cbSucursal.DataSource = resp.sucursales;
            cbSucursal.DisplayMember = "nombre_sucursal";
        }

        private void rgb1_Load(object sender, EventArgs e)
        {

        }

        private void labelFecha_Click(object sender, EventArgs e)
        {

        }

        private void labelHora_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void roundedGroupBox82_Enter(object sender, EventArgs e)
        {

        }

        private void roundedTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void roundedTextBox2__TextChanged(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {

        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void botonPersonalizado3_Click(object sender, EventArgs e)
        {

        }
    }
}
