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
    public partial class VideojuegoColaboracion : Form
    {
        string consulta;
        public VideojuegoColaboracion()
        {
            InitializeComponent();
        }

        private void VideojuegoColaboracion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM VideojuegoColaboracion ORDER BY idVideojuegoColaboracion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idVideojuego = textBox1.Text;
            string idColaboracion = textBox4.Text;
            consulta = "INSERT INTO VideojuegoColaboracion(idVideojuego, idColaboracion) values('" + idVideojuego + "','" + idColaboracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idVideojuego = textBox1.Text;
            string idColaboracion = textBox4.Text;
            int idVideojuegoColaboracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE VideojuegoColaboracion SET idVideojuego = '" + idVideojuego + "',idColaboracion = '" + idColaboracion + "' WHERE idVideojuegoColaboracion = " + idVideojuegoColaboracion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idVideojuegoColaboracion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE VideojuegoColaboracion SET Estatus = 0 WHERE idVideojuegoColaboracion =  " + idVideojuegoColaboracion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            VideojuegoContenidodescarga vcnn = new VideojuegoContenidodescarga();
            vcnn.Show();
            this.Hide();
        }
    }
}
