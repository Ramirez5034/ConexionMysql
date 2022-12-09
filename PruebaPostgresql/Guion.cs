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
    public partial class Guion : Form
    {
        string consulta;
        public Guion()
        {
            InitializeComponent();
        }

        private void Guion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Guion ORDER BY idGuion");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string Numero = textBox1.Text;
            string Nombre = textBox2.Text;
            string Descripción = textBox3.Text;
            consulta = "INSERT INTO Guion(Numero, Nombre, Descripción) values('" + Numero + "', '" + Nombre + "', '" + Descripción + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String Numero = textBox1.Text;
            int idGuion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Guion SET numero = '" + Numero + "' WHERE idGuion = " + idGuion.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idGuion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Guion SET Estatus= 0 WHERE idGuion =  " + idGuion.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Imprenta imp = new Imprenta();
            imp.Show();
            this.Hide();
        }
    }
}
