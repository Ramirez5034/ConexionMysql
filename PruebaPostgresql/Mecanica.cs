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
    public partial class Mecanica : Form
    {
        string consulta;
        public Mecanica()
        {
            InitializeComponent();
        }

        private void Mecanica_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Mecanica ORDER BY idMecanica");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string Activación = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO Mecanica(Nombre, Descripcion, Activación, idGeneracion) values('" + Nombre + "', '" + Descripcion + "', '" + Activación + "', '" + idGeneracion + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Descripcion = textBox2.Text;
            string Activación = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idMecanica = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mecanica SET Nombre = '" + Nombre + "'Descripcion = '" + Descripcion + "',Activación = '" + Activación + "',idGeneracion = '" + idGeneracion + "' WHERE idMecanica = " + idMecanica.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMecanica = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Mecanica SET Estatus = 0 WHERE idMecanica =  " + idMecanica.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Movimiento mov = new Movimiento();
            mov.Show();
            this.Hide();
        }
    }
}
