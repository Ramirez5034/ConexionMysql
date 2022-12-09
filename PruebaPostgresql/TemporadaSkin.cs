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
    public partial class TemporadaSkin : Form
    {
        string consulta;
        public TemporadaSkin()
        {
            InitializeComponent();
        }

        private void TemporadaSkin_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM TemporadaSkin ORDER BY idTemporadaSkin");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idTemporada = textBox1.Text;
            string idSkin = textBox4.Text;
            consulta = "INSERT INTO TemporadaSkin(idTemporada, idSkin) values('" + idTemporada + "','" + idSkin + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idTemporada = textBox1.Text;
            string idSkin = textBox4.Text;
            int idTemporadaSkin = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE TemporadaSkin SET idTemporada = '" + idTemporada + "',idSkin = '" + idSkin + "' WHERE idTemporadaSkin = " + idTemporadaSkin.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTemporadaSkin = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE TemporadaSkin SET Estatus = 0 WHERE idTemporadaSkin =  " + idTemporadaSkin.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            TemporadaVestuario tv = new TemporadaVestuario();
            tv.Show();
            this.Hide();
        }
    }
}
