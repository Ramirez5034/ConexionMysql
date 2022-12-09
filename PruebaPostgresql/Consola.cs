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
    public partial class Consola : Form
    {
        string consulta;
        public Consola()
        {
            InitializeComponent();
        }

        private void Consola_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Consola ORDER BY idConsola");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string Precio = textBox2.Text;
            string diseño = textBox3.Text;
            consulta = "INSERT INTO Consola (numero, precio, diseño) values('" + numero + "', '" + Precio + "', '" + diseño + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String numero = textBox1.Text;
            string precio = textBox2.Text;
            string diseño = textBox3.Text;
            int idConsola = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Consola SET numero = '" + numero + "', precio ='" + precio + "', diseño= '" + diseño + "' WHERE idConsola = " + idConsola.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idConsola = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Consola SET Estatus = 0 WHERE idConsola = " + idConsola.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contro contro = new Contro();
            contro.Show();
        }
    }
}
