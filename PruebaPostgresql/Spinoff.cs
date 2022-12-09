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
    public partial class Spinoff : Form
    {
        string consulta;
        public Spinoff()
        {
            InitializeComponent();
        }

        private void Spinoff_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Spinoff ORDER BY idSpinoff");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Ventas = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO Spinoff(Nombre, Numero, Ventas, idGeneracion) values('" + Nombre + "', '" + Numero + "', '" + Ventas + "', '" + idGeneracion + "')";
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
            string Ventas = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idSpinoff = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Spinoff SET Nombre = '" + Nombre + "'Numero = '" + Numero + "',Ventas = '" + Ventas + "',idGeneracion = '" + idGeneracion + "' WHERE idSpinoff = " + idSpinoff.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSpinoff = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Spinoff SET Estatus = 0 WHERE idSpinoff =  " + idSpinoff.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Zona zon = new Zona();
            zon.Show();
            this.Hide();
        }
    }
}
