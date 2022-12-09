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
    public partial class Expansion : Form
    {
        string consulta;
        public Expansion()
        {
            InitializeComponent();
        }

        private void Expansion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Expansion ORDER BY idExpansion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Fecha = textBox3.Text;
            consulta = "INSERT INTO Expansion(Nombre, Numero, FechaSalida) values('" + Nombre + "', '" + Numero + "', '" + Fecha + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Numero = textBox1.Text;
            int idExpansion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Expansion SET numero = '" + Numero + "' WHERE idExpansion = " + idExpansion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idExpansion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Expansion SET Estatus = 0 WHERE idExpansion =  " + idExpansion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Guion g = new Guion();
            g.Show();
            this.Hide();
        }
    }
}
