﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tienda_de_Abarrotes
{
    public partial class frmMovimientos : Form
    {
        public frmMovimientos()
        {
            InitializeComponent();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (rdbVenta.Checked == true)
            {
                this.Hide();
                frmVentas frmVentas = new frmVentas();
                frmVentas.Show();
            }
            else if (rdbCompra.Checked == true)
            {
                this.Hide();
                frmCompras frmCompras = new frmCompras();
                frmCompras.Show();
            }
        }
    }
}
