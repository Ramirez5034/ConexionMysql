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
    public partial class PlataformaAplicacion : Form
    {
        string consulta;
        public PlataformaAplicacion()
        {
            InitializeComponent();
        }

        private void PlataformaAplicacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM PlataformaAplicacion ORDER BY idPlataformaAplicacion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idPlataforma = textBox1.Text;
            string idAplicacion = textBox4.Text;
            consulta = "INSERT INTO PlataformaAplicacion(idPlataforma, idAplicacion) values('" + idPlataforma + "','" + idAplicacion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idPlataforma = textBox1.Text;
            string idAplicacion = textBox4.Text;
            int idPlataformaAplicacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PlataformaAplicacion SET idPlataforma = '" + idPlataforma + "',idAplicacion = '" + idAplicacion + "' WHERE idPlataformaAplicacion = " + idPlataformaAplicacion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPlataformaAplicacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE PlataformaAplicacion SET Estatus = 0 WHERE idPlataformaAplicacion =  " + idPlataformaAplicacion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }
    }
}
