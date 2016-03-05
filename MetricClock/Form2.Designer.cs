namespace MetricClock
{
    partial class Form2
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.Sec = new System.Windows.Forms.NumericUpDown();
            this.Min = new System.Windows.Forms.NumericUpDown();
            this.Hor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LDateTime = new System.Windows.Forms.TextBox();
            this.SDate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Sec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hor)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(280, 26);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Sec
            // 
            this.Sec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sec.Location = new System.Drawing.Point(240, 104);
            this.Sec.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.Sec.Name = "Sec";
            this.Sec.ReadOnly = true;
            this.Sec.Size = new System.Drawing.Size(52, 29);
            this.Sec.TabIndex = 1;
            this.Sec.ValueChanged += new System.EventHandler(this.Sec_ValueChanged);
            // 
            // Min
            // 
            this.Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Min.Location = new System.Drawing.Point(163, 104);
            this.Min.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.Min.Name = "Min";
            this.Min.ReadOnly = true;
            this.Min.Size = new System.Drawing.Size(52, 29);
            this.Min.TabIndex = 1;
            this.Min.ValueChanged += new System.EventHandler(this.Min_ValueChanged);
            // 
            // Hor
            // 
            this.Hor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hor.Location = new System.Drawing.Point(81, 104);
            this.Hor.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.Hor.Name = "Hor";
            this.Hor.ReadOnly = true;
            this.Hor.Size = new System.Drawing.Size(52, 29);
            this.Hor.TabIndex = 1;
            this.Hor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Hor.ValueChanged += new System.EventHandler(this.Hor_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(221, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Time :";
            // 
            // LDateTime
            // 
            this.LDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LDateTime.Location = new System.Drawing.Point(12, 148);
            this.LDateTime.Name = "LDateTime";
            this.LDateTime.ReadOnly = true;
            this.LDateTime.Size = new System.Drawing.Size(280, 21);
            this.LDateTime.TabIndex = 3;
            this.LDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LDateTime.Click += new System.EventHandler(this.LDateTime_Click);
            // 
            // SDate
            // 
            this.SDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SDate.Location = new System.Drawing.Point(81, 56);
            this.SDate.Name = "SDate";
            this.SDate.ReadOnly = true;
            this.SDate.Size = new System.Drawing.Size(211, 29);
            this.SDate.TabIndex = 3;
            this.SDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(304, 187);
            this.Controls.Add(this.SDate);
            this.Controls.Add(this.LDateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hor);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Sec);
            this.Controls.Add(this.dateTimePicker1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form2";
            this.Text = "Metric Clock";
            ((System.ComponentModel.ISupportInitialize)(this.Sec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NumericUpDown Sec;
        private System.Windows.Forms.NumericUpDown Min;
        private System.Windows.Forms.NumericUpDown Hor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox LDateTime;
        private System.Windows.Forms.TextBox SDate;
    }
}