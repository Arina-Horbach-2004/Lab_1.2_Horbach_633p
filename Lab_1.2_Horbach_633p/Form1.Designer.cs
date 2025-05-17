namespace Lab_1._2_Horbach_633p
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
            label1 = new Label();
            textBox_z = new TextBox();
            radioButton_min = new RadioButton();
            radioButton_max = new RadioButton();
            Обмеження = new Label();
            textBox_obmejenya = new TextBox();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            textBox_x = new TextBox();
            textBoxZ = new TextBox();
            textBox_count = new TextBox();
            button_protokol = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 54);
            label1.Name = "label1";
            label1.Size = new Size(28, 20);
            label1.TabIndex = 0;
            label1.Text = "Z=";
            // 
            // textBox_z
            // 
            textBox_z.Location = new Point(78, 49);
            textBox_z.Name = "textBox_z";
            textBox_z.Size = new Size(279, 27);
            textBox_z.TabIndex = 1;
            // 
            // radioButton_min
            // 
            radioButton_min.AutoSize = true;
            radioButton_min.Checked = true;
            radioButton_min.Location = new Point(379, 52);
            radioButton_min.Name = "radioButton_min";
            radioButton_min.Size = new Size(55, 24);
            radioButton_min.TabIndex = 2;
            radioButton_min.TabStop = true;
            radioButton_min.Text = "min";
            radioButton_min.UseVisualStyleBackColor = true;
            // 
            // radioButton_max
            // 
            radioButton_max.AutoSize = true;
            radioButton_max.Location = new Point(460, 52);
            radioButton_max.Name = "radioButton_max";
            radioButton_max.Size = new Size(58, 24);
            radioButton_max.TabIndex = 3;
            radioButton_max.Text = "max";
            radioButton_max.UseVisualStyleBackColor = true;
            // 
            // Обмеження
            // 
            Обмеження.AutoSize = true;
            Обмеження.Location = new Point(22, 122);
            Обмеження.Name = "Обмеження";
            Обмеження.Size = new Size(96, 20);
            Обмеження.TabIndex = 4;
            Обмеження.Text = "Обмеження:";
            // 
            // textBox_obmejenya
            // 
            textBox_obmejenya.Location = new Point(22, 145);
            textBox_obmejenya.Multiline = true;
            textBox_obmejenya.Name = "textBox_obmejenya";
            textBox_obmejenya.Size = new Size(274, 175);
            textBox_obmejenya.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(327, 162);
            label3.Name = "label3";
            label3.Size = new Size(121, 20);
            label3.TabIndex = 6;
            label3.Text = "Кількість зміних";
            // 
            // button1
            // 
            button1.Location = new Point(327, 209);
            button1.Name = "button1";
            button1.Size = new Size(275, 43);
            button1.TabIndex = 8;
            button1.Text = "Знайти оптимальний розв'язок";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(327, 264);
            label4.Name = "label4";
            label4.Size = new Size(32, 20);
            label4.TabIndex = 9;
            label4.Text = "X =";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(327, 300);
            label5.Name = "label5";
            label5.Size = new Size(32, 20);
            label5.TabIndex = 10;
            label5.Text = "Z =";
            // 
            // textBox_x
            // 
            textBox_x.Location = new Point(379, 258);
            textBox_x.Name = "textBox_x";
            textBox_x.Size = new Size(223, 27);
            textBox_x.TabIndex = 11;
            // 
            // textBoxZ
            // 
            textBoxZ.Location = new Point(379, 297);
            textBoxZ.Name = "textBoxZ";
            textBoxZ.Size = new Size(223, 27);
            textBoxZ.TabIndex = 12;
            // 
            // textBox_count
            // 
            textBox_count.Location = new Point(477, 159);
            textBox_count.Name = "textBox_count";
            textBox_count.Size = new Size(125, 27);
            textBox_count.TabIndex = 13;
            // 
            // button_protokol
            // 
            button_protokol.Location = new Point(173, 350);
            button_protokol.Name = "button_protokol";
            button_protokol.Size = new Size(275, 43);
            button_protokol.TabIndex = 14;
            button_protokol.Text = "Протокол обчислення";
            button_protokol.UseVisualStyleBackColor = true;
            button_protokol.Click += button_protokol_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 425);
            Controls.Add(button_protokol);
            Controls.Add(textBox_count);
            Controls.Add(textBoxZ);
            Controls.Add(textBox_x);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox_obmejenya);
            Controls.Add(Обмеження);
            Controls.Add(radioButton_max);
            Controls.Add(radioButton_min);
            Controls.Add(textBox_z);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox_z;
        private RadioButton radioButton_min;
        private RadioButton radioButton_max;
        private Label Обмеження;
        private TextBox textBox_obmejenya;
        private Label label3;
        private Button button1;
        private Label label4;
        private Label label5;
        private TextBox textBox_x;
        private TextBox textBoxZ;
        private TextBox textBox_count;
        private Button button_protokol;
    }
}
