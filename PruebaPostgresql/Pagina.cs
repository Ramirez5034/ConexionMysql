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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PruebaPostgresql
{
    public partial class Pagina : Form
    {
        string consulta;
        public Pagina()
        {
            InitializeComponent();
        }

        private void Pagina_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Pagina ORDER BY idPagina");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Diseño = textBox1.Text;
            string FechaCreacion = textBox2.Text;
            string link = textBox3.Text;
            consulta = "INSERT INTO Pagina(Diseño, FechaCreacion, Link) values('" + Diseño + "', '" + FechaCreacion + "', '" + link + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Diseño = textBox1.Text;
            int idPagina = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Pagina SET Diseño = '" + Diseño + "' WHERE idPagina = " + idPagina.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPagina = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Pagina SET Estatus = 0 WHERE idPagina =  " + idPagina.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Skin sk = new Skin();
            sk.Show();
            this.Hide();
        }
    }
}
