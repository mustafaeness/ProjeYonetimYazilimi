using FontAwesome.Sharp;
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

namespace VTYS
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");
        private void Form5_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT gorev.*,proje.proje_adi,calisan.calisan_adi,calisan.calisan_soyadi FROM gorev INNER JOIN proje ON gorev.proje_id = proje.proje_id INNER JOIN calisan ON gorev.calisan_id = calisan.calisan_id", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[6].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[9].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[5].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[6].Value = item[4].ToString();
                dataGridView1.Rows[n].Cells[7].Value = item[10].ToString() +" "+ item[11].ToString();
                dataGridView1.Rows[n].Cells[8].Value = item[5].ToString();
                dataGridView1.Rows[n].Cells[9].Value = item[8].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 durumguncelleme = new Form6();
            durumguncelleme.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 gorevekle = new Form7();
            gorevekle.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 anasayfa = new Form3();
            anasayfa.Show();
            this.Hide();
        }

    }
}
