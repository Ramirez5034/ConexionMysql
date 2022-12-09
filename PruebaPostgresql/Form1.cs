using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using PruebaMySQL;
using System.Diagnostics.Eventing.Reader;

namespace PruebaPostgresql
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Form1()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Herbarioo;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Colaboracion ORDER BY idColaboracion");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
           
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContenidoDescarga con = new ContenidoDescarga();
            con.Show();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string fecha = textBox2.Text;
            string Tipo = textBox3.Text;

            consulta = "INSERT INTO Colaboracion (numero, fecha, Tipo) values('" + numero + "', '" + fecha + "', '" + Tipo + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {

            string numero = textBox1.Text;
            string fecha = textBox2.Text;
            string Tipo = textBox3.Text;

            int idColaboracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Colaboracion SET numero = '" + numero + "',fecha = '" + fecha + "',tipo = '" + Tipo + "' WHERE idColaboracion = " + idColaboracion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            int idColaboracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Colaboracion SET Estatus = 0 WHERE idColaboracion = " + idColaboracion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
