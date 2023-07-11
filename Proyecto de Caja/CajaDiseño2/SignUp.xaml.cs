using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;


namespace CajaDiseño
{
    public partial class SignUp : Window


    {

        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();

        string ruta_foto;
        string dir_proyecto = Directory.GetParent(Directory.GetParent(Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName).FullName).FullName;
        public SignUp()
        {
            InitializeComponent();

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado();
            empleado.nombre = txtName.Text;
            empleado.apellido = txtLastName.Text;
            empleado.tipo_empleado = new Categoria_Empleado();
            empleado.email = txtEmail.Text;
            empleado.cedula = txtCedula.Text;
            empleado.salario = decimal.Parse(txtSalario.Text);
            empleado.fecha_nac = DateTime.Parse(dpBirthday.Text);
            empleado.num_telefono = txtPhone.Text;
            empleado.sucursal = new Sucursales();
            empleado.estado = new Estados();
            empleado.direccion = txtAddress.Text;
            Categoria_Empleado catemp = (Categoria_Empleado)Cb_Categoria_Empleado.SelectedItem;
            Estados est = (Estados)Cb_Estado1.SelectedItem;
            Sucursales suc = (Sucursales)Cb_Sucursal.SelectedItem;
            empleado.estado.id_estado = est.id_estado;
            empleado.tipo_empleado.id_categoria = catemp.id_categoria;
            empleado.tipo_empleado.id_categoria = catemp.id_categoria;
            empleado.sucursal.id_sucursal = suc.id_sucursal;
            empleado.ruta_foto = @"\Fotos\Empleados\" + empleado.nombre + empleado.apellido + ".jpeg";


            BitmapImage bitmapImage = new BitmapImage(new Uri(ruta_foto));

            // Crear una instancia de JpegBitmapEncoder para codificar la imagen como JPEG
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.QualityLevel = 80; // Establecer la calidad de la imagen
            ruta_foto = dir_proyecto + empleado.ruta_foto;
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

            //Crear un cuadro de diálogo SaveFileDialog para que el usuario elija la ubicación y el nombre del archivo a guardar

            // Guardar la imagen en el archivo seleccionado por el usuario
            using (FileStream fileStream = new FileStream(ruta_foto, FileMode.Create))
            {
                encoder.Save(fileStream);
            }

            RegistrarEmpleadoResponses respuesta = new RegistrarEmpleadoResponses();
            respuesta = ws.RegistrarEmpleado(empleado);


           Info_Login credenciales = new Info_Login();
            string Hashpass = HashPassword(txtPassword.Text);
            credenciales.cedula_email = empleado.cedula;
            credenciales.hash_password = Hashpass;

            if (ws.RegistrarInfoRegistroEmpleados(credenciales))
            {
                LogIn log = new LogIn();
                log.Show();
                this.Close();
            }
            else
            {
                txtName.Name = "NO HECHO";
            }





            //LogIn logIn = new LogIn();
            //logIn.Show();
            //this.Close();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPosition_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dpBirthday_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPhone.Text))
            {
                if (!Regex.IsMatch(txtPhone.Text, @"^[0-9]+$"))
                {
                    txtPhone.BorderBrush = Brushes.Red;
                    btnSignUp.IsEnabled = false;
                }
                else
                {
                    txtPhone.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#2D2A32");
                    btnSignUp.IsEnabled = true;
                }
            }
            else
            {
                txtPhone.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFromString("#2D2A32");
                btnSignUp.IsEnabled = false;
            }
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ObtenerEstadosResponses respuesta = ws.ObtenerEstados(true);
            Cb_Estado1.ItemsSource = respuesta.estados;
            Cb_Estado1.DisplayMemberPath = "nombre_estado";
            ObtenerCategoriaEmpleadoResponses responses = ws.ObtenerCategoriaEmpleado(true);
            Cb_Categoria_Empleado.ItemsSource = responses.categoria;
            Cb_Categoria_Empleado.DisplayMemberPath = "nombre_categoria";
            ObtenerSucursalesResponses resp = ws.ObtenerSucursales(true);
            Cb_Sucursal.ItemsSource = resp.sucursales;
            Cb_Sucursal.DisplayMemberPath = "nombre_sucursal";
        }

        private void btnBuscatFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            ruta_foto = ofd.FileName;
            txtFotos.Text = ruta_foto;
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
