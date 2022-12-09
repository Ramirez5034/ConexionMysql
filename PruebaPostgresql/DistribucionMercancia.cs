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
    public partial class DistribucionMercancia : Form
    {
        string consulta;
        public DistribucionMercancia()
        {
            InitializeComponent();
        }

        private void DistribucionMercancia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM DistribuciónMercancia ORDER BY idDistribuciónMercancia");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string idDistribución = textBox1.Text;
            string idMercancia = textBox4.Text;
            consulta = "INSERT INTO DistribuciónMercancia(idDistribución, idMercancia) values('" + idDistribución + "','" + idMercancia + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idDistribución = textBox1.Text;
            string idMercancia = textBox4.Text;
            int idDistribuciónMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE DistribuciónMercancia SET idDistribución = '" + idDistribución + "',idMercancia = '" + idMercancia + "' WHERE idDistribuciónMercancia = " + idDistribuciónMercancia.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDistribuciónMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE DistribuciónMercancia SET Estatus = 0 WHERE idDistribuciónMercancia =  " + idDistribuciónMercancia.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            GeneracionEntrenador ge = new GeneracionEntrenador();
            ge.Show();
            this.Hide();
        }
    }
}
