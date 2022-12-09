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
    public partial class GeneracionMercancia : Form
    {
        string consulta;
        public GeneracionMercancia()
        {
            InitializeComponent();
        }

        private void GeneracionMercancia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM GeneracionMercancia ORDER BY idGeneracionMercancia");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idGeneracion = textBox1.Text;
            string idMercancia = textBox4.Text;
            consulta = "INSERT INTO GeneracionMercancia(idGeneracion, idMercancia) values('" + idGeneracion + "','" + idMercancia + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idGeneracion = textBox1.Text;
            string idMercancia = textBox4.Text;
            int idGeneracionMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GeneracionMercancia SET idGeneracion = '" + idGeneracion + "',idMercancia = '" + idMercancia + "' WHERE idGeneracionMercancia = " + idGeneracionMercancia.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGeneracionMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE GeneracionMercancia SET Estatus = 0 WHERE idGeneracionMercancia =  " + idGeneracionMercancia.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ColaboracionCarta cc = new ColaboracionCarta();
            cc.Show();
            this.Hide();
        }
    }
}
