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
    public partial class Distribución : Form
    {
        string consulta;
        public Distribución()
        {
            InitializeComponent();
        }

        private void Distribución_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Distribución ORDER BY idDistribución");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Pedidos = textBox1.Text;
            string Lugares = textBox2.Text;
            string Transporte = textBox3.Text;
            consulta = "INSERT INTO Distribución(Pedidos, Lugares, Transporte) values('" + Pedidos + "', '" + Lugares + "', '" + Transporte + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Pedidos = textBox1.Text;
            int idDistribución = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Distribución SET numero = '" + Pedidos + "' WHERE idDistribución = " + idDistribución.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDistribución = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Distribución SET 0 = False WHERE idDistribución =  " + idDistribución.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Entrenador ent = new Entrenador();
            ent.Show();
            this.Hide();
        }
    }
}
