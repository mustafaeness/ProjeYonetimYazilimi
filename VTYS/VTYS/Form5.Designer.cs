namespace VTYS
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            Column1 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewComboBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(56, 124, 207);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column9, Column2, Column3, Column4, Column6, Column5, Column8, Column7, Column10 });
            dataGridView1.Location = new Point(12, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1088, 293);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(56, 124, 207);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(153, 12);
            button1.Name = "button1";
            button1.Size = new Size(135, 29);
            button1.TabIndex = 10;
            button1.Text = "Durum Güncelle";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(56, 124, 207);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(12, 12);
            button2.Name = "button2";
            button2.Size = new Size(135, 29);
            button2.TabIndex = 11;
            button2.Text = "Görev Ekle";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(56, 124, 207);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(959, 12);
            button4.Name = "button4";
            button4.Size = new Size(135, 29);
            button4.TabIndex = 13;
            button4.Text = "Geri Dön";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // Column1
            // 
            Column1.HeaderText = "Proje ID";
            Column1.Name = "Column1";
            Column1.Width = 50;
            // 
            // Column9
            // 
            Column9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column9.HeaderText = "Proje Adı";
            Column9.Name = "Column9";
            // 
            // Column2
            // 
            Column2.HeaderText = "Görev ID";
            Column2.Name = "Column2";
            Column2.Width = 70;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Görev Adı";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Başlangıç Tarihi";
            Column4.Name = "Column4";
            // 
            // Column6
            // 
            Column6.HeaderText = "Planlanan Bitiş Tarihi";
            Column6.Name = "Column6";
            // 
            // Column5
            // 
            Column5.HeaderText = "A/G Değeri";
            Column5.Name = "Column5";
            Column5.Width = 50;
            // 
            // Column8
            // 
            Column8.HeaderText = "Çalışan Adı";
            Column8.Name = "Column8";
            // 
            // Column7
            // 
            Column7.HeaderText = "Durum";
            Column7.Items.AddRange(new object[] { "Tamamlanacak", "Devam Ediyor", "Tamamlandı" });
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 160;
            // 
            // Column10
            // 
            Column10.HeaderText = "Gerçekleşen Bitiş Tarihi";
            Column10.Name = "Column10";
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 74, 129);
            ClientSize = new Size(1110, 350);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "Form5";
            Text = "Proje Görevleri";
            FormClosing += Form5_FormClosing;
            Load += Form5_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button4;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewComboBoxColumn Column7;
        private DataGridViewTextBoxColumn Column10;
    }
}