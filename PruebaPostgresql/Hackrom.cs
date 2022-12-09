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
    public partial class Hackrom : Form
    {
        string consulta;
        public Hackrom()
        {
            InitializeComponent();
        }

        private void Hackrom_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Hackrom ORDER BY idHackrom");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Plataforma = textBox1.Text;
            string Creador = textBox2.Text;
            string Nombre = textBox3.Text;
            string idVideojuego = textBox4.Text;
            consulta = "INSERT INTO Hackrom(Plataforma, Creador, Nombre, idVideojuego) values('" + Plataforma + "', '" + Creador + "', '" + Nombre + "', '" + idVideojuego + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Plataforma = textBox1.Text;
            string Creador = textBox2.Text;
            string Nombre = textBox3.Text;
            string idVideojuego = textBox4.Text;
            int idHackrom = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Hackrom SET Plataforma = '" + Plataforma + "'Creador = '" + Creador + "',Nombre = '" + Nombre + "',idVideojuego = '" + idVideojuego + "' WHERE idHackrom = " + idHackrom.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idHackrom = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Hackrom SET Estatus = 0 WHERE idHackrom =  " + idHackrom.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Manga man = new Manga();
            man.Show();
            this.Hide();
        }
    }
}
