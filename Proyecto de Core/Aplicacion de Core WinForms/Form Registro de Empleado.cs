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
using System.Security.Cryptography;
using System.Text;


namespace Aplicacion_de_Core_WinForms
{
    public partial class Form_Registro_de_Empleado : Form
    {
        public Form_Registro_de_Empleado()
        {
            InitializeComponent();
        }
        string dir_proyecto = Directory.GetParent(Directory.GetParent(Application.StartupPath).FullName).FullName;
        string rutaImagen;
        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();
        private void Form_Registro_de_Empleado_Load(object sender, EventArgs e)
        {
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

        private void botonPersonalizado2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                rutaImagen = ofd.FileName;
                txbrutafoto.Texts = rutaImagen;
            }
        }

        private void botonPersonalizado3_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.nombre = txbNombre.Texts;
            empleado.apellido = txbApellido.Texts;
            empleado.cedula = txbCedula.Texts;
            empleado.email = txbemail.Texts;
            empleado.num_telefono = txbemail.Texts;
            empleado.salario = decimal.Parse(txbSalario.Texts);
            empleado.direccion = txbdireccion.Texts;
            empleado.estado = new Estados();
            empleado.tipo_empleado = new Categoria_Empleado();
            empleado.sucursal = new Sucursales();
            empleado.fecha_nac = dtpFechaNac.Value;
            Categoria_Empleado catemp = (Categoria_Empleado)cbTipoEmpleado.SelectedItem;
            Estados est = (Estados)cbEstado.SelectedItem;
            Sucursales suc = (Sucursales)cbSucursal.SelectedItem;
            empleado.estado.id_estado = est.id_estado;
            empleado.tipo_empleado.id_categoria = catemp.id_categoria;
            empleado.sucursal.id_sucursal = suc.id_sucursal;
            empleado.ruta_foto = @"\Fotos\Empleados\" + empleado.nombre + empleado.apellido + ".jpeg";

            Image imagen = Image.FromFile(rutaImagen);
            rutaImagen = dir_proyecto + empleado.ruta_foto;
            imagen.Save(rutaImagen, System.Drawing.Imaging.ImageFormat.Jpeg);
            ws.RegistrarEmpleado(empleado);

            Info_Login credenciales = new Info_Login();

            string hashpass = HashPassword(txbcontrasena.Texts);
            credenciales.cedula_email = empleado.cedula;
            credenciales.hash_password = hashpass;

            if (ws.RegistrarInfoRegistroEmpleados(credenciales))
            {
                this.Close();
            }
            else
            {
                labelPrueba.Text = "NOMILOCO";
            }
            
        }

        public static string HashPassword(string password)
        {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Convertir la contraseña en un arreglo de bytes
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convertir el arreglo de bytes en una cadena de texto en formato hexadecimal
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

}
}
