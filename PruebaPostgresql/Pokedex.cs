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
    public partial class Pokedex : Form
    {
        string consulta;
        public Pokedex()
        {
            InitializeComponent();
        }

        private void Pokedex_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Pokedex ORDER BY idPokedex");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Diseño = textBox1.Text;
            string NumeroPokemon = textBox2.Text;
            string Descripcion = textBox3.Text;
            consulta = "INSERT INTO Pokedex(Diseño, NumeroPokemon, Descripcion) values('" + Diseño + "', '" + NumeroPokemon + "', '" + Descripcion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Diseño = textBox1.Text;
            int idPokedex = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Pokedex SET Diseño = '" + Diseño + "' WHERE idPokeball = " + idPokedex.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPokedex = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Pokedex SET Estatus = 0 WHERE idPokedex =  " + idPokedex.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Pagina pg = new Pagina();
            pg.Show();
            this.Hide();
        }
    }
}
