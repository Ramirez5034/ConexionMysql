using PruebaMySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaPostgresql
{
    public partial class Imprenta : Form
    {
        string consulta;
        public Imprenta()
        {
            InitializeComponent();
        }

        private void Imprenta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Desarrollador ORDER BY idDesarrollador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string ciudad = textBox3.Text;
            string Calle = textBox1.Text;
            string Telefono = textBox2.Text;
            string CP = textBox3.Text;
            consulta = "INSERT INTO Imprenta(Numero, Nombre, Fecha) values('" + Nombre + "', '" + Numero + "', '" + ciudad + "' '" + Calle + "', '" + Telefono + "', '" + CP + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Numero = textBox2.Text;
            int idImprenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Imprenta SET Numero = '" + Numero + "' WHERE idImprenta = " + idImprenta.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idImprenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Imprenta SET Imprenta = 0 WHERE idImprenta =  " + idImprenta.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Membresia mem = new Membresia();
            mem.Show();
            this.Hide();
        }
    }
}
