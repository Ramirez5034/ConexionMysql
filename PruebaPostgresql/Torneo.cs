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
    public partial class Torneo : Form
    {
        string consulta;
        public Torneo()
        {
            InitializeComponent();
        }

        private void Torneo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Torneo ORDER BY idTorneo");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Participantes = textBox2.Text;
            string Premio = textBox3.Text;
            consulta = "INSERT INTO Torneo(Nombre, Participantes, Premio) values('" + Nombre + "', '" + Participantes + "', '" + Premio + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Nombre = textBox1.Text;
            int idTorneo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Skin SET Nombre = '" + Nombre + "' WHERE idTorneo = " + idTorneo.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTorneo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Torneo SET Estatus = 0 WHERE idTorneo =  " + idTorneo.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Vestuario vs = new Vestuario();
            vs.Show();
            this.Hide();
        }
    }
}
