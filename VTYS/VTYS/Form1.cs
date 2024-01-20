using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace VTYS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)          //login button
        {
            if (textBox1 == null)
            {
                MessageBox.Show("Kullanıcı adı giriniz");
            }
            else if (textBox2 == null)
            {
                MessageBox.Show("Şifre giriniz");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");
                    SqlCommand cmd = new SqlCommand("select * from kullanici where kullanici_adi =@kullanici_adi AND kullanici_sifre =@kullanici_sifre", con);
                    cmd.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
                    cmd.Parameters.AddWithValue("kullanici_sifre", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Giriş başarılı");
                        Form3 anasayfa = new Form3();
                        anasayfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)          //exit button
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)          //sign up button
        {
            Form2 kayitol = new Form2();
            kayitol.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
