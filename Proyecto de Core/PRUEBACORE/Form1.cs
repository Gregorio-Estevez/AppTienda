using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PRUEBACORE.SR;

namespace PRUEBACORE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            ObtenerProveedoresResponses response = new ObtenerProveedoresResponses();
            response = ws.ObtenerProveedores(true);
            comboBox1.DataSource = response.proveedores;
            comboBox1.DisplayMember = "nombre";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proveedores estadoseleccionado = (Proveedores)comboBox1.SelectedItem;
            label1.Text= estadoseleccionado.rnc;
        }
    }
}
