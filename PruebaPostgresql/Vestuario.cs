using PruebaMySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaPostgresql
{
    public partial class Vestuario : Form
    {
        string consulta;
        public Vestuario()
        {
            InitializeComponent();
        }

        private void Vestuario_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Vestuario ORDER BY idVestuario");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string Diseño = textBox3.Text;
            consulta = "INSERT INTO Vestuario(Nombre, Numero, Diseño) values('" + Nombre + "', '" + Numero + "', '" + Diseño + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            int idVestuario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Skin SET Nombre = '" + Nombre + "' WHERE idVestuario = " + idVestuario.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idVestuario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Vestuario SET Estatus = 0 WHERE idVestuario =  " + idVestuario.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Generacion gen = new Generacion();
            gen.Show();
            this.Hide();
        }
    }
}
