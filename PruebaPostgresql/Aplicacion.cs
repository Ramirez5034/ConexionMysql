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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PruebaPostgresql
{
    public partial class Aplicacion : Form
    {
        String consulta;
        public Aplicacion()
        {
            InitializeComponent();
        }

        private void Aplicacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Tienda ORDER BY idTienda");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Tamaño = textBox1.Text;
            string Nombre = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO Aplicacion(Tamaño, Nombre, Descripcion, idGeneracion) values('" + Tamaño + "', '" + Nombre + "', '" + Descripcion + "', '" + idGeneracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Tamaño = textBox1.Text;
            string Nombre = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idAplicacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Aplicacion SET Tamaño = '" + Tamaño + "'Nombre = '" + Nombre + "',Descripcion = '" + Descripcion  + "',idGeneracion = '" + idGeneracion + "' WHERE idAplicacion = " + idAplicacion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idAplicacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Generacion SET Estatus = 0 WHERE idGeneracion =  " + idAplicacion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Artista art = new Artista();
            art.Show();
            this.Hide();
        }
    }
}
