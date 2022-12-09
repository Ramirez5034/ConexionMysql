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
    public partial class VideojuegoJugador : Form
    {
        string consulta;
        public VideojuegoJugador()
        {
            InitializeComponent();
        }

        private void VideojuegoJugador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM VideojuegoJugador ORDER BY idVideojuegoJugador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idVideojuego = textBox1.Text;
            string idJugador = textBox4.Text;
            consulta = "INSERT INTO VideojuegoJugador(idVideojuego, idJugador) values('" + idVideojuego + "','" + idJugador + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idVideojuego = textBox1.Text;
            string idJugador = textBox4.Text;
            int idVideojuegoJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE VideojuegoJugador SET idVideojuego = '" + idVideojuego + "',idJugador = '" + idJugador + "' WHERE idVideojuegoJugador = " + idVideojuegoJugador.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idVideojuegoJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE VideojuegoJugador SET Estatus = 0 WHERE idVideojuegoJugador =  " + idVideojuegoJugador.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            VideojuegoColaboracion vcn = new VideojuegoColaboracion();
            vcn.Show();
            this.Hide();
        }
    }
}
