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
    public partial class Objeto : Form
    {
        string consulta;
        public Objeto()
        {
            InitializeComponent();
        }

        private void Objeto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Objeto ORDER BY idObjeto");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Tipo = textBox2.Text;
            string DescripciÖn = textBox3.Text;
            consulta = "INSERT INTO Objeto(Nombre, Tipo, Descripción) values('" + Nombre + "', '" + Tipo + "', '" + DescripciÖn + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Nombre = textBox1.Text;
            int idObjeto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Objeto SET Precio = '" + Nombre + "' WHERE idObjeto = " + idObjeto.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idObjeto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Objeto SET Estatus = 0 WHERE idObjeto =  " + idObjeto.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Enlinea lin = new Enlinea();
            lin.Show();
            this.Hide();
        }
    }
}
