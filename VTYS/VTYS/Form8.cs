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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private string connectionString = ("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 calisanekle = new Form9();
            calisanekle.Show();
            this.Hide();
        }
        private void load_calisandata()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Çalışanlar, Görevler ve Projeler tablolarını birleştiren SQL sorgusu
                    string query = "SELECT * FROM calisan";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'e verileri bağla
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Insert(3, buttonColumn);
            buttonColumn.HeaderText = "Satır Sil";
            buttonColumn.Width = 100;
            buttonColumn.Text = "Sil";
            buttonColumn.UseColumnTextForButtonValue = true;

        }
        private void Form8_Load(object sender, EventArgs e)
        {
            load_calisandata();

        }


        private void button4_Click(object sender, EventArgs e)
        {
            Form3 anasayfa = new Form3();
            anasayfa.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (MessageBox.Show(string.Format("Bu satırı silmek istiyor musunuz?", row.Cells["calisan_id"].Value), "Emin misiniz?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (SqlConnection con1 = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM gorev WHERE calisan_id = @calisan_id", con1))
                        {
                            cmd.Parameters.AddWithValue("@calisan_id", row.Cells["calisan_id"].Value);
                            con1.Open();
                            cmd.ExecuteNonQuery();
                            con1.Close();

                        }
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM calisan WHERE calisan_id = @calisan_id", con1))
                        {
                            cmd.Parameters.AddWithValue("@calisan_id", row.Cells["calisan_id"].Value);
                            con1.Open();
                            cmd.ExecuteNonQuery();
                            con1.Close();

                        }
                    }
                    load_calisandata();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 calisanistatistik = new Form10();
            calisanistatistik.Show();
            this.Hide();
        }
    }
}
