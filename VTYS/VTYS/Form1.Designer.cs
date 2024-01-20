namespace VTYS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox1 = new TextBox();
            ıconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            panel2 = new Panel();
            textBox2 = new TextBox();
            ıconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(56, 124, 207);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(ıconPictureBox1);
            panel1.Location = new Point(24, 167);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 33);
            panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(56, 124, 207);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.ForeColor = SystemColors.Menu;
            textBox1.Location = new Point(33, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 25);
            textBox1.TabIndex = 1;
            textBox1.Text = "Kullanıcı Adı";
            // 
            // ıconPictureBox1
            // 
            ıconPictureBox1.BackColor = Color.FromArgb(56, 124, 207);
            ıconPictureBox1.ForeColor = SystemColors.Control;
            ıconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User;
            ıconPictureBox1.IconColor = SystemColors.Control;
            ıconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox1.Location = new Point(0, 0);
            ıconPictureBox1.Name = "ıconPictureBox1";
            ıconPictureBox1.Size = new Size(32, 32);
            ıconPictureBox1.TabIndex = 0;
            ıconPictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(56, 124, 207);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(ıconPictureBox2);
            panel2.Location = new Point(24, 234);
            panel2.Name = "panel2";
            panel2.Size = new Size(263, 33);
            panel2.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(56, 124, 207);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.ForeColor = SystemColors.Menu;
            textBox2.Location = new Point(33, 3);
            textBox2.MaxLength = 16;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(227, 25);
            textBox2.TabIndex = 3;
            textBox2.Text = "Şifre";
            textBox2.UseSystemPasswordChar = true;
            // 
            // ıconPictureBox2
            // 
            ıconPictureBox2.BackColor = Color.FromArgb(56, 124, 207);
            ıconPictureBox2.ForeColor = SystemColors.Control;
            ıconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Lock;
            ıconPictureBox2.IconColor = SystemColors.Control;
            ıconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ıconPictureBox2.Location = new Point(0, 0);
            ıconPictureBox2.Name = "ıconPictureBox2";
            ıconPictureBox2.Size = new Size(32, 32);
            ıconPictureBox2.TabIndex = 0;
            ıconPictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = SystemColors.Control;
            button1.Location = new Point(273, 2);
            button1.Name = "button1";
            button1.Size = new Size(25, 23);
            button1.TabIndex = 2;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.icon;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(95, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(109, 116);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(56, 124, 207);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(32, 308);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Giriş Yap";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(56, 124, 207);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(183, 308);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "Kayıt ol";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 74, 129);
            ClientSize = new Size(299, 370);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ıconPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox1;
        private TextBox textBox1;
        private Panel panel2;
        private TextBox textBox2;
        private FontAwesome.Sharp.IconPictureBox ıconPictureBox2;
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
        private Button button3;
    }
}
