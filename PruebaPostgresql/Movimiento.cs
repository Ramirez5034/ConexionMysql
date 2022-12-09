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
    public partial class Movimiento : Form
    {
        string consulta;
        public Movimiento()
        {
            InitializeComponent();
        }

        private void Movimiento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Movimiento ORDER BY idMovimiento");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Poder = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idGeneracion = textBox4.Text;
            consulta = "INSERT INTO Movimiento(Nombre, Poder, Descripcion, idGeneracion) values('" + Nombre + "', '" + Poder + "', '" + Descripcion + "', '" + idGeneracion + "')";
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
            string Poder = textBox2.Text;
            string Descripcion = textBox3.Text;
            string idGeneracion = textBox4.Text;
            int idMovimiento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Movimiento SET Nombre = '" + Nombre + "'Poder = '" + Poder + "',Descripcion = '" + Descripcion + "',idGeneracion = '" + idGeneracion + "' WHERE idMovimiento = " + idMovimiento.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idMovimiento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Movimiento SET Estatus = 0 WHERE idMovimiento =  " + idMovimiento.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Soundtrack sound = new Soundtrack();
            sound.Show();
            this.Hide();
        }
    }
}
