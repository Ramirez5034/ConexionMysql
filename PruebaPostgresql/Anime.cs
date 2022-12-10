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
    public partial class Anime : Form
    {
        string consulta;
        public Anime()
        {
            InitializeComponent();
        }

        private void Anime_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Anime ORDER BY idAnime");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string FechaInicio = textBox1.Text;
            string Nombre = textBox2.Text;
            string FechaFinalizacion = textBox3.Text;
            string idGeneracion = textBox4.Text;
            string idGuion = textBox5.Text;
            string idEstudio = textBox6.Text;
            consulta = "INSERT INTO Anime(FechaInicio, Nombre, FechaFinalizacion, idGeneracion, idGuion, idEstudio) values('" + FechaInicio + "', '" + Nombre + "', '" + FechaFinalizacion + "', '" + idGeneracion + "', '" + idGuion + "', '" +idEstudio+ "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string FechaInicio = textBox1.Text;
            string Nombre = textBox2.Text;
            string FechaFinalizacion = textBox3.Text;
            string idGeneracion = textBox4.Text;
            string idGuion = textBox5.Text;
            string idEstudio = textBox6.Text;
            int idAnime = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Anime SET FechaInicio = '" + FechaInicio + "'Nombre = '" + Nombre + "',FechaFinalizacion = '" + FechaFinalizacion + "',idGeneracion = '" + idGeneracion + "' ,idGuion = '" + idGuion + "',idEstudio = '" + idEstudio + "' WHERE idAnime = " + idAnime.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();


        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAnime = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Anime SET Estatus = 0 WHERE idAnime =  " + idAnime.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Aplicacion app = new Aplicacion();
            app.Show();
            this.Hide();
        }
    }
}
