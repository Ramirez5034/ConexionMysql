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
    public partial class VideojuegoEvento : Form
    {
        string consulta;
        public VideojuegoEvento()
        {
            InitializeComponent();
        }

        private void VideojuegoEvento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM VideojuegoEvento ORDER BY idVideojuegoEvento");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idVideojuego = textBox1.Text;
            string idEvento = textBox4.Text;
            consulta = "INSERT INTO VideojuegoEvento(idVideojuego, idEvento) values('" + idVideojuego + "','" + idEvento + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string idVideojuego = textBox1.Text;
            string idEvento = textBox4.Text;
            int idVideojuegoEvento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE VideojuegoEvento SET idVideojuego = '" + idVideojuego + "',idEvento = '" + idEvento + "' WHERE idVideojuegoEvento = " + idVideojuegoEvento.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            int idVideojuegoEvento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE VideojuegoEvento SET Estatus = 0 WHERE idVideojuegoEvento =  " + idVideojuegoEvento.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            VideojuegoJugador vj = new VideojuegoJugador();
            vj.Show();
            this.Hide();
        }
    }
}
