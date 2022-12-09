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
    public partial class Temporada : Form
    {
        string consulta;
        public Temporada()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Temporada_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Temporada ORDER BY idTemporada");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Fechasalida = textBox3.Text;
            string Fechafinal = textBox4.Text;
            string idVideojuego = textBox5.Text;
            consulta = "INSERT INTO Temporada(Nombre, Numero, Fechasalida, Fechafinal, idDesarrollador) values('" + Nombre + "', '" + Numero + "', '" + Fechasalida + "', '" + Fechafinal + "', '" + idVideojuego + "')";
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
            string Numero = textBox2.Text;
            string Fechasalida = textBox3.Text;
            string Fechafinal = textBox4.Text;
            string idVideojuego = textBox5.Text;
            int idTemporada = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Temporada SET Nombre = '" + Nombre+ "'Numero = '" + Numero + "',Fechasalida = '" + Fechasalida + "',Fechafinal = '" + Fechafinal + "',idVideojuego = '" + idVideojuego + "' WHERE idTemporada = " + idTemporada.ToString();
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

            int idTemporada = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Temporada SET Estatus = 0 WHERE idTemporada =  " + idTemporada.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Transmisión tran = new Transmisión();
            tran.Show();
            this.Hide();
        }
    }
}
