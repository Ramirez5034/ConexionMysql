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
    public partial class AnimePelicula : Form
    {
        string consulta;
        public AnimePelicula()
        {
            InitializeComponent();
        }

        private void AnimePelicula_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM AnimePelicula ORDER BY idAnimePelicula");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idAnime = textBox1.Text;
            string idPelicula = textBox4.Text;
            consulta = "INSERT INTO AnimePelicula(idAnime, idPelicula) values('" + idAnime + "','" + idPelicula + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idAnime = textBox1.Text;
            string idPelicula = textBox4.Text;
            int idAnimePelicula = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE AnimePelicula SET idAnime = '" + idAnime + "',idPelicula = '" + idPelicula + "' WHERE idAnimePelicula = " + idAnimePelicula.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAnimePelicula = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE AnimePelicula SET Estatus = 0 WHERE idAnimePelicula =  " + idAnimePelicula.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ConsolaContro cc = new ConsolaContro();
            cc.Show();
            this.Hide();
        }
    }
}
