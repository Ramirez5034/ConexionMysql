using PruebaMySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaPostgresql
{
    public partial class Compra : Form
    {
        string consulta;
        public Compra()
        {
            InitializeComponent();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Compra ORDER BY idCompra");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Codigo = textBox1.Text;
            string Fecha = textBox2.Text;
            string MetodoPago = textBox3.Text;
            string idJugador = textBox4.Text;
            consulta = "INSERT INTO Compra(Codigo, Fecha, MetodoPago, idJugador) values('" + Codigo + "', '" + Fecha + "', '" + MetodoPago + "', '" + idJugador + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Codigo = textBox1.Text;
            string Fecha = textBox2.Text;
            string MetodoPago = textBox3.Text;
            string idJugador = textBox4.Text;
            int idCompra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Compra SET Codigo = '" + Codigo + "'Fecha = '" + Fecha + "',MetodoPago = '" + MetodoPago + "',idJugador = '" + idJugador + "' WHERE idCompra = " + idCompra.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCompra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Compra SET Estatus = 0 WHERE idCompra =  " + idCompra.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Doblaje dob = new Doblaje();
            dob.Show();
            this.Hide();
        }
    }
}
