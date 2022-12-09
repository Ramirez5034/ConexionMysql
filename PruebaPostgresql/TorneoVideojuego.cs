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
    public partial class TorneoVideojuego : Form
    {
        string consulta;
        public TorneoVideojuego()
        {
            InitializeComponent();
        }

        private void TorneoVideojuego_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM TorneoVideojuego ORDER BY idTorneoVideojuego");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idTorneo = textBox1.Text;
            string idVideojuego = textBox4.Text;
            consulta = "INSERT INTO TorneoVideojuego(idTorneo, idVideojuego) values('" + idTorneo + "','" + idVideojuego + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string idTorneo = textBox1.Text;
            string idVideojuego = textBox4.Text;
            int idTorneoVideojuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE TorneoVideojuego SET idTorneo = '" + idTorneo + "',idVideojuego = '" + idVideojuego + "' WHERE idTorneoVideojuego = " + idTorneoVideojuego.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTorneoVideojuego = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE TorneoVideojuego SET Estatus = 0 WHERE idTorneoVideojuego =  " + idTorneoVideojuego.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            VideojuegoEvento ve = new VideojuegoEvento();
            ve.Show();
            this.Hide();
        }
    }
}
