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
    public partial class ConsolaVideojuego : Form
    {
        string consulta;
        public ConsolaVideojuego()
        {
            InitializeComponent();
        }

        private void ConsolaVideojuego_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM ConsolaVideojuego ORDER BY idConsolaVideojuego");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idConsola = textBox1.Text;
            string idVideojuego = textBox4.Text;
            consulta = "INSERT INTO ConsolaVideojuego(idConsola, idVideojuego) values('" + idConsola + "','" + idVideojuego + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string idConsola = textBox1.Text;
            string idVideojuego = textBox4.Text;
            int idConsolaVideojuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ConsolaVideojuego SET idConsola = '" + idConsola + "',idVideojuego = '" + idVideojuego + "' WHERE idConsolaVideojuego = " + idConsolaVideojuego.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idConsolaVideojuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ConsolaVideojuego SET Estatus = 0 WHERE idConsolaVideojuego =  " + idConsolaVideojuego.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            DistribucionMercancia dm = new DistribucionMercancia();
            dm.Show();
            this.Hide();
        }
    }
}
