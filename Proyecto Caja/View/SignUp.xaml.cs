using System;
using System.Collections.Generic;
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

namespace Proyecto.View
{
    public partial class SignUp : Window
    {
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

        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
