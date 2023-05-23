namespace POS
{
    partial class POSForm
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
            this.lbl_hellomsg = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Purchase = new System.Windows.Forms.Button();
            this.txt_Customer = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_Toppanel = new System.Windows.Forms.Panel();
            this.btn_History = new System.Windows.Forms.Button();
            this.lbl_Header = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.lbl_LastPurchase = new System.Windows.Forms.Label();
            this.pnl_Customer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsv_ShoppingCart = new System.Windows.Forms.ListView();
            this.ch_ProductId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnl_Product = new System.Windows.Forms.Panel();
            this.pnl_Products = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbl_Price4 = new System.Windows.Forms.Label();
            this.lbl_Price1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_Price3 = new System.Windows.Forms.Label();
            this.lbl_Price2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
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
            this.pnl_Total = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.pnl_Toppanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.pnl_Bottom.SuspendLayout();
            this.pnl_Customer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Product.SuspendLayout();
            this.pnl_Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Keyboard.SuspendLayout();
            this.pnl_Total.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_hellomsg
            // 
            this.lbl_hellomsg.AutoSize = true;
            this.lbl_hellomsg.Location = new System.Drawing.Point(98, 198);
            this.lbl_hellomsg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_hellomsg.Name = "lbl_hellomsg";
            this.lbl_hellomsg.Size = new System.Drawing.Size(0, 21);
            this.lbl_hellomsg.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Medlemsnummer";
            // 
            // btn_Purchase
            // 
            this.btn_Purchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Purchase.Location = new System.Drawing.Point(528, 6);
            this.btn_Purchase.Name = "btn_Purchase";
            this.btn_Purchase.Size = new System.Drawing.Size(127, 45);
            this.btn_Purchase.TabIndex = 5;
            this.btn_Purchase.Text = "Køb";
            this.btn_Purchase.UseVisualStyleBackColor = true;
            this.btn_Purchase.Click += new System.EventHandler(this.btn_Purchase_Click);
            // 
            // txt_Customer
            // 
            this.txt_Customer.Location = new System.Drawing.Point(21, 37);
            this.txt_Customer.Name = "txt_Customer";
            this.txt_Customer.Size = new System.Drawing.Size(117, 27);
            this.txt_Customer.TabIndex = 1;
            this.txt_Customer.TextChanged += new System.EventHandler(this.txt_Customer_TextChanged);
            this.txt_Customer.Enter += new System.EventHandler(this.txt_Customer_Enter);
            this.txt_Customer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Customer_KeyDown);
            this.txt_Customer.Leave += new System.EventHandler(this.txt_Customer_Leave);
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(172, 37);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(388, 27);
            this.txt_Name.TabIndex = 11;
            this.txt_Name.TabStop = false;
            this.txt_Name.TextChanged += new System.EventHandler(this.txt_Name_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Navn";
            // 
            // pnl_Toppanel
            // 
            this.pnl_Toppanel.BackColor = System.Drawing.Color.White;
            this.pnl_Toppanel.Controls.Add(this.btn_History);
            this.pnl_Toppanel.Controls.Add(this.lbl_Header);
            this.pnl_Toppanel.Controls.Add(this.btn_Close);
            this.pnl_Toppanel.Controls.Add(this.pic_Logo);
            this.pnl_Toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Toppanel.Location = new System.Drawing.Point(0, 0);
            this.pnl_Toppanel.Name = "pnl_Toppanel";
            this.pnl_Toppanel.Size = new System.Drawing.Size(800, 64);
            this.pnl_Toppanel.TabIndex = 100;
            this.pnl_Toppanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Toppanel_Paint);
            // 
            // btn_History
            // 
            this.btn_History.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_History.Location = new System.Drawing.Point(639, 12);
            this.btn_History.Name = "btn_History";
            this.btn_History.Size = new System.Drawing.Size(88, 33);
            this.btn_History.TabIndex = 2;
            this.btn_History.Text = "Historik";
            this.btn_History.UseVisualStyleBackColor = true;
            this.btn_History.Click += new System.EventHandler(this.btn_History_Click);
            // 
            // lbl_Header
            // 
            this.lbl_Header.AutoSize = true;
            this.lbl_Header.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Header.Location = new System.Drawing.Point(230, 20);
            this.lbl_Header.Name = "lbl_Header";
            this.lbl_Header.Size = new System.Drawing.Size(149, 25);
            this.lbl_Header.TabIndex = 3;
            this.lbl_Header.Text = "Selvbetjening";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Red;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(733, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(55, 33);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "Luk";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pic_Logo
            // 
            this.pic_Logo.ImageLocation = "";
            this.pic_Logo.Location = new System.Drawing.Point(3, 3);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(100, 50);
            this.pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_Logo.TabIndex = 1;
            this.pic_Logo.TabStop = false;
            this.pic_Logo.Click += new System.EventHandler(this.pic_Logo_Click);
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.BackColor = System.Drawing.Color.White;
            this.pnl_Bottom.Controls.Add(this.lbl_LastPurchase);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 570);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(800, 30);
            this.pnl_Bottom.TabIndex = 101;
            // 
            // lbl_LastPurchase
            // 
            this.lbl_LastPurchase.AutoSize = true;
            this.lbl_LastPurchase.Location = new System.Drawing.Point(4, 3);
            this.lbl_LastPurchase.Name = "lbl_LastPurchase";
            this.lbl_LastPurchase.Size = new System.Drawing.Size(137, 21);
            this.lbl_LastPurchase.TabIndex = 0;
            this.lbl_LastPurchase.Text = "lbl_LastPurchase";
            // 
            // pnl_Customer
            // 
            this.pnl_Customer.Controls.Add(this.panel1);
            this.pnl_Customer.Controls.Add(this.pnl_Product);
            this.pnl_Customer.Controls.Add(this.pnl_Total);
            this.pnl_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Customer.Location = new System.Drawing.Point(0, 64);
            this.pnl_Customer.Name = "pnl_Customer";
            this.pnl_Customer.Size = new System.Drawing.Size(800, 506);
            this.pnl_Customer.TabIndex = 102;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsv_ShoppingCart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 154);
            this.panel1.TabIndex = 104;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lsv_ShoppingCart
            // 
            this.lsv_ShoppingCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_ProductId,
            this.ch_Product,
            this.ch_Qty,
            this.ch_Price,
            this.ch_Total});
            this.lsv_ShoppingCart.HideSelection = false;
            this.lsv_ShoppingCart.Location = new System.Drawing.Point(0, 0);
            this.lsv_ShoppingCart.Name = "lsv_ShoppingCart";
            this.lsv_ShoppingCart.Size = new System.Drawing.Size(800, 157);
            this.lsv_ShoppingCart.TabIndex = 13;
            this.lsv_ShoppingCart.TabStop = false;
            this.lsv_ShoppingCart.UseCompatibleStateImageBehavior = false;
            this.lsv_ShoppingCart.View = System.Windows.Forms.View.Details;
            this.lsv_ShoppingCart.SelectedIndexChanged += new System.EventHandler(this.lsv_ShoppingCart_SelectedIndexChanged);
            // 
            // ch_ProductId
            // 
            this.ch_ProductId.Text = "Varenummer";
            this.ch_ProductId.Width = 0;
            // 
            // ch_Product
            // 
            this.ch_Product.Text = "Produkt";
            // 
            // ch_Qty
            // 
            this.ch_Qty.Text = "Antal";
            this.ch_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ch_Price
            // 
            this.ch_Price.Text = "Pris";
            this.ch_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ch_Total
            // 
            this.ch_Total.Text = "Total";
            this.ch_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnl_Product
            // 
            this.pnl_Product.Controls.Add(this.pnl_Products);
            this.pnl_Product.Controls.Add(this.button2);
            this.pnl_Product.Controls.Add(this.pnl_Keyboard);
            this.pnl_Product.Controls.Add(this.label2);
            this.pnl_Product.Controls.Add(this.txt_Customer);
            this.pnl_Product.Controls.Add(this.txt_Name);
            this.pnl_Product.Controls.Add(this.label5);
            this.pnl_Product.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Product.Location = new System.Drawing.Point(0, 0);
            this.pnl_Product.Name = "pnl_Product";
            this.pnl_Product.Size = new System.Drawing.Size(800, 296);
            this.pnl_Product.TabIndex = 103;
            this.pnl_Product.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Product_Paint);
            // 
            // pnl_Products
            // 
            this.pnl_Products.Controls.Add(this.pictureBox3);
            this.pnl_Products.Controls.Add(this.lbl_Price4);
            this.pnl_Products.Controls.Add(this.lbl_Price1);
            this.pnl_Products.Controls.Add(this.pictureBox4);
            this.pnl_Products.Controls.Add(this.pictureBox2);
            this.pnl_Products.Controls.Add(this.lbl_Price3);
            this.pnl_Products.Controls.Add(this.lbl_Price2);
            this.pnl_Products.Controls.Add(this.pictureBox1);
            this.pnl_Products.Location = new System.Drawing.Point(5, 70);
            this.pnl_Products.Name = "pnl_Products";
            this.pnl_Products.Size = new System.Drawing.Size(554, 218);
            this.pnl_Products.TabIndex = 16;
            this.pnl_Products.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Products_Paint);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(282, 17);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 128);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbl_Price4
            // 
            this.lbl_Price4.AutoSize = true;
            this.lbl_Price4.Location = new System.Drawing.Point(445, 148);
            this.lbl_Price4.Name = "lbl_Price4";
            this.lbl_Price4.Size = new System.Drawing.Size(71, 21);
            this.lbl_Price4.TabIndex = 14;
            this.lbl_Price4.Text = "100 DKK";
            // 
            // lbl_Price1
            // 
            this.lbl_Price1.AutoSize = true;
            this.lbl_Price1.Location = new System.Drawing.Point(43, 148);
            this.lbl_Price1.Name = "lbl_Price1";
            this.lbl_Price1.Size = new System.Drawing.Size(71, 21);
            this.lbl_Price1.TabIndex = 14;
            this.lbl_Price1.Text = "100 DKK";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(416, 17);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(128, 128);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(148, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbl_Price3
            // 
            this.lbl_Price3.AutoSize = true;
            this.lbl_Price3.Location = new System.Drawing.Point(310, 148);
            this.lbl_Price3.Name = "lbl_Price3";
            this.lbl_Price3.Size = new System.Drawing.Size(71, 21);
            this.lbl_Price3.TabIndex = 14;
            this.lbl_Price3.Text = "100 DKK";
            // 
            // lbl_Price2
            // 
            this.lbl_Price2.AutoSize = true;
            this.lbl_Price2.Location = new System.Drawing.Point(180, 148);
            this.lbl_Price2.Name = "lbl_Price2";
            this.lbl_Price2.Size = new System.Drawing.Size(71, 21);
            this.lbl_Price2.TabIndex = 14;
            this.lbl_Price2.Text = "100 DKK";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(14, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1014, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 43);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
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
            this.pnl_Keyboard.Location = new System.Drawing.Point(566, 6);
            this.pnl_Keyboard.Name = "pnl_Keyboard";
            this.pnl_Keyboard.Size = new System.Drawing.Size(222, 283);
            this.pnl_Keyboard.TabIndex = 13;
            // 
            // btn_Enter
            // 
            this.btn_Enter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Enter.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Enter.Location = new System.Drawing.Point(81, 213);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(126, 60);
            this.btn_Enter.TabIndex = 20;
            this.btn_Enter.TabStop = false;
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
            this.btn_Key9.TabIndex = 18;
            this.btn_Key9.TabStop = false;
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
            this.btn_Key8.TabIndex = 17;
            this.btn_Key8.TabStop = false;
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
            this.btn_Key6.TabIndex = 15;
            this.btn_Key6.TabStop = false;
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
            this.btn_Key0.TabIndex = 19;
            this.btn_Key0.TabStop = false;
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
            this.btn_Key5.TabIndex = 14;
            this.btn_Key5.TabStop = false;
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
            this.btn_Key7.TabIndex = 16;
            this.btn_Key7.TabStop = false;
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
            this.btn_Key3.TabIndex = 12;
            this.btn_Key3.TabStop = false;
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
            this.btn_Key4.TabIndex = 13;
            this.btn_Key4.TabStop = false;
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
            this.btn_Key2.TabIndex = 11;
            this.btn_Key2.TabStop = false;
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
            this.btn_Key1.TabIndex = 10;
            this.btn_Key1.TabStop = false;
            this.btn_Key1.Text = "1";
            this.btn_Key1.UseVisualStyleBackColor = true;
            this.btn_Key1.Click += new System.EventHandler(this.btn_Key1_Click);
            // 
            // pnl_Total
            // 
            this.pnl_Total.Controls.Add(this.btn_Cancel);
            this.pnl_Total.Controls.Add(this.btn_Purchase);
            this.pnl_Total.Controls.Add(this.label1);
            this.pnl_Total.Controls.Add(this.txt_Total);
            this.pnl_Total.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Total.Location = new System.Drawing.Point(0, 450);
            this.pnl_Total.Name = "pnl_Total";
            this.pnl_Total.Size = new System.Drawing.Size(800, 56);
            this.pnl_Total.TabIndex = 102;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Location = new System.Drawing.Point(661, 6);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(127, 45);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Fortryd";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 21);
            this.label1.TabIndex = 100;
            this.label1.Text = "Total";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_Total
            // 
            this.txt_Total.Location = new System.Drawing.Point(182, 14);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(67, 27);
            this.txt_Total.TabIndex = 14;
            this.txt_Total.TabStop = false;
            // 
            // POSForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnl_Customer);
            this.Controls.Add(this.pnl_Bottom);
            this.Controls.Add(this.pnl_Toppanel);
            this.Controls.Add(this.lbl_hellomsg);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "POSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl_Toppanel.ResumeLayout(false);
            this.pnl_Toppanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.pnl_Bottom.ResumeLayout(false);
            this.pnl_Bottom.PerformLayout();
            this.pnl_Customer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnl_Product.ResumeLayout(false);
            this.pnl_Product.PerformLayout();
            this.pnl_Products.ResumeLayout(false);
            this.pnl_Products.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_Keyboard.ResumeLayout(false);
            this.pnl_Total.ResumeLayout(false);
            this.pnl_Total.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_hellomsg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Purchase;
        private System.Windows.Forms.TextBox txt_Customer;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnl_Toppanel;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel pnl_Customer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView lsv_ShoppingCart;
        private System.Windows.Forms.ColumnHeader ch_Product;
        private System.Windows.Forms.ColumnHeader ch_Qty;
        private System.Windows.Forms.ColumnHeader ch_Price;
        private System.Windows.Forms.ColumnHeader ch_Total;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label lbl_LastPurchase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_Product;
        private System.Windows.Forms.Panel pnl_Total;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_Header;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_History;
        private System.Windows.Forms.ColumnHeader ch_ProductId;
        private System.Windows.Forms.Panel pnl_Keyboard;
        private System.Windows.Forms.Button btn_Key3;
        private System.Windows.Forms.Button btn_Key2;
        private System.Windows.Forms.Button btn_Key1;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_Key9;
        private System.Windows.Forms.Button btn_Key8;
        private System.Windows.Forms.Button btn_Key6;
        private System.Windows.Forms.Button btn_Key0;
        private System.Windows.Forms.Button btn_Key5;
        private System.Windows.Forms.Button btn_Key7;
        private System.Windows.Forms.Button btn_Key4;
        private System.Windows.Forms.Label lbl_Price4;
        private System.Windows.Forms.Label lbl_Price3;
        private System.Windows.Forms.Label lbl_Price2;
        private System.Windows.Forms.Label lbl_Price1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnl_Products;
    }
}

