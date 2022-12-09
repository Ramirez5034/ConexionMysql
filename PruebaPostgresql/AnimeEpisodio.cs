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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PruebaPostgresql
{
    public partial class AnimeEpisodio : Form
    {
        String consulta;
        public AnimeEpisodio()
        {
            InitializeComponent();
        }

        private void AnimeEpisodio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM AnimeEpisodio ORDER BY idAnimeEpisodio");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idAnime = textBox1.Text;
            string idEpisodio = textBox4.Text;
            consulta = "INSERT INTO AnimeEpisodio(idAnime, idEpisodio) values('" + idAnime + "','" + idEpisodio + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idAnime = textBox1.Text;
            string idEpisodio = textBox4.Text;
            int idAnimeEpisodio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE AnimeEpisodio SET idAnime = '" + idAnime + "',idEpisodio = '" + idEpisodio + "' WHERE idAnimeEpisodio = " + idAnimeEpisodio.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAnimeEpisodio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE AnimeEpisodio SET Estatus = 0 WHERE idAnimeEpisodio =  " + idAnimeEpisodio.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            AnimeEspecial ane = new AnimeEspecial();
            ane.Show();
            this.Hide();
        }
    }
}
