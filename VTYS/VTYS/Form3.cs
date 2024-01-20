using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace VTYS
{
    public partial class Form3 : Form
    {
        ArrayList planlanan = new ArrayList();

        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");

        private void Form3_Load(object sender, EventArgs e)
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT proje.*, MAX(gorev.gorev_gerBitTar) AS enBuyukGorevBitisTarihi FROM proje INNER JOIN gorev ON gorev.proje_id = proje.proje_id WHERE proje.proje_id = gorev.proje_id GROUP BY proje.proje_id, proje.proje_adi, proje.proje_basTar, proje.proje_bitTar, proje.proje_gecikme", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                con.Open();
                string query = "SELECT proje.*, MAX(gorev.gorev_gerBitTar) AS enBuyukGorevBitisTarihi FROM proje INNER JOIN gorev ON gorev.proje_id = proje.proje_id WHERE proje.proje_id = gorev.proje_id GROUP BY proje.proje_id, proje.proje_adi, proje.proje_basTar, proje.proje_bitTar, proje.proje_gecikme";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            // proje_bitTar sütunundan string değeri al
                            string projeBitisTarihiString = reader["proje_bitTar"].ToString();
                            
                            // "enBuyukGorevBitisTarihi" ve "proje_bitTar" arasındaki farkı hesapla
                            if (DateTime.TryParse(item["enBuyukGorevBitisTarihi"].ToString(), out DateTime enBuyukGorevBitisTarihi) &&
                            DateTime.TryParse(item["proje_bitTar"].ToString(), out DateTime yeniDegisken))
                            {
                                TimeSpan fark = enBuyukGorevBitisTarihi - yeniDegisken;
                                

                                // Fark 0'dan büyükse, gün olarak DataGridView'e ekle
                                if (fark.TotalDays > 0)
                                {
                                    dataGridView1.Rows[n].Cells[4].Value = fark.TotalDays.ToString() +" "+ "gün";
                                    int farkInt = Convert.ToInt32(fark.TotalDays);

                                    // SQL sorgusu
                                    string updateQuery = $"UPDATE proje SET proje_gecikme = {farkInt} WHERE proje_id = {item["proje_id"]}";

                                    // SqlConnection ve SqlCommand kullanarak sorguyu çalıştırın
                                    using (SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False"))
                                    {
                                        connection.Open();

                                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                                        {
                                            updateCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Geçersiz tarih formatı");
                            }


                        }
                    }

                }


            }
        }

            /*
            string gorevBitTarString = item[3].ToString();
            string tarihFormati = "yyyy-MM-dd";
            DateTime gorevBitTarDateTime = DateTime.ParseExact(gorevBitTarString, @"d/M/yyyy",System.Globalization.CultureInfo.InvariantCulture);
            */


            /* DateTime dt1 = new DateTime(DateTime.ParseExact(, "yyyy-MM-dd",CultureInfo.InvariantCulture);
             DateTime dt2 = new DateTime((int)(dataGridView1.Rows[n].Cells[4].Value = item[5].ToString()));
             var diffOfDates = dt2.Subtract(dt1);
             dataGridView1.Rows[n].Cells[4].Value = item[5].ToString();*/

            /*
            string enBuyukGorevBitisTarihi = item[5].ToString();
            string gorevBitTarString = item[3].ToString();
            string tarihFormati = "yyyy-MM-dd";
            try
            {
                DateTime enBuyukGorervBitisTarihiDateTime = DateTime.ParseExact(enBuyukGorevBitisTarihi, tarihFormati, CultureInfo.InvariantCulture);
                DateTime gorevBitTarDateTime = DateTime.ParseExact(gorevBitTarString, tarihFormati, CultureInfo.InvariantCulture);
                TimeSpan fark = enBuyukGorervBitisTarihiDateTime - gorevBitTarDateTime;

                dataGridView1.Rows[n].Cells[4].Value = Convert.ToDateTime(fark);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }*/


            /*DateTime projeBitisTarihi = Convert.ToDateTime(dataGridView1.Rows[1].Cells[3].Value);
             TimeSpan gecikmeSuresi = (projeBitisTarihi - Convert.ToDateTime(dataGridView1.Rows[n].Cells[4].Value = item[5].ToString()));
            dataGridView1.Rows[n].Cells[4].Value = Convert.ToDateTime(gecikmeSuresi);*/








            private void Form3_FormClosing(object sender, FormClosingEventArgs e)
            {
                Application.Exit();
            }

            private void button1_Click(object sender, EventArgs e)
            {
                Form4 projeekle = new Form4();
                projeekle.Show();
                this.Hide();
            }

            private void button2_Click(object sender, EventArgs e)
            {
                Form5 gorevekran = new Form5();
                gorevekran.Show();
                this.Hide();
            }

            private void button3_Click(object sender, EventArgs e)
            {
                Form8 calisanekran = new Form8();
                calisanekran.Show();
                this.Hide();
            }
        }
    }

