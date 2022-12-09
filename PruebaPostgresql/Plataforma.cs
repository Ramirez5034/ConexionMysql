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
    public partial class Plataforma : Form
    {
        string consulta;
        public Plataforma()
        {
            InitializeComponent();
        }

        private void Plataforma_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Plataforma ORDER BY idPlataforma");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string numero = textBox2.Text;
            string Capacidad = textBox3.Text;
            consulta = "INSERT INTO Plataforma(Nombre, Numero, Capacidad) values('" + Nombre + "', '" + numero + "', '" + Capacidad + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Nombre = textBox1.Text;
            int idPlataforma = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Plataforma SET Nombre = '" + Nombre + "' WHERE idPlataforma = " + idPlataforma.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPlataforma = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Plataforma SET Estatus = 0 WHERE idPlataforma =  " + idPlataforma.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Pokeball pk = new Pokeball();
            pk.Show();
            this.Hide();
        }
    }
}
