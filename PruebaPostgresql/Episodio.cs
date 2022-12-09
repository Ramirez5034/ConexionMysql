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
    public partial class Episodio : Form
    {
        string consulta;
        public Episodio()
        {
            InitializeComponent();
        }

        private void Episodio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Episodio ORDER BY idEpisodio");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Sipnosis = textBox3.Text;
            consulta = "INSERT INTO Episodio(Nombre, Numero, Sipnosis) values('" + Nombre + "', '" + Numero + "', '" + Sipnosis + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Nombre = textBox1.Text;
            int idEpisodio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Entrenador SET nombre = '" + Nombre + "' WHERE idEpisodio = " + idEpisodio.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEpisodio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Episodio SET Estatus = 0 WHERE idEpisodio =  " + idEpisodio.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            Especial es = new Especial();
            es.Show();
            this.Hide();
        }
    }
}
