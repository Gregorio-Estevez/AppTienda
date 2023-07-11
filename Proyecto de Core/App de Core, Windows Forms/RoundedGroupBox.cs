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
    public partial class RoundedGroupBox : UserControl
    {
        public RoundedGroupBox()
        {
            InitializeComponent();
        }
        private int borderRadius = 0;

        public int BorderRadius { get => borderRadius; set 
            {
                if(value>=0)
                {
                    borderRadius = value;
                    this.Invalidate();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
