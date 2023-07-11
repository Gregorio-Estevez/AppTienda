using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion_de_Core_WinForms.SR;

namespace Aplicacion_de_Core_WinForms
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

        }

        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();

        private void label4_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            Form_Registro_de_Empleado form = new Form_Registro_de_Empleado();
            this.Visible = false;
            form.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //long ced;
            //if (txbCedula.Texts == "" || txbContrasena.Texts == "")
            //{
            //    MessageBox.Show("Llene los campos e intentelo de nuevo");
            //}
            //else if (long.TryParse(txbCedula.Texts, out ced))
            //{
            //    LoginEmpleadoRequest request = new LoginEmpleadoRequest();
            //    request.cedula = txbCedula.Texts;
            //    request.hash_password = HashPassword(txbContrasena.Texts);
            //    LoginEmpleadoResponse responses = new LoginEmpleadoResponse();
            //    responses = ws.VerificarLoginEmpleado(request);
            //    if (responses.resultado)
            //    {
                    ObtenerEmpleadoCoindicanResponses obtenerEmpleado = new ObtenerEmpleadoCoindicanResponses();
                    obtenerEmpleado = ws.ObtenerEmpleadoCoindican(null, txbCedula.Texts, null);
                    Empleado empleado = new Empleado();
                    empleado = obtenerEmpleado.empleados[0];
                    this.TopMost = false;
                    this.Visible = false;
                    Form_de_Manejo_de_Proveedores_Inicialcs form = new Form_de_Manejo_de_Proveedores_Inicialcs(empleado);
                    form.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Las credenciales no son correctas, intentelo nuevamente");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ingrese una Cedula Valida e Intentelo de Nuevo");
            //}
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
