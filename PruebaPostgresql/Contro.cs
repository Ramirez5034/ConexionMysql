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
    public partial class Contro : Form
    {
        string consulta;
        public Contro()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string Precio = textBox2.Text;
            string diseño = textBox3.Text;
            consulta = "INSERT INTO Contro (numero, precio, diseño) values('" + numero + "', '" + Precio + "', '" + diseño + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String numero = textBox1.Text;
            string precio = textBox2.Text;
            string diseño = textBox3.Text;
            int idContro = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Contro SET numero = '" + numero + "', precio ='" + precio + "', diseño= '" + diseño + "' WHERE idContro = " + idContro.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idContro = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Contro SET Estatus = 0 WHERE idContro = " + idContro.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Desarrollador des = new Desarrollador();
            des.Show();
        }

        private void Contro_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Contro ORDER BY idContro");
        }
    }
}
