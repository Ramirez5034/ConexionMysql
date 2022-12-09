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
    public partial class PokeballTienda : Form
    {
        string consulta;
        public PokeballTienda()
        {
            InitializeComponent();
        }

        private void PokeballTienda_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM PokeballTienda ORDER BY idPokeballTienda");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idPokeball = textBox1.Text;
            string idTienda = textBox4.Text;
            consulta = "INSERT INTO PokeballTienda(idPokeball, idTienda) values('" + idPokeball + "','" + idTienda + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idPokeball = textBox1.Text;
            string idTienda = textBox4.Text;
            int idPokeballTienda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PokeballTienda SET idPokeball = '" + idPokeball + "',idTienda = '" + idTienda + "' WHERE idPokeballTienda = " + idPokeballTienda.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idPokeballTienda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE PokeballTienda SET Estatus = 0 WHERE idPokeballTienda =  " + idPokeballTienda.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            TemporadaSkin ts = new TemporadaSkin();
            ts.Show();
            this.Hide();
        }
    }
}
