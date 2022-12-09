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
    public partial class Estudio : Form
    {
        string consulta;
        public Estudio()
        {
            InitializeComponent();
        }

        private void Estudio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Estudio ORDER BY idEstudio");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string ciudad = textBox3.Text;
            string Calle = textBox6.Text;
            string Telefono = textBox5.Text;
            string CP = textBox4.Text;
            consulta = "INSERT INTO Estudio(Nombre, Numero, ciudad, Calle, Telefono, CP) values('" + Nombre + "', '" + Numero + "', '" + ciudad + "' '" + Calle + "', '" + Telefono + "', '" + CP + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Nombre = textBox1.Text;
            string Numero = textBox2.Text;
            string ciudad = textBox3.Text;
            string Calle = textBox6.Text;
            string Telefono = textBox5.Text;
            string CP = textBox4.Text;
            int idEstudio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Estudio SET nombre = '" + Nombre + "', Numero ='" + Numero + "', Ciudad= '" + ciudad + "', Calle ='" + Calle + "', Telefono= '" + Telefono + "', CP ='" + CP + "' WHERE idEstudio = " + idEstudio.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idEstudio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Estudio SET Estatus = 0 WHERE idEstudio =  " + idEstudio.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Expansion exp = new Expansion();
            exp.Show();
            this.Hide();
        }
    }
    }

