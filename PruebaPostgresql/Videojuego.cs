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
    public partial class Videojuego : Form
    {
        string consulta;
        public Videojuego()
        {
            InitializeComponent();
        }

        private void Videojuego_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Videojuego ORDER BY idVideojuego");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string FechaSalida = textBox1.Text;
            string Nombre = textBox2.Text;
            string CopiasVendidas = textBox3.Text;
            string idGeneracion = textBox4.Text;
            string idDesarrollador= textBox5.Text;
            consulta = "INSERT INTO Videojuego(FechaSalida, Nombre, CopiasVendidas, idGeneracion, idDesarrollador) values('" + FechaSalida + "', '" + Nombre + "', '" + CopiasVendidas + "', '" + idGeneracion + "', '" + idDesarrollador + "')";
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
            string FechaSalida = textBox1.Text;
            string Nombre = textBox2.Text;
            string CopiasVendidas = textBox3.Text;
            string idGeneracion = textBox4.Text;
            string idDesarrollador = textBox5.Text;
            int idVideojuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Videojuego SET FechaSalida = '" + FechaSalida + "'Nombre = '" + Nombre + "',CopiasVendidas = '" + CopiasVendidas + "',idGeneracion = '" + idGeneracion + "',idDesarrollador = '" + idDesarrollador + "' WHERE idVideojuego = " + idVideojuego.ToString();
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
            int idVideojuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Videojuego SET Estatus = 0 WHERE idVideojuego =  " + idVideojuego.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Temporada temp = new Temporada();
            temp.Show();
            this.Hide();
        }
    }
}
