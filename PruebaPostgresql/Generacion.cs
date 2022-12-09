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
    public partial class Generacion : Form
    {
        string consulta;
        public Generacion()
        {
            InitializeComponent();
        }

        private void Generacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Generacion ORDER BY idGeneracion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Fechasalida = textBox1.Text;
            string Numero = textBox2.Text;
            string Descripción = textBox3.Text;
            string idPokedex = textBox4.Text;
            consulta = "INSERT INTO Generacion(Fechasalida, Numero, Descripción, idPokedex) values('" + Fechasalida + "', '" + Numero + "', '" + Descripción + "', '" + idPokedex + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string FechaSalida = textBox1.Text;
            int idGeneracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Generacion SET FechaSalida = '" + FechaSalida + "' WHERE idGeneracion = " + idGeneracion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGeneracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Generacion SET Estatus = 0 WHERE idGeneracion =  " + idGeneracion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            tienda tn = new tienda();
            tn.Show();
            this.Hide();
        }
    }
}
