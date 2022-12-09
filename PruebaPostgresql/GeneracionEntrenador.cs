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
    public partial class GeneracionEntrenador : Form
    {
        string consulta;
        public GeneracionEntrenador()
        {
            InitializeComponent();
        }

        private void GeneracionEntrenador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM GeneracionEntrenador ORDER BY idGeneracionEntrenador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idGeneracion = textBox1.Text;
            string idEntrenador = textBox4.Text;
            consulta = "INSERT INTO GeneracionEntrenador(idGeneracion, idEntrenador) values('" + idGeneracion + "','" + idEntrenador + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idGeneracion = textBox1.Text;
            string idEntrenador = textBox4.Text;
            int idGeneracionEntrenador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GeneracionEntrenador SET idGeneracion = '" + idGeneracion + "',idEntrenador = '" + idEntrenador + "' WHERE idGeneracionEntrenador = " + idGeneracionEntrenador.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGeneracionEntrenador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE GeneracionEntrenador SET Estatus = 0 WHERE idGeneracionEntrenador =  " + idGeneracionEntrenador.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            GeneracionMercancia gm = new GeneracionMercancia();
            gm.Show();
            this.Hide();
        }
    }
}
