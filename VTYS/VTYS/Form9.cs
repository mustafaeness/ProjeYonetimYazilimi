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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");
        private void button2_Click(object sender, EventArgs e)
        {
            Form8 calisanekran = new Form8();
            calisanekran.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    int v = checkad(textBox1.Text);
                    int c = checksoyad(textBox2.Text);
                    
                    if (v != 1)
                    {
                        if(c != 1)
                        {
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into calisan (calisan_adi, calisan_soyadi) values (@calisan_adi, @calisan_soyadi)", con);
                            cmd.Parameters.AddWithValue("@calisan_adi", textBox1.Text);
                            cmd.Parameters.AddWithValue("@calisan_soyadi", textBox2.Text);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Ekleme Başarılı");
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                        


                    }
                    else
                    {
                        MessageBox.Show("Zaten kayıtlısınız");
                    }

                }
                else
                {
                    MessageBox.Show("Lütfen boş alanları doldurunuz");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        int checkad(string calisan_adi)
        {
            con.Open();
            string queryad = "select count (*) from calisan where calisan_adi='" + calisan_adi + "'";
            SqlCommand cmd = new SqlCommand(queryad, con);
            int v = (int)cmd.ExecuteScalar();
            con.Close();
            return v;
        }
        int checksoyad(string calisan_soyadi)
        {
            con.Open();
            string querysoyad = "select count (*) from calisan where calisan_soyadi = '" + calisan_soyadi + "'";
            SqlCommand cmd = new SqlCommand(querysoyad, con);
            int c = (int)cmd.ExecuteScalar();
            con.Close();
            return c;
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

