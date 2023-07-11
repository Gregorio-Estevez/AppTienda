using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using App_de_Core__Windows_Forms.SR;

namespace App_de_Core__Windows_Forms
{
    public partial class Form_Registro_de_Empleado : Form
    {
        public Form_Registro_de_Empleado()
        {
            InitializeComponent();
        }
        WebServiceCoreSoapClient ws = new WebServiceCoreSoapClient();
        private void Form_Registro_de_Empleado_Load(object sender, EventArgs e)
        {
          

        }

        private void botonPersonalizado2_Click(object sender, EventArgs e)
        {
            ObtenerTipoEstadosResponses respuesta = ws.ObtenerTipoEstados(true);
            cbEstado.DataSource = respuesta.tipo_Estados;
            cbEstado.DisplayMember = "descripcion";
        }
    }
}
