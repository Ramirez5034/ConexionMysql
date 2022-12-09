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
    public partial class Manga : Form
    {
        string consulta;
        public Manga()
        {
            InitializeComponent();
        }

        private void Manga_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Manga ORDER BY idManga");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string FechaSalida = textBox2.Text;
            string Numero = textBox3.Text;
            string idGeneracion = textBox4.Text;
            string idGuion = textBox5.Text;
            consulta = "INSERT INTO Manga(Nombre, FechaSalida, Numero, idGeneracion, idGuion) values('" + Nombre + "', '" + FechaSalida + "', '" + Numero + "', '" + idGeneracion + "', '" + idGuion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string FechaSalida = textBox2.Text;
            string Numero = textBox3.Text;
            string idGeneracion = textBox4.Text;
            string idGuion = textBox5.Text;
            int idManga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Manga SET Nombre = '" + Nombre + "'FechaSalida = '" + FechaSalida + "',Numero = '" + Numero + "',idGeneracion = '" + idGeneracion + "',idGuion = '" + idGuion + "' WHERE idManga = " + idManga.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idManga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Manga SET Estatus = 0 WHERE idManga =  " + idManga.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Mecanica mec = new Mecanica();
            mec.Show();
            this.Hide();
        }
    }
}
