using CajaDiseño;
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
using System.Security.Cryptography;
using System.Text;

namespace CajaDiseño
{
    public partial class LogIn : Window
    {

        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();

        public LogIn()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            long ced;
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Llene los campos e intentelo de nuevo");
            }
            else if (long.TryParse(txtUser.Text, out ced))
            {
                LoginEmpleadoRequest request = new LoginEmpleadoRequest();
                request.cedula = txtUser.Text;
                request.hash_password = HashPassword(txtPass.Text);
                LoginEmpleadoResponse response = new LoginEmpleadoResponse();
                response = ws.VerificarLoginEmpleado(request);
                if (response.resultado)
                {
                    ObtenerEmpleadoCoindicanResponses obtenerEmpleado = new ObtenerEmpleadoCoindicanResponses();
                    obtenerEmpleado = ws.ObtenerEmpleadoCoindican(null, txtUser.Text, null);
                    Empleado empleado = new Empleado();
                    empleado = obtenerEmpleado.empleados[0];
                     MainWindow main = new MainWindow();
                    Application.Current.Properties["emp"] = empleado;
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Las credenciales no son correctas, intentelo nuevamente");
                }
            }
            else
            {
                MessageBox.Show("Ingrese una Cedula Valida e Intentelo de Nuevo");
            }


        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox.Content = "Remember Me";
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox.Content = "Remember Me";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
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
