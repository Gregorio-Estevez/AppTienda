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

namespace App_de_Core__Windows_Forms
{
    public partial class Form_de_Manejo_de_Proveedores_Inicialcs : Form
    {
        public Form_de_Manejo_de_Proveedores_Inicialcs()
        {
            InitializeComponent();
        }
        string dir_proyecto = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;
        private void Form_de_Manejo_de_Proveedores_Inicialcs_Load(object sender, EventArgs e)
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
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Seleccionar Imagen de Empleado";
            open.Filter = "Archivos de imagen (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string nombre_empleado = "Shakira_Pike_04800102008";
                string rutaImagen = open.FileName;
                MessageBox.Show(rutaImagen);
                Image imagen = Image.FromFile(rutaImagen);
                pb_foto_empleado.Image = imagen;
                rutaImagen = dir_proyecto + @"\Fotos\Empleados\" + nombre_empleado+".jpeg";
                imagen.Save(rutaImagen, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}
