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
    
    public partial class Doblaje : Form
    {
        string consulta;
        public Doblaje()
        {
            InitializeComponent();
        }

        private void Doblaje_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Doblaje ORDER BY idDoblaje");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Zona = textBox1.Text;
            string Director = textBox2.Text;
            string Lenguaje = textBox3.Text;
            string idAnime = textBox4.Text;
            consulta = "INSERT INTO Doblaje(Zona, Director, Lenguaje, idAnime) values('" + Zona + "', '" + Director + "', '" + Lenguaje + "', '" + idAnime + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Zona = textBox1.Text;
            string Director = textBox2.Text;
            string Lenguaje = textBox3.Text;
            string idAnime = textBox4.Text;
            int idDoblaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Doblaje SET Zona = '" + Zona + "'Director = '" + Director + "',Lenguaje = '" + Lenguaje + "',idAnime = '" + idAnime + "' WHERE idDoblaje = " + idDoblaje.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDoblaje = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Doblaje SET Estatus = 0 WHERE idDoblaje =  " + idDoblaje.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Evolucion evo = new Evolucion();
            evo.Show();
            this.Hide();
        }
    }
}
