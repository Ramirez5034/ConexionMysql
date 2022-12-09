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
    public partial class AnimeEspecial : Form
    {
        string consulta;
        public AnimeEspecial()
        {
            InitializeComponent();
        }

        private void AnimeEspecial_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM AnimeEspecial ORDER BY idAnimeEspecial");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idAnime = textBox1.Text;
            string idEspecial = textBox4.Text;
            consulta = "INSERT INTO AnimeEspecial(idAnime, idEspecial) values('" + idAnime + "','" + idEspecial + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idAnime = textBox1.Text;
            string idEspecial = textBox4.Text;
            int idAnimeEspecial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE AnimeEspecial SET idAnime = '" + idAnime + "',idEspecial = '" + idEspecial + "' WHERE idAnimeEspecial = " + idAnimeEspecial.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAnimeEspecial = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE AnimeEspecial SET 0 = False WHERE idAnimeEspecial =  " + idAnimeEspecial.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            AnimePelicula ape = new AnimePelicula();
            ape.Show();
            this.Hide();
        }
    }
}
