
namespace LibraryClient
{
    partial class Form1
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
            this.UsertextBox = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Listing = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.NametextBox1 = new System.Windows.Forms.TextBox();
            this.CodetextBox2 = new System.Windows.Forms.TextBox();
            this.PricetextBox3 = new System.Windows.Forms.TextBox();
            this.Bye = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Buy = new System.Windows.Forms.Button();
            this.booksGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Register = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Register_Password = new System.Windows.Forms.TextBox();
            this.Register_Username = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.AuthortextBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Logout = new System.Windows.Forms.Button();
            this.CreateSale = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsertextBox
            // 
            this.UsertextBox.Location = new System.Drawing.Point(134, 12);
            this.UsertextBox.Name = "UsertextBox";
            this.UsertextBox.Size = new System.Drawing.Size(152, 20);
            this.UsertextBox.TabIndex = 0;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(540, 10);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 2;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Location = new System.Drawing.Point(382, 12);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.Size = new System.Drawing.Size(152, 20);
            this.PasswordtextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 382);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Status message";
            // 
            // Listing
            // 
            this.Listing.Location = new System.Drawing.Point(6, 198);
            this.Listing.Name = "Listing";
            this.Listing.Size = new System.Drawing.Size(152, 23);
            this.Listing.TabIndex = 5;
            this.Listing.Text = "List Books";
            this.Listing.UseVisualStyleBackColor = true;
            this.Listing.Click += new System.EventHandler(this.Listing_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(51, 113);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 11;
            this.Add.Text = "Submit";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // NametextBox1
            // 
            this.NametextBox1.Location = new System.Drawing.Point(51, 9);
            this.NametextBox1.Name = "NametextBox1";
            this.NametextBox1.Size = new System.Drawing.Size(183, 20);
            this.NametextBox1.TabIndex = 7;
            // 
            // CodetextBox2
            // 
            this.CodetextBox2.Location = new System.Drawing.Point(51, 61);
            this.CodetextBox2.Name = "CodetextBox2";
            this.CodetextBox2.Size = new System.Drawing.Size(97, 20);
            this.CodetextBox2.TabIndex = 9;
            // 
            // PricetextBox3
            // 
            this.PricetextBox3.Location = new System.Drawing.Point(51, 87);
            this.PricetextBox3.Name = "PricetextBox3";
            this.PricetextBox3.Size = new System.Drawing.Size(97, 20);
            this.PricetextBox3.TabIndex = 10;
            // 
            // Bye
            // 
            this.Bye.Location = new System.Drawing.Point(713, 10);
            this.Bye.Name = "Bye";
            this.Bye.Size = new System.Drawing.Size(75, 23);
            this.Bye.TabIndex = 10;
            this.Bye.Text = "Exit";
            this.Bye.UseVisualStyleBackColor = true;
            this.Bye.Click += new System.EventHandler(this.Bye_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(38, 109);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 253);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Buy);
            this.tabPage1.Controls.Add(this.booksGridView);
            this.tabPage1.Controls.Add(this.Listing);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(488, 227);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bookshelf";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Buy
            // 
            this.Buy.Enabled = false;
            this.Buy.Location = new System.Drawing.Point(407, 198);
            this.Buy.Name = "Buy";
            this.Buy.Size = new System.Drawing.Size(75, 23);
            this.Buy.TabIndex = 6;
            this.Buy.Text = "Buy";
            this.Buy.UseVisualStyleBackColor = true;
            this.Buy.Click += new System.EventHandler(this.Buy_Click);
            // 
            // booksGridView
            // 
            this.booksGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.booksGridView.Location = new System.Drawing.Point(6, 6);
            this.booksGridView.Name = "booksGridView";
            this.booksGridView.Size = new System.Drawing.Size(476, 186);
            this.booksGridView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Register);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.Register_Password);
            this.tabPage2.Controls.Add(this.Register_Username);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(488, 227);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(71, 84);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 4;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Password:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Username:";
            // 
            // Register_Password
            // 
            this.Register_Password.Location = new System.Drawing.Point(71, 58);
            this.Register_Password.Name = "Register_Password";
            this.Register_Password.Size = new System.Drawing.Size(100, 20);
            this.Register_Password.TabIndex = 1;
            // 
            // Register_Username
            // 
            this.Register_Username.Location = new System.Drawing.Point(71, 28);
            this.Register_Username.Name = "Register_Username";
            this.Register_Username.Size = new System.Drawing.Size(100, 20);
            this.Register_Username.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.AuthortextBox1);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.NametextBox1);
            this.tabPage3.Controls.Add(this.CodetextBox2);
            this.tabPage3.Controls.Add(this.PricetextBox3);
            this.tabPage3.Controls.Add(this.Add);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(488, 227);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Book Editor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Author:";
            // 
            // AuthortextBox1
            // 
            this.AuthortextBox1.Location = new System.Drawing.Point(51, 35);
            this.AuthortextBox1.Name = "AuthortextBox1";
            this.AuthortextBox1.Size = new System.Drawing.Size(183, 20);
            this.AuthortextBox1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Login username:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Login password:";
            // 
            // Logout
            // 
            this.Logout.Enabled = false;
            this.Logout.Location = new System.Drawing.Point(621, 10);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(75, 23);
            this.Logout.TabIndex = 14;
            this.Logout.Text = "Logout";
            this.Logout.UseVisualStyleBackColor = true;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // CreateSale
            // 
            this.CreateSale.Enabled = false;
            this.CreateSale.Location = new System.Drawing.Point(621, 131);
            this.CreateSale.Name = "CreateSale";
            this.CreateSale.Size = new System.Drawing.Size(120, 61);
            this.CreateSale.TabIndex = 15;
            this.CreateSale.Text = "CREATE SALE";
            this.CreateSale.UseVisualStyleBackColor = true;
            this.CreateSale.Click += new System.EventHandler(this.CreateSale_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreateSale);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Bye);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordtextBox);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.UsertextBox);
            this.Name = "Form1";
            this.Text = "Book Store";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.booksGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsertextBox;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Listing;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox NametextBox1;
        private System.Windows.Forms.TextBox CodetextBox2;
        private System.Windows.Forms.TextBox PricetextBox3;
        private System.Windows.Forms.Button Bye;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView booksGridView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AuthortextBox1;
        private System.Windows.Forms.Button Logout;
        private System.Windows.Forms.Button Buy;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Register_Password;
        private System.Windows.Forms.TextBox Register_Username;
        private System.Windows.Forms.Button CreateSale;
    }
}

