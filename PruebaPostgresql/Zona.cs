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
    public partial class Zona : Form

    {
        string consulta;
        public Zona()
        {
            InitializeComponent();
        }

        private void Zona_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Zona ORDER BY idZona");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Acceso = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO Zona(Nombre, Numero, Acceso, idGeneracion) values('" + Nombre + "', '" + Numero + "', '" + Acceso + "', '" + idGeneracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Acceso = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Zona SET Nombre = '" + Nombre + "'Numero = '" + Numero + "',Acceso = '" + Acceso + "',idGeneracion = '" + idGeneracion + "' WHERE idZona = " + idZona.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idZona = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Zona SET Estatus = 0 WHERE idZona =  " + idZona.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            AnimeEpisodio An = new AnimeEpisodio();
            An.Show();
            this.Hide();
        }
    }
}
