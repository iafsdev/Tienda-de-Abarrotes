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
    public partial class frmCompras : Form
    {
        public double Total = 0;
        int piezas;
        int precioUnitario;
        int valorTotal;

        public frmCompras()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.bancosTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Bancos);
            this.cajaTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Caja);
            this.comprasTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Compras);
            this.inventarioTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Inventario);

            LblFecha.Text = DateTime.Now.ToLongDateString();
            Lbl2.Text = " ";
            Lbl4.Text = " ";
            rdbCaja.Checked = true;

        }

        private void CBProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnTtl_Click(object sender, EventArgs e)
        {
            this.inventarioTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Inventario);
            this.comprasTableAdapter.Insertar(Convert.ToDateTime(LblFecha.Text), Convert.ToDecimal(Lbl4.Text));
            this.comprasTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Compras);

            if (rdbCaja.Checked == true)
            {
                this.cajaTableAdapter.Insertar(Convert.ToDateTime(LblFecha.Text), Convert.ToDecimal(Lbl4.Text)*-1);
                this.cajaTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Caja);
            }
            else if (rdbBancos.Checked == true)
            {
                this.bancosTableAdapter.Insertar(Convert.ToDateTime(LblFecha.Text), Convert.ToDecimal(Lbl4.Text)*-1);
                this.bancosTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Bancos);
            }

            this.Close();
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LblFecha_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnAc_Click(object sender, EventArgs e)
        {

            if (TxtValor.Text == "" || TxtPiezas.Text == "") { MessageBox.Show("Porfavor llene los datos"); }
            double Val = Convert.ToDouble(TxtValor.Text);
            double Pza = Convert.ToDouble(TxtPiezas.Text);
            Total = Total + (Val * Pza);
            string strTotal = Convert.ToString(Total);
            Lbl4.Text = strTotal;

            this.inventarioTableAdapter.Buscar(tiendaDeAbarrotesDataSet.Inventario, TxtProducto.Text);
            
            piezas = Convert.ToInt32(dgvInventario.CurrentRow.Cells[2].Value.ToString());
            piezas = piezas + Convert.ToInt32(TxtPiezas.Text);
            precioUnitario = Convert.ToInt32(dgvInventario.CurrentRow.Cells[3].Value.ToString());
            valorTotal = piezas * precioUnitario;
            this.inventarioTableAdapter.ModificarPiezas(piezas, valorTotal, TxtProducto.Text);
            this.inventarioTableAdapter.Fill(this.tiendaDeAbarrotesDataSet.Inventario);

            TxtProducto.Text = "";
            TxtPiezas.Text = "";
            TxtValor.Text = "";
        }

        private void TxtProducto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            this.Close();
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
