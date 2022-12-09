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
    public partial class Versión : Form
    {
        string consulta;
        public Versión()
        {
            InitializeComponent();
        }

        private void Versión_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Versión ORDER BY idVersión");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string Fechasalida = textBox3.Text;
            string Fechactualizacion = textBox4.Text;
            string idVideojuego = textBox5.Text;
            consulta = "INSERT INTO Versión(Nombre, Numero, Fechasalida, Fechactualizacion, idDesarrollador) values('" + Nombre + "', '" + Fechasalida + "', '" + Fechactualizacion + "', '" + idVideojuego + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;           
            string Fechasalida = textBox3.Text;
            string Fechactualizacion = textBox4.Text;
            string idVideojuego = textBox5.Text;
            int idVersión = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Versión SET Nombre = '" + Nombre + "'Nombre = '" + Nombre + "',Fechasalida = '" + Fechasalida + "',Fechactualizacion = '" + Fechactualizacion + "',idVideojuego = '" + idVideojuego + "' WHERE idVersión = " + idVersión.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idVersión = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Versión SET Estatus = 0 WHERE idVersión =  " + idVersión.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }
    }
}
