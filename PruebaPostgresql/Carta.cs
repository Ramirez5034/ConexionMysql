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
    public partial class Carta : Form
    {
        string consulta;
        public Carta()
        {
            InitializeComponent();
        }

        private void Carta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Carta ORDER BY idCarta");
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Codigo = textBox1.Text;
            string FechaCreacion = textBox2.Text;
            string Rareza = textBox3.Text;
            string idExpansion = textBox4.Text;
            consulta = "INSERT INTO Carta(Codigo, FechaCreacion, Rareza, idExpansion) values('" + Codigo + "', '" + FechaCreacion + "', '" + Rareza + "', '" + idExpansion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string Codigo = textBox1.Text;
            string FechaCreacion = textBox2.Text;
            string Rareza = textBox3.Text;
            string idExpansion = textBox4.Text;
            int idCarta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Carta SET Codigo = '" + Codigo + "'FechaCreacion = '" + FechaCreacion + "',Rareza = '" + Rareza + "',idExpansion = '" + idExpansion + "' WHERE idCarta = " + idCarta.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCarta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Carta SET Estatus = 0 WHERE idCarta =  " + idCarta.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Jugador jug = new Jugador();
            jug.Show();
            this.Hide();
        }
    }
}
