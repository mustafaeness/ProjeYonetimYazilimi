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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            LoadProjeData();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=vtys;Integrated Security=True;Encrypt=False");
        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 gorevekran = new Form5();
            gorevekran.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            

            try
            {
                // ComboBox3'teki seçili durumu al
                string yeniDurum = comboBox3.SelectedItem.ToString();

                // ComboBox2'den seçilen görev_id'sini al
                int selectedGorevID = Convert.ToInt32(comboBox2.SelectedValue);

                // Görev durumunu güncelle
                UpdateGorevDurum(selectedGorevID, yeniDurum);

                // Kullanıcıya güncelleme başarılı mesajını göster
                MessageBox.Show("Görev durumu güncellendi.");

                // ComboBox2'yi ve TextBox'ları yeniden yükle
                LoadGorevData(Convert.ToInt32(comboBox2.SelectedValue));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görev durumu güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void UpdateGorevDurum(int gorevID, string yeniDurum)
        {
            try
            {
                con.Open();
                DateTime bugun = new DateTime();
                bugun = DateTime.Now;
                
                

                // Görev durumunu güncelle
                string updateQuery = "UPDATE gorev SET gorev_durum = @gorev_durum WHERE gorev_id = @gorev_id";
                SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                updateCommand.Parameters.AddWithValue("@gorev_durum", yeniDurum);
                updateCommand.Parameters.AddWithValue("@gorev_id", gorevID);
                updateCommand.ExecuteNonQuery();
                if(yeniDurum == "Tamamlandı")
                {
                    string updateDate = "UPDATE gorev SET gorev_gerBitTar = @gorev_gerBitTar WHERE gorev_id = @gorev_id";
                    SqlCommand updateDatecmd = new SqlCommand(updateDate, con);
                    updateDatecmd.Parameters.AddWithValue("@gorev_gerBitTar", bugun);
                    updateDatecmd.Parameters.AddWithValue("@gorev_id", gorevID);
                    updateDatecmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Görev durumu güncellenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void LoadProjeData()
        {
            try
            {
                con.Open();

                // ComboBox1'e proje_id'leri yükle
                string projeQuery = "SELECT proje_id, proje_adi FROM proje";
                SqlDataAdapter projeAdapter = new SqlDataAdapter(projeQuery, con);
                DataTable projeTable = new DataTable();
                projeAdapter.Fill(projeTable);

                comboBox1.DataSource = projeTable;
                comboBox1.ValueMember = "proje_id";
                comboBox1.DisplayMember = "proje_adi";

                // ComboBox1'de seçim değiştiğinde olayı tanımla
                comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proje verileri yüklenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void LoadGorevData(int projeID)
        {
            try
            {
                con.Open();

                // ComboBox2'ye proje_id'ye ait görev_id'leri yükle
                string gorevQuery = "SELECT gorev_id, gorev_adi FROM gorev WHERE proje_id = @proje_id";
                SqlDataAdapter gorevAdapter = new SqlDataAdapter(gorevQuery, con);
                gorevAdapter.SelectCommand.Parameters.AddWithValue("@proje_id", projeID);
                DataTable gorevTable = new DataTable();
                gorevAdapter.Fill(gorevTable);

                comboBox2.DataSource = gorevTable;
                comboBox2.ValueMember = "gorev_id";
                comboBox2.DisplayMember = "gorev_adi";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Görev verileri yüklenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox2'den seçilen görev_id'sini al
            int selectedGorevID = Convert.ToInt32(comboBox2.SelectedValue);

            // TextBox'a seçilen görevin bilgilerini yükle
            LoadGorevDetails(selectedGorevID);
        }
        private void LoadGorevDetails(int gorevID)
        {
            try
            {
                con.Open();

                // Seçilen görev_id'ye ait görev detaylarını al
                string detailsQuery = "SELECT * FROM gorev WHERE gorev_id = @gorev_id";
                SqlDataAdapter detailsAdapter = new SqlDataAdapter(detailsQuery, con);
                detailsAdapter.SelectCommand.Parameters.AddWithValue("@gorev_id", gorevID);
                DataTable detailsTable = new DataTable();
                detailsAdapter.Fill(detailsTable);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Görev detayları yüklenirken bir hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ComboBox1'den seçilen proje_id'sini al
            int selectedProjeID = Convert.ToInt32(comboBox1.SelectedValue);

            // ComboBox2'ye seçilen proje_id'ye ait görev_id'leri yükle
            LoadGorevData(selectedProjeID);
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedValue.ToString();
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox2.SelectedValue.ToString();
        }
    }
}
