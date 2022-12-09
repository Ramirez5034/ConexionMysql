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
    public partial class tienda : Form
    {
        string consulta;
        public tienda()
        {
            InitializeComponent();
        }

        private void tienda_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Tienda ORDER BY idTienda");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Ubicacion = textBox1.Text;
            string Numero = textBox2.Text;
            string Tipo = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO Generacion(Ubicacion, Numero, Tipo, idGeneracion) values('" + Ubicacion + "', '" + Numero + "', '" + Tipo + "', '" + idGeneracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string Ubicacion = textBox1.Text;
            string Numero = textBox2.Text;
            string Tipo = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idTienda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Colaboracion SET Ubicacion = '" + Ubicacion + "'Numero = '" + Numero + "',Tipo = '" + Tipo + "',idGeneracion = '" + idGeneracion + "' WHERE idTienda = " + idTienda.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTienda = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Tienda SET Estatus = 0 WHERE idTienda =  " + idTienda.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Anime an = new Anime();
            an.Show();
            this.Hide();
        }
    }
}
