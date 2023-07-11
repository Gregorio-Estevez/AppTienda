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

        private void label4_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            Form_Registro_de_Empleado form = new Form_Registro_de_Empleado();
            this.Visible = false;
            form.ShowDialog();
            this.Show();
        }
    }
}
