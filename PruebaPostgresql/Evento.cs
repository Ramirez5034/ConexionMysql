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
    public partial class Evento : Form
    {
        string consulta;
        public Evento()
        {
            InitializeComponent();
        }

        private void Evento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Evento ORDER BY idEvento");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Numero = textBox1.Text;
            string Nombre = textBox2.Text;
            string Fecha = textBox3.Text;
            consulta = "INSERT INTO Evento(Numero, Nombre, Fecha) values('" + Numero + "', '" + Nombre + "', '" + Fecha + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Numero = textBox1.Text;
            int idEvento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Evento SET numero = '" + Numero + "' WHERE idEvento = " + idEvento.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEvento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Evento SET Estatus = 0 WHERE idEvento =  " + idEvento.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Estudio est = new Estudio();
            est.Show();
            this.Hide();
        }
    }
}
