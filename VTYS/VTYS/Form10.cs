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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");
        SqlCommand cm = new SqlCommand();

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 calisanekran = new Form8();
            calisanekran.Show();
            this.Hide();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
             SqlDataReader oku2;
             con.Open();
             cm.Connection = con;
             cm.CommandText = "select * from calisan";
             oku2 = cm.ExecuteReader();
             while (oku2.Read())
             {
                 comboBox1.Items.Add(oku2[1].ToString() + " " + oku2[2].ToString());
             }
             con.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string metin = comboBox1.SelectedItem.ToString(); // "Adı Soyadı" formatında bir değer varsayalım
            string[] adSoyad = metin.Split(' ');


            string adi = adSoyad[0];
            string soyadi = adSoyad[1];

            con.Open();
            string sorgu = $"SELECT calisan_id FROM calisan WHERE calisan_adi = '{adi}' AND calisan_soyadi = '{soyadi}'";
            SqlCommand cmd2 = new SqlCommand(sorgu, con);
            int cid = Convert.ToInt32(cmd2.ExecuteScalar());

            string sorgu2 = $"SELECT COUNT(*) AS tamamlanan_gorev_sayisi FROM gorev WHERE calisan_id = '{cid}' AND gorev_durum = 'Tamamlandı'";
            SqlCommand cmd = new SqlCommand(sorgu2, con);
            int tamamlananGorevSayisi = Convert.ToInt32(cmd.ExecuteScalar());
            textBox1.Text = tamamlananGorevSayisi.ToString();

            string sorgu3 = $"SELECT COUNT(*) AS tamamlanan_gorev_sayisi FROM gorev WHERE calisan_id = '{cid}' AND gorev_durum = 'Tamamlanacak'";
            SqlCommand cmd3 = new SqlCommand(sorgu3, con);
            int tamamlanacakGorevSayisi = Convert.ToInt32(cmd3.ExecuteScalar());
            textBox2.Text = tamamlanacakGorevSayisi.ToString();

            string sorgu4 = $"SELECT COUNT(*) AS tamamlanan_gorev_sayisi FROM gorev WHERE calisan_id = '{cid}' AND gorev_durum = 'Devam Ediyor'";
            SqlCommand cmd4 = new SqlCommand(sorgu4,con);
            int devamedenGorevSayisi = Convert.ToInt32(cmd4.ExecuteScalar());
            textBox3.Text = devamedenGorevSayisi.ToString();

            string sorgu5 = $"SELECT gorev.gorev_adi, proje.proje_adi FROM gorev INNER JOIN proje ON gorev.proje_id = proje.proje_id WHERE gorev.calisan_id ='{cid}'";
            SqlCommand cmd5 = new SqlCommand(sorgu5,con);
            using (SqlDataReader reader = cmd5.ExecuteReader())
                {
    
                    // ListBox'ı temizleyin
                    listBox1.Items.Clear();

                    // Her bir kayıt için işlem yapın
                    while (reader.Read())
                    {
                        // 'gorev_adi' ve 'proje_adi' değerini ListBox'a ekleyin
                        listBox1.Items.Add(reader["gorev_adi"].ToString()+ " ---> " + reader["proje_adi"].ToString());
                    }
                }
        }
    }
}
