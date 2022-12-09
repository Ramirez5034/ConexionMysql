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
    public partial class Transmisión : Form
    {
        string consulta;
        public Transmisión()
        {
            InitializeComponent();
        }

        private void Transmisión_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM Transmisión ORDER BY idTransmisión");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Canal = textBox1.Text;
            string Numero = textBox2.Text;
            string Horario = textBox3.Text;
            string idAnime = textBox4.Text;
            consulta = "INSERT INTO Transmisión(Canal, Numero, Horario, idAnime) values('" + Canal + "', '" + Numero + "', '" + Horario + "', '" + idAnime + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Canal = textBox1.Text;
            string Numero = textBox2.Text;
            string Horario = textBox3.Text;
            string idAnime = textBox4.Text;
            int idTransmisión = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Transmisión SET Canal = '" + Canal + "'Numero = '" + Numero + "', Horario = '" + Horario + "',idAnime = '" + idAnime + "' WHERE idTransmisión = " + idTransmisión.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idTransmisión= (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Transmisión SET Estatus = 0 WHERE idTransmisión =  " + idTransmisión.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            BattlePass bp = new BattlePass();
            bp.Show();
            this.Hide();
        }
    }
}
