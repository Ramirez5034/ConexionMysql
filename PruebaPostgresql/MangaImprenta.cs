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
    public partial class MangaImprenta : Form
    {
        string consulta;
        public MangaImprenta()
        {
            InitializeComponent();
        }

        private void MangaImprenta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM MangaImprenta ORDER BY idMangaImprenta");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idManga = textBox1.Text;
            string idImprenta = textBox4.Text;
            consulta = "INSERT INTO MangaImprenta(idManga, idImprenta) values('" + idManga + "','" + idImprenta + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idManga = textBox1.Text;
            string idImprenta = textBox4.Text;
            int idMangaImprenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MangaImprenta SET idManga = '" + idManga + "',idImprenta = '" + idImprenta + "' WHERE idMangaImprenta = " + idMangaImprenta.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMangaImprenta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE MangaImprenta SET Estatus = 0 WHERE idMangaImprenta =  " + idMangaImprenta.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            MercanciaPagina mp = new MercanciaPagina();
                mp.Show();
            this.Hide();
        }
    }
}
