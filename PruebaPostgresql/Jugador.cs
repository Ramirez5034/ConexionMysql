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
    public partial class Jugador : Form
    {
        string consulta;
        public Jugador()
        {
            InitializeComponent();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Jugador ORDER BY idJugador");
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Usuario = textBox1.Text;
            string Contraseña = textBox2.Text;
            string Correo = textBox3.Text;
            string idEnlinea = textBox4.Text;
            string idMembresia = textBox5.Text;
            consulta = "INSERT INTO Jugador(Usuario, Contraseña, Correo, idEnlinea, idMembresia) values('" + Usuario + "', '" + Contraseña + "', '" + Correo + "', '" + idEnlinea + "', '" + idMembresia + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void Jugador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Usuario = textBox1.Text;
            string Contraseña = textBox2.Text;
            string Correo = textBox3.Text;
            string idEnlinea = textBox4.Text;
            string idMembresia = textBox5.Text;
            int idJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Jugador SET Usuario = '" + Usuario + "'Contraseña = '" + Contraseña + "',Correo = '" + Correo + "',idEnlinea = '" + idEnlinea + "',idMembresia = '" + idMembresia + "' WHERE idJugador = " + idJugador.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idJugador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Jugador SET Estatus = 0 WHERE idJugador =  " + idJugador.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Compra com = new Compra();
            com.Show();
            this.Hide();
        }
    }
}
