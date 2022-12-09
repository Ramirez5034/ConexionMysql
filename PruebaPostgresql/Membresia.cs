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
    public partial class Membresia : Form
    {
        string consulta;
        public Membresia()
        {
            InitializeComponent();
        }

        private void Membresia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Membresia ORDER BY idMembresia");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Precio = textBox1.Text;
            string FechaSalida = textBox2.Text;
            string Numero = textBox3.Text;
            consulta = "INSERT INTO Membresia(Precio, FechaSalida, Numero) values('" + Precio + "', '" + FechaSalida + "', '" + Numero + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Precio = textBox1.Text;
            int idMembresia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Membresia SET Precio = '" + Precio + "' WHERE idMembresia = " + idMembresia.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMembresia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Membresia SET Estatus = 0 WHERE idMembresia =  " + idMembresia.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Mercancia merc = new Mercancia();
            merc.Show();
            this.Hide();
        }
    }
}
