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
    public partial class Especial : Form
    {
        string consulta;
        public Especial()
        {
            InitializeComponent();
        }

        private void Especial_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Especial ORDER BY idEspecial");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Sipnosis = textBox3.Text;
            consulta = "INSERT INTO Especial(Nombre, Numero, Sipnosis) values('" + Nombre + "', '" + Numero + "', '" + Sipnosis + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Nombre = textBox1.Text;
            int idEspecial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Especial SET nombre = '" + Nombre + "' WHERE idEspecial = " + idEspecial.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEspecial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Episodio SET Estatus = 0 WHERE idEpisodio =  " + idEspecial.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Evento ev = new Evento();
            ev.Show();
            this.Hide();
        }
    }
}
