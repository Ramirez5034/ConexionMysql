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
    public partial class Enlinea : Form
    {
        string consulta;
        public Enlinea()
        {
            InitializeComponent();
        }

        private void Enlinea_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Enlinea ORDER BY idEnlinea");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Numero = textBox1.Text;
            string host = textBox2.Text;
            string personas = textBox3.Text;
            consulta = "INSERT INTO Objeto(Nombre, Tipo, Descripción) values('" + Numero + "', '" + host + "', '" + personas + "')";

            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Numero = textBox1.Text;
            int idEnlinea = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Enlinea SET Numero = '" + Numero + "' WHERE idEnlinea = " + idEnlinea.ToString();

            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEnlinea = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Enlinea SET Estatus = 0 WHERE idEnlinea =  " + idEnlinea.ToString(); ;

            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Plataforma pl = new Plataforma();
            pl.Show();
            this.Hide();
        }
    }
}
