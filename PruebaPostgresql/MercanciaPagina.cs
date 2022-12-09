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
    public partial class MercanciaPagina : Form
    {
        string consulta;
        public MercanciaPagina()
        {
            InitializeComponent();
        }

        private void MercanciaPagina_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM MercanciaPagina ORDER BY idMercanciaPagina");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idMercancia = textBox1.Text;
            string idPagina = textBox4.Text;
            consulta = "INSERT INTO MercanciaPagina(idMercancia, idPagina) values('" + idMercancia + "','" + idPagina + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idMercancia = textBox1.Text;
            string idPagina = textBox4.Text;
            int idMercanciaPagina = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MercanciaPagina SET idMercancia = '" + idMercancia + "',idPagina = '" + idPagina + "' WHERE idMercanciaPagina = " + idMercanciaPagina.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMercanciaPagina = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE MercanciaPagina SET Estatus = 0 WHERE idMercanciaPagina =  " + idMercanciaPagina.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ObjetoTienda ot = new ObjetoTienda();
            ot.Show();
            this.Hide();
        }
    }
}
