using PruebaMySQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaPostgresql
{
    public partial class BattlePass : Form
    {
        string consulta;
        public BattlePass()
        {
            InitializeComponent();
        }

        private void BattlePass_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMysql.ejecutaConsultaSelect("SELECT *FROM BattlePass ORDER BY idBattlePass");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Precio = textBox1.Text;
            string Nombre = textBox2.Text;
            string Tematica = textBox3.Text;
            string idBattlePass = textBox4.Text;
            consulta = "INSERT INTO BattlePass(Precio, Nombre, Tematica, idTemporada) values('" + Precio + "', '" + Nombre + "', '" + Tematica + "', '" + idBattlePass + "')";
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Precio = textBox1.Text;
            string Nombre = textBox2.Text;
            string Tematica = textBox3.Text;
            string idTemporada = textBox4.Text;
            int idBattlePass = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE BattlePass SET Precio = '" + Precio + "'Nombre = '" + Nombre + "',Tematica = '" + Tematica + "',idTemporada = '" + idTemporada + "' WHERE idBattlePass = " + idBattlePass.ToString();
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBattlePass = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE BattlePass SET Estatus = 0 WHERE idBattlePass =  " + idBattlePass.ToString(); ;
            ConexionMysql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Carta cart = new Carta();
            cart.Show();
            this.Hide();
        }
    }
}
