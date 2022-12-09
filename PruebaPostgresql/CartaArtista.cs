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
    public partial class CartaArtista : Form
    {
        string consulta;
        public CartaArtista()
        {
            InitializeComponent();
        }

        private void CartaArtista_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM CartaArtista ORDER BY idCartaArtista");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idCarta = textBox1.Text;
            string idArtista = textBox4.Text;
            consulta = "INSERT INTO CartaArtista(idCarta, idArtista) values('" + idCarta + "','" + idArtista + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idCarta = textBox1.Text;
            string idArtista = textBox4.Text;
            int idCartaArtista = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE CartaArtista SET idCarta = '" + idCarta + "',idArtista = '" + idArtista + "' WHERE idCartaArtista = " + idCartaArtista.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idCartaArtista = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE CartaArtista SET Estatus = 0 WHERE idCartaArtista =  " + idCartaArtista.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }
    }
}
