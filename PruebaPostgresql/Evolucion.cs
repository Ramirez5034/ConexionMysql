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
    public partial class Evolucion : Form
    {
        string consulta;
        public Evolucion()
        {
            InitializeComponent();
        }

        private void Evolucion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Evolucion ORDER BY idEvolucion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string PokemonUso = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO Evolucion(Nombre, Descripcion, PokemonUso, idGeneracion) values('" + Nombre + "', '" + Descripcion + "', '" + PokemonUso + "', '" + idGeneracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string PokemonUso = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idEvolucion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Evolucion SET Nombre = '" + Nombre + "'Descripcion = '" + Descripcion + "',PokemonUso = '" + PokemonUso + "',idGeneracion = '" + idGeneracion + "' WHERE idEvolucion = " + idEvolucion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEvolucion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Evolucion SET Estatus = 0 WHERE idEvolucion =  " + idEvolucion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Exclusivo ex = new Exclusivo();
            ex.Show();
            this.Hide();
        }
    }
}
