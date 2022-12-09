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
    public partial class Soundtrack : Form
        
    {
        string consulta;
        public Soundtrack()

        {
            InitializeComponent();
        }

        private void Soundtrack_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Soundtrack ORDER BY idSoundtrack");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Uso = textBox1.Text;
            string Numero = textBox2.Text;
            string Duración = textBox3.Text;
            string idVideojuego = textBox4.Text;
            consulta = "INSERT INTO Soundtrack(Uso, Numero, Duración, idVideojuego) values('" + Uso + "', '" + Numero + "', '" + Duración + "', '" + idVideojuego + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Uso = textBox1.Text;
            string Numero = textBox2.Text;
            string Duración = textBox3.Text;
            string idVideojuego = textBox4.Text;
            int idSoundtrack = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Soundtrack SET Uso = '" + Uso + "'Numero = '" + Numero + "',Duración = '" + Duración + "',idVideojuego = '" + idVideojuego + "' WHERE idSoundtrack = " + idSoundtrack.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idSoundtrack = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Soundtrack SET Estatus = 0 WHERE idSoundtrack =  " + idSoundtrack.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Spinoff spin = new Spinoff();
            spin.Show();
            this.Hide();
        }
    }
}
