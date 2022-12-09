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
    public partial class ContenidoDescarga : Form
    {
        string consulta;
        public ContenidoDescarga()
        {
            InitializeComponent();
        }

        private void ContenidoDescarga_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM ContenidoDescarga ORDER BY idContenidoDescarga");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string Precio = textBox2.Text;
            string fecha = textBox3.Text;
            consulta = "INSERT INTO Contenidodescarga (nombre, precio, fecha) values('" + nombre + "', '" + Precio + "', '" + fecha + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String nombre = textBox1.Text;
            string precio = textBox2.Text;
            string fecha = textBox3.Text;
            int idContenidodescarga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Contenidodescarga SET nombre = '" + nombre + "', precio ='" + precio + "', fecha= '" + fecha + "' WHERE idContenidodescarga = " + idContenidodescarga.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idContenidodescarga = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Contenidodescarga SET Estatus = 0 WHERE idContenidodescarga = " + idContenidodescarga.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Consola consola = new Consola();
            consola.Show();
        }
    }
}
