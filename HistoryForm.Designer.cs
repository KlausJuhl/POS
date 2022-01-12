namespace POS
{
    partial class HistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_POSTransaction = new System.Windows.Forms.DataGridView();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.pnl_Keyboard = new System.Windows.Forms.Panel();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.btn_Key9 = new System.Windows.Forms.Button();
            this.btn_Key8 = new System.Windows.Forms.Button();
            this.btn_Key6 = new System.Windows.Forms.Button();
            this.btn_Key0 = new System.Windows.Forms.Button();
            this.btn_Key5 = new System.Windows.Forms.Button();
            this.btn_Key7 = new System.Windows.Forms.Button();
            this.btn_Key3 = new System.Windows.Forms.Button();
            this.btn_Key4 = new System.Windows.Forms.Button();
            this.btn_Key2 = new System.Windows.Forms.Button();
            this.btn_Key1 = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_POSTransaction)).BeginInit();
            this.pnl_Keyboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_POSTransaction
            // 
            this.dgv_POSTransaction.AllowUserToAddRows = false;
            this.dgv_POSTransaction.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_POSTransaction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_POSTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_POSTransaction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_POSTransaction.Location = new System.Drawing.Point(12, 301);
            this.dgv_POSTransaction.Name = "dgv_POSTransaction";
            this.dgv_POSTransaction.ReadOnly = true;
            this.dgv_POSTransaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_POSTransaction.Size = new System.Drawing.Size(704, 467);
            this.dgv_POSTransaction.TabIndex = 3;
            // 
            // txt_Customer
            // 
            this.txt_Customer.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txt_Customer.Location = new System.Drawing.Point(191, 29);
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.Size = new System.Drawing.Size(100, 27);
            this.txt_Customer.TabIndex = 0;
            this.txt_Customer.TextChanged += new System.EventHandler(this.txt_Customer_TextChanged);
            this.txt_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Medlemsnummer";
            // 
            // btn_Search
            // 
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btn_Search.Location = new System.Drawing.Point(336, 25);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 34);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Søg";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // pnl_Keyboard
            // 
            this.pnl_Keyboard.Controls.Add(this.btn_Enter);
            this.pnl_Keyboard.Controls.Add(this.btn_Key9);
            this.pnl_Keyboard.Controls.Add(this.btn_Key8);
            this.pnl_Keyboard.Controls.Add(this.btn_Key6);
            this.pnl_Keyboard.Controls.Add(this.btn_Key0);
            this.pnl_Keyboard.Controls.Add(this.btn_Key5);
            this.pnl_Keyboard.Controls.Add(this.btn_Key7);
            this.pnl_Keyboard.Controls.Add(this.btn_Key3);
            this.pnl_Keyboard.Controls.Add(this.btn_Key4);
            this.pnl_Keyboard.Controls.Add(this.btn_Key2);
            this.pnl_Keyboard.Controls.Add(this.btn_Key1);
            this.pnl_Keyboard.Location = new System.Drawing.Point(494, 12);
            this.pnl_Keyboard.Name = "pnl_Keyboard";
            this.pnl_Keyboard.Size = new System.Drawing.Size(222, 283);
            this.pnl_Keyboard.TabIndex = 14;
            // 
            // btn_Enter
            // 
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enter.Location = new System.Drawing.Point(81, 213);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(126, 60);
            this.btn_Enter.TabIndex = 0;
            this.btn_Enter.Text = "Enter";
            this.btn_Enter.UseVisualStyleBackColor = true;
            this.btn_Enter.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key9
            // 
            this.btn_Key9.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key9.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key9.Location = new System.Drawing.Point(147, 147);
            this.btn_Key9.Name = "btn_Key9";
            this.btn_Key9.Size = new System.Drawing.Size(60, 60);
            this.btn_Key9.TabIndex = 0;
            this.btn_Key9.Text = "9";
            this.btn_Key9.UseVisualStyleBackColor = true;
            this.btn_Key9.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key8
            // 
            this.btn_Key8.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key8.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key8.Location = new System.Drawing.Point(81, 147);
            this.btn_Key8.Name = "btn_Key8";
            this.btn_Key8.Size = new System.Drawing.Size(60, 60);
            this.btn_Key8.TabIndex = 0;
            this.btn_Key8.Text = "8";
            this.btn_Key8.UseVisualStyleBackColor = true;
            this.btn_Key8.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key6
            // 
            this.btn_Key6.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key6.Location = new System.Drawing.Point(147, 81);
            this.btn_Key6.Name = "btn_Key6";
            this.btn_Key6.Size = new System.Drawing.Size(60, 60);
            this.btn_Key6.TabIndex = 0;
            this.btn_Key6.Text = "6";
            this.btn_Key6.UseVisualStyleBackColor = true;
            this.btn_Key6.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key0
            // 
            this.btn_Key0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key0.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key0.Location = new System.Drawing.Point(15, 213);
            this.btn_Key0.Name = "btn_Key0";
            this.btn_Key0.Size = new System.Drawing.Size(60, 60);
            this.btn_Key0.TabIndex = 0;
            this.btn_Key0.Text = "0";
            this.btn_Key0.UseVisualStyleBackColor = true;
            this.btn_Key0.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key5
            // 
            this.btn_Key5.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key5.Location = new System.Drawing.Point(81, 81);
            this.btn_Key5.Name = "btn_Key5";
            this.btn_Key5.Size = new System.Drawing.Size(60, 60);
            this.btn_Key5.TabIndex = 0;
            this.btn_Key5.Text = "5";
            this.btn_Key5.UseVisualStyleBackColor = true;
            this.btn_Key5.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key7
            // 
            this.btn_Key7.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key7.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key7.Location = new System.Drawing.Point(15, 147);
            this.btn_Key7.Name = "btn_Key7";
            this.btn_Key7.Size = new System.Drawing.Size(60, 60);
            this.btn_Key7.TabIndex = 0;
            this.btn_Key7.Text = "7";
            this.btn_Key7.UseVisualStyleBackColor = true;
            this.btn_Key7.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key3
            // 
            this.btn_Key3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key3.Location = new System.Drawing.Point(147, 15);
            this.btn_Key3.Name = "btn_Key3";
            this.btn_Key3.Size = new System.Drawing.Size(60, 60);
            this.btn_Key3.TabIndex = 0;
            this.btn_Key3.Text = "3";
            this.btn_Key3.UseVisualStyleBackColor = true;
            this.btn_Key3.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key4
            // 
            this.btn_Key4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key4.Location = new System.Drawing.Point(15, 81);
            this.btn_Key4.Name = "btn_Key4";
            this.btn_Key4.Size = new System.Drawing.Size(60, 60);
            this.btn_Key4.TabIndex = 0;
            this.btn_Key4.Text = "4";
            this.btn_Key4.UseVisualStyleBackColor = true;
            this.btn_Key4.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key2
            // 
            this.btn_Key2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key2.Location = new System.Drawing.Point(81, 15);
            this.btn_Key2.Name = "btn_Key2";
            this.btn_Key2.Size = new System.Drawing.Size(60, 60);
            this.btn_Key2.TabIndex = 0;
            this.btn_Key2.Text = "2";
            this.btn_Key2.UseVisualStyleBackColor = true;
            this.btn_Key2.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Key1
            // 
            this.btn_Key1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Key1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Key1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Key1.Location = new System.Drawing.Point(15, 15);
            this.btn_Key1.Name = "btn_Key1";
            this.btn_Key1.Size = new System.Drawing.Size(60, 60);
            this.btn_Key1.TabIndex = 0;
            this.btn_Key1.Text = "1";
            this.btn_Key1.UseVisualStyleBackColor = true;
            this.btn_Key1.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btn_Clear.Location = new System.Drawing.Point(336, 65);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 34);
            this.btn_Clear.TabIndex = 2;
            this.btn_Clear.Text = "Ryd";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 780);
            this.Controls.Add(this.pnl_Keyboard);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Customer);
            this.Controls.Add(this.dgv_POSTransaction);
            this.Name = "HistoryForm";
            this.Text = "Købs historik";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_POSTransaction)).EndInit();
            this.pnl_Keyboard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_POSTransaction;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Panel pnl_Keyboard;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Key9;
        private System.Windows.Forms.Button btn_Key8;
        private System.Windows.Forms.Button btn_Key6;
        private System.Windows.Forms.Button btn_Key0;
        private System.Windows.Forms.Button btn_Key5;
        private System.Windows.Forms.Button btn_Key7;
        private System.Windows.Forms.Button btn_Key3;
        private System.Windows.Forms.Button btn_Key4;
        private System.Windows.Forms.Button btn_Key2;
        private System.Windows.Forms.Button btn_Key1;
        private System.Windows.Forms.Button btn_Clear;
    }
}