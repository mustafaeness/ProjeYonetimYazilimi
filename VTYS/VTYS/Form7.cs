using System;
using System.CodeDom;
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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");
        SqlCommand cm = new SqlCommand();
        private void Form7_Load(object sender, EventArgs e)
        {

            dateTimePicker1.MinDate = DateTime.Now;


            SqlDataReader oku;
            con.Open();
            cm.Connection = con;
            cm.CommandText = "select * from proje";
            oku = cm.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[0].ToString());
            }
            con.Close();

            SqlDataReader oku2;
            con.Open();
            cm.Connection = con;
            cm.CommandText = "select * from calisan";
            oku2 = cm.ExecuteReader();
            while (oku2.Read())
            {
                comboBox2.Items.Add(oku2[1].ToString() + " " + oku2[2].ToString());
            }
            con.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
           



            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                     
                    string metin = comboBox2.SelectedItem.ToString(); // "Adı Soyadı" formatında bir değer varsayalım
                    string[] adSoyad = metin.Split(' ');

                  
                        string adi = adSoyad[0];
                        string soyadi = adSoyad[1];

                        con.Open();
                        string sorgu = $"SELECT calisan_id FROM calisan WHERE calisan_adi = '{adi}' AND calisan_soyadi = '{soyadi}'";
                        SqlCommand cmd2 = new SqlCommand(sorgu, con);
                        int cid = Convert.ToInt32(cmd2.ExecuteScalar());
                  


                   
                  
                    SqlCommand cmd = new SqlCommand("insert into gorev (gorev_adi,gorev_basTar, gorev_adamGunDeger, gorev_bitTar, proje_id,calisan_id) values (@gorev_adi, @gorev_basTar, @gorev_adamGunDeger, @gorev_bitTar, @proje_id,@calisan_id)", con);
                    cmd.Parameters.AddWithValue("@proje_id", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@gorev_adi", textBox1.Text);
                    cmd.Parameters.AddWithValue("@gorev_adamGunDeger", textBox2.Text);
                    cmd.Parameters.AddWithValue("@gorev_basTar", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@calisan_id", cid);

                    DateTime selectedDate = dateTimePicker1.Value;
                    int gunEklenecek = Convert.ToInt32(textBox2.Text);
                    DateTime newDate = selectedDate.AddDays(gunEklenecek);
                    string sqlNewDate = newDate.ToString("dd/MM/yyyy");
                    cmd.Parameters.AddWithValue("@gorev_bitTar", sqlNewDate);
                    
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Görev Ekleme Başarılı");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    
                    


                }
                else if (textBox1.Text == "" && textBox2.Text != "")
                {
                    MessageBox.Show("Lütfen görev adı giriniz.");
                }
                else if (textBox1.Text != "" && textBox2.Text == "")
                {
                    MessageBox.Show("Lütfen adam/gün değerini giriniz");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 gorevekran = new Form5();
            gorevekran.Show();
            this.Hide();
        }
    }
}

