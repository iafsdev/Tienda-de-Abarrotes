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
    public partial class frmVentas : Form
    {
        int valorTotal;
        int ventaTotal;

        public frmVentas()
        {
            InitializeComponent();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tiendaDeAbarrotesDataSet.Inventario' Puede moverla o quitarla según sea necesario.
            this.inventarioTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Inventario);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.inventarioTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Inventario);
            this.inventarioTableAdapter.Buscar(this.tiendaDeAbarrotesDataSet.Inventario, txbProducto.Text);
            int piezas = Convert.ToInt32(dgvInventario.CurrentRow.Cells[2].Value.ToString()) - Convert.ToInt32(txbPiezas.Text);
            int precio = Convert.ToInt32(dgvInventario.CurrentRow.Cells[3].Value.ToString());
            ventaTotal = ventaTotal + (Convert.ToInt32(txbPiezas.Text) * precio);
            valorTotal = piezas * precio;
            this.inventarioTableAdapter.ModificarPiezas(piezas, Convert.ToDecimal(valorTotal), txbProducto.Text);

            txbProducto.Text = "";
            txbPiezas.Text = "";
            lblValorTotal.Text = Convert.ToString(ventaTotal);

            this.inventarioTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Inventario);
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }
    }
}
