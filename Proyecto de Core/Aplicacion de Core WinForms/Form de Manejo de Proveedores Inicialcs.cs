using Aplicacion_de_Core_WinForms.Properties;
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
    public partial class Form_de_Manejo_de_Proveedores_Inicialcs : Form
    {
        public Empleado emp { get; set; } = new Empleado();
        public Form_de_Manejo_de_Proveedores_Inicialcs(Empleado empleado)
        {
            emp = empleado;
            InitializeComponent();
        }
        string dir_proyecto = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;

        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();

        private void Update_DGV()
        {
            Proveedores[] proveedores;
            ObtenerProveedoresResponses responses = new ObtenerProveedoresResponses();
            responses = ws.ObtenerProveedores(false);
            proveedores = responses.proveedores;
            dgvProveedores.DataSource = proveedores;
            dgvProveedores.Refresh();
        }

        private void Form_de_Manejo_de_Proveedores_Inicialcs_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            timerHora.Start();
            Update_DGV();
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
            string ruta_foto = dir_proyecto + emp.ruta_foto;
            pb_foto_empleado.Image = Image.FromFile(ruta_foto);
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void roundedTextBox4__TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Form_de_Manejo_de_Proveedores_Inicialcs_Resize(object sender, EventArgs e)
        {
            
        }

        private void Form_de_Manejo_de_Proveedores_Inicialcs_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void botonPersonalizado1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog open = new OpenFileDialog();
            //open.Title = "Seleccionar Imagen de Empleado";
            //open.Filter = "Archivos de imagen (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    string nombre_empleado = "Shakira_Pike_04800102008";
            //    string rutaImagen = open.FileName;
            //    MessageBox.Show(rutaImagen);
            //    Image imagen = Image.FromFile(rutaImagen);
            //    pb_foto_empleado.Image = imagen;
            //    rutaImagen = dir_proyecto + @"\Fotos\Empleados\" + nombre_empleado+".jpeg";
            //    imagen.Save(rutaImagen, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
        }

        private void roundedGroupBox82_Enter(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form_Manejo_de_Proveedores_2 form = new Form_Manejo_de_Proveedores_2(emp);
            this.TopMost = false;
            this.Visible = false;
            form.ShowDialog();
            this.TopMost = true;
            this.Visible = true;
            Update_DGV();
        }

        private void btn_manejo_empleado_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            Form1 form = new Form1(emp);
            form.Show();
            this.Close();
        }
    }
}
