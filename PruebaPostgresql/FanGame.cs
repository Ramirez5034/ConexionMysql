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
    public partial class FanGame : Form
    {
        string consulta;
        public FanGame()
        {
            InitializeComponent();
        }

        private void FanGame_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM FanGame ORDER BY idFanGame");
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Numero = textBox1.Text;
            string Creador = textBox2.Text;
            string Nombre = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO FanGame(Numero, Creador, Nombre, idGeneracion) values('" + Numero + "', '" + Creador + "', '" + Nombre + "', '" + idGeneracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Numero = textBox1.Text;
            string Creador = textBox2.Text;
            string Nombre = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idFanGame = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE FanGame SET Numero = '" + Numero + "'Creador = '" + Creador + "',Nombre = '" + Nombre + "',idGeneracion = '" + idGeneracion + "' WHERE idFanGame = " + idFanGame.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idFanGame = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE FanGame SET Estatus = 0 WHERE idFanGame =  " + idFanGame.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Hackrom hack = new Hackrom();
            hack.Show();
            this.Hide();
        }
    }
}
