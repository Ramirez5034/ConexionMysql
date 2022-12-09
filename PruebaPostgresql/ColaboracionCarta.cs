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
    public partial class ColaboracionCarta : Form
    {
        string consulta;
        public ColaboracionCarta()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idColaboracion = textBox1.Text;
            string idCarta = textBox4.Text;
            consulta = "INSERT INTO ColaboracionCarta(idColaboracion, idCarta) values('" + idColaboracion + "','" + idCarta + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM ColaboracionCarta ORDER BY idColaboracionCarta");
        }

        private void ColaboracionCarta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idColaboracion = textBox1.Text;
            string idCarta = textBox4.Text;
            int idColaboracionCarta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ColaboracionCarta SET idColaboracion = '" + idColaboracion + "',idCarta = '" + idCarta + "' WHERE idColaboracionCarta = " + idColaboracionCarta.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

            int idColaboracionCarta = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ColaboracionCarta SET Estatus = 0 WHERE idColaboracionCarta =  " + idColaboracionCarta.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            CartaArtista ca = new CartaArtista();
            ca.Show();
            this.Hide();
        }
    }
}
