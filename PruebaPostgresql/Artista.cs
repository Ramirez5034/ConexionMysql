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
    public partial class Artista : Form
    {
        string consulta;
        public Artista()
        {
            InitializeComponent();
        }

        private void Artista_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Artista ORDER BY idArtista");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string ciudad = textBox3.Text;
            string Calle = textBox6.Text;
            string CURP = textBox5.Text;
            string CP = textBox4.Text;
            string idGeneracion = textBox7.Text;
            consulta = "INSERT INTO Artista(Numero, Nombre, Ciudad, Calle, CURP, CP) values('" + Nombre + "', '" + Numero + "', '" + ciudad + "' '" + Calle + "', '" + CURP + "', '" + CP + "', '" + idGeneracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string ciudad = textBox3.Text;
            string Calle = textBox6.Text;
            string CURP = textBox5.Text;
            string CP = textBox4.Text;
            string idGeneracion = textBox7.Text;
            int idArtista = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Estudio SET nombre = '" + Nombre + "', Numero ='" + Numero + "', Ciudad= '" + ciudad + "', Calle ='" + Calle + "', CURP = '" + CURP + "', CP ='" + CP + "' WHERE idEstudio = " + idArtista.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idArtista = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Artista SET Estatus = 0 WHERE idArtista =  " + idArtista.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Videojuego vd = new Videojuego();
            vd.Show();
            this.Hide();
        }
    }
}
