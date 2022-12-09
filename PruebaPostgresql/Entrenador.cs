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
    public partial class Entrenador : Form
    {
        string consulta;
        public Entrenador()
        {
            InitializeComponent();
        }

        private void Entrenador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Entrenador ORDER BY idEntrenador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string CantidadPokemon = textBox2.Text;
            string Tipo = textBox3.Text;
            consulta = "INSERT INTO Entrenador(Nombre, CantidadPokemon, Tipo) values('" + Nombre + "', '" + CantidadPokemon + "', '" + Tipo + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Nombre = textBox1.Text;
            int idEntrenador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Entrenador SET numero = '" + Nombre + "' WHERE idEntrenador = " + idEntrenador.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEntrenador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Entrenador SET Estatus = 0 WHERE idEntrenador =  " + idEntrenador.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Episodio ep = new Episodio();
            ep.Show();
            this.Hide();
        }
    }
}
