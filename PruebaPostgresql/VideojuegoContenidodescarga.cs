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
    public partial class VideojuegoContenidodescarga : Form
    {
        String consulta;
        public VideojuegoContenidodescarga()
        {
            InitializeComponent();
        }

        private void VideojuegoContenidodescarga_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM VideojuegoContenidodescarga ORDER BY idVideojuegoContenidodescarga");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idVideojuego = textBox1.Text;
            string idContenidodescarga = textBox4.Text;
            consulta = "INSERT INTO VideojuegoContenidodescarga(idVideojuego, idContenidodescarga) values('" + idVideojuego + "','" + idContenidodescarga + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idVideojuego = textBox1.Text;
            string idContenidodescarga = textBox4.Text;
            int idVideojuegoContenidodescarga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE VideojuegoContenidodescarga SET idVideojuego = '" + idVideojuego + "',idContenidodescarga = '" + idContenidodescarga + "' WHERE idVideojuegoContenidodescarga = " + idVideojuegoContenidodescarga.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idVideojuegoContenidodescarga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE VideojuegoContenidodescarga SET Estatus = 0 WHERE idVideojuegoContenidodescarga =  " + idVideojuegoContenidodescarga.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            PlataformaAplicacion pa = new PlataformaAplicacion();
            pa.Show();
            this.Hide();
        }
    }
}
