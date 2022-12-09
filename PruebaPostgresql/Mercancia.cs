using PruebaMySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaPostgresql
{
    public partial class Mercancia : Form
    {
        string consulta;
        public Mercancia()
        {
            InitializeComponent();
        }

        private void Mercancia_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Mercancia ORDER BY idMercancia");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Precio = textBox1.Text;
            string Nombre = textBox2.Text;
            string Numero = textBox3.Text;
            consulta = "INSERT INTO Membresia(Precio, Nombre, Numero) values('" + Precio + "', '" + Nombre + "', '" + Numero + "')";

            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Precio = textBox1.Text;
            int idMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mercancia SET Precio = '" + Precio + "' WHERE idMercancia = " + idMercancia.ToString();

            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMercancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Mercancia SET Estatus = 0 WHERE idMercancia =  " + idMercancia.ToString(); ;

            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            Objeto ob = new Objeto();
            ob.Show();
            this.Hide();
        }
    }
}
