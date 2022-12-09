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
    public partial class Desarrollador : Form
    {
        string consulta;
        public Desarrollador()
        {
            InitializeComponent();
        }

        private void Desarrollador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Desarrollador ORDER BY idDesarrollador");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Telefono = textBox1.Text;
            string Nombre = textBox2.Text;
            string RFC = textBox3.Text;
            consulta = "INSERT INTO Desarrollador (Telefono, Nombre, RFC) values('" + Telefono + "', '" + Nombre + "', '" + RFC + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Telefono = textBox1.Text;
            string nombre = textBox2.Text;
            string RFC = textBox3.Text;
            int idDesarrollador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Desarrollador SET numero = '" + Telefono + "' WHERE idDesarrollador = " + idDesarrollador.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idDesarrollador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Desarrollador SET Estatus = 0 WHERE idDesarrollador = " + idDesarrollador.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            Distribución dis = new Distribución();
            dis.Show();
            this.Hide();
        }
    }
}
