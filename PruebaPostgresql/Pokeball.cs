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
    public partial class Pokeball : Form
    {
        string consulta;
        public Pokeball()
        {
            InitializeComponent();
        }

        private void Pokeball_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Pokeball ORDER BY idPokeball");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Precio = textBox2.Text;
            string Descripcion = textBox3.Text;
            consulta = "INSERT INTO Pokeball(Nombre, Precio, Descripcion) values('" + Nombre + "', '" + Precio + "', '" + Descripcion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            String Nombre = textBox1.Text;
            int idPokeball = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Pokeball SET Nombre = '" + Nombre + "' WHERE idPokeball = " + idPokeball.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPokeball = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Pokeball SET Estatus = 0 WHERE idPokeball =  " + idPokeball.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Pokedex pkx = new Pokedex();
            pkx.Show();
            this.Hide();
        }
    }
}
