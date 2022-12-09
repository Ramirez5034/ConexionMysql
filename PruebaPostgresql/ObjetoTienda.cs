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
    public partial class ObjetoTienda : Form
    {
        String consulta;
        public ObjetoTienda()
        {
            InitializeComponent();
        }

        private void ObjetoTienda_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM ObjetoTienda ORDER BY idObjetoTienda");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idObjeto = textBox1.Text;
            string idTienda = textBox4.Text;
            consulta = "INSERT INTO ObjetoTienda(idObjeto, idTienda) values('" + idObjeto + "','" + idTienda + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string idObjeto = textBox1.Text;
            string idTienda = textBox4.Text;
            int idObjetoTienda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ObjetoTienda SET idObjeto = '" + idObjeto + "',idTienda = '" + idTienda + "' WHERE idObjetoTienda = " + idObjetoTienda.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idObjetoTienda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ObjetoTienda SET Estatus = 0 WHERE idObjetoTienda =  " + idObjetoTienda.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            PokeballTienda pt = new PokeballTienda();
            pt.Show();
            this.Hide();
        }
    }
}
