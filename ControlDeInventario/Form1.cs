﻿/*
 *  Creado por Alan Francisco Sánchez Cazarez
 */

using System;
using System.Windows.Forms;

namespace ControlDeInventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Inventario inventario;

        private void Form1_Load(object sender, EventArgs e)
        {
            inventario = new Inventario();
        }

        private void limpiarCajasDeTexto()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto(txtCodigo.Text, txtNombre.Text, int.Parse(txtCantidad.Text), double.Parse(txtPrecio.Text));
            if (!inventario.agregar(producto))
                MessageBox.Show("Inventario lleno.");

            limpiarCajasDeTexto();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtReporte.Text = "";
            txtReporte.Text = inventario.reporte();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto producto = inventario.busqueda(txtCodigo.Text);
            if (producto == null)
            {
                MessageBox.Show("No existe.");
            }
            else
            {
                txtNombre.Text = producto.nombre;
                txtCantidad.Text = producto.cantidad.ToString();
                txtPrecio.Text = producto.precio.ToString();
            }            
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            inventario.eliminar(txtCodigo.Text);
            limpiarCajasDeTexto();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int indice = int.Parse(txtPosicion.Text);
            Producto p = new Producto(txtCodigo.Text, txtNombre.Text, int.Parse(txtCantidad.Text), double.Parse(txtPrecio.Text));

            if (inventario.insertar(p, indice-1))
            {
                limpiarCajasDeTexto();
            }
            else
            {
                MessageBox.Show("No hay espacio.");
            }
        }
    }
}
