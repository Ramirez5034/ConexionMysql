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
    public partial class Exclusivo : Form
    {
        string consulta;
        public Exclusivo()
        {
            InitializeComponent();
        }

        private void Exclusivo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Exclusivo ORDER BY idExclusivo");
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string FechaDisponibilidad = textBox3.Text;
            string idVideojuego = textBox4.Text;
            consulta = "INSERT INTO Exclusivo(Nombre, Descripcion, FechaDisponibilidad, idVideojuego) values('" + Nombre + "', '" + Descripcion + "', '" + FechaDisponibilidad + "', '" + idVideojuego + "')";
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
            string Descripcion = textBox2.Text;
            string FechaDisponibilidad = textBox3.Text;
            string idVideojuego = textBox4.Text;
            int idExclusivo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Exclusivo SET Nombre = '" + Nombre + "'Descripcion = '" + Descripcion + "',FechaDisponibilidad = '" + FechaDisponibilidad + "',idVideojuego = '" + idVideojuego + "' WHERE idExclusivo = " + idExclusivo.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idExclusivo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Exclusivo SET Estatus = 0 WHERE idExclusivo =  " + idExclusivo.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            FanGame fan = new FanGame();
            fan.Show();
            this.Hide();
        }
    }
}
