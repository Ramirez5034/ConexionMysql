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
    public partial class ConsolaContro : Form
    {
        string consulta;
        public ConsolaContro()
        {
            InitializeComponent();
        }

        private void ConsolaContro_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM ConsolaContro ORDER BY idConsolaContro");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idConsola = textBox1.Text;
            string idContro = textBox4.Text;
            consulta = "INSERT INTO ConsolaContro(idConsola, idContro) values('" + idConsola + "','" + idContro + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idConsola = textBox1.Text;
            string idContro = textBox4.Text;
            int idConsolaContro = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ConsolaContro SET idConsola = '" + idConsola + "',idContro = '" + idContro + "' WHERE idConsolaContro = " + idConsolaContro.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idConsolaContro = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ConsolaContro SET Estatus = 0 WHERE idConsolaContro =  " + idConsolaContro.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ConsolaVideojuego cv = new ConsolaVideojuego();
            cv.Show();
            this.Hide();
        }
    }
}
