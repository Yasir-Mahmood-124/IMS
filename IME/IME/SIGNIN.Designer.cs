namespace IME
{
    partial class SIGNIN
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            userBox = new TextBox();
            passwordbox = new TextBox();
            usertype = new Guna.UI2.WinForms.Guna2ComboBox();
            signUPbutton = new Guna.UI2.WinForms.Guna2CircleButton();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.i;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(493, 659);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.1525421F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.8474579F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.15675F));
            tableLayoutPanel1.Size = new Size(1132, 665);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(224, 224, 224);
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 433F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(userBox, 1, 1);
            tableLayoutPanel2.Controls.Add(passwordbox, 1, 2);
            tableLayoutPanel2.Controls.Add(usertype, 1, 3);
            tableLayoutPanel2.Controls.Add(signUPbutton, 1, 4);
            tableLayoutPanel2.Controls.Add(label2, 1, 5);
            tableLayoutPanel2.Controls.Add(button1, 1, 6);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(502, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857132F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.Size = new Size(627, 659);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 34);
            label1.Name = "label1";
            label1.Size = new Size(188, 26);
            label1.TabIndex = 2;
            label1.Text = "SIGN In NOW";
            // 
            // userBox
            // 
            userBox.AllowDrop = true;
            userBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userBox.BackColor = Color.White;
            userBox.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            userBox.Location = new Point(197, 126);
            userBox.Name = "userBox";
            userBox.PlaceholderText = "User Name";
            userBox.Size = new Size(427, 30);
            userBox.TabIndex = 3;
            // 
            // passwordbox
            // 
            passwordbox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            passwordbox.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordbox.Location = new Point(197, 220);
            passwordbox.Name = "passwordbox";
            passwordbox.PlaceholderText = "Password";
            passwordbox.Size = new Size(427, 30);
            passwordbox.TabIndex = 4;
            // 
            // usertype
            // 
            usertype.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            usertype.BackColor = Color.White;
            usertype.BorderColor = Color.Black;
            usertype.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            usertype.CustomizableEdges = customizableEdges10;
            usertype.DrawMode = DrawMode.OwnerDrawFixed;
            usertype.DropDownStyle = ComboBoxStyle.DropDownList;
            usertype.FocusedColor = Color.FromArgb(94, 148, 255);
            usertype.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            usertype.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            usertype.ForeColor = Color.FromArgb(68, 88, 112);
            usertype.ItemHeight = 30;
            usertype.Items.AddRange(new object[] { "Teacher", "Student", "Admin" });
            usertype.Location = new Point(197, 311);
            usertype.Name = "usertype";
            usertype.ShadowDecoration.CustomizableEdges = customizableEdges11;
            usertype.Size = new Size(427, 36);
            usertype.TabIndex = 9;
            // 
            // signUPbutton
            // 
            signUPbutton.BackColor = Color.Silver;
            signUPbutton.CustomBorderColor = Color.Gray;
            signUPbutton.DisabledState.BorderColor = Color.DarkGray;
            signUPbutton.DisabledState.CustomBorderColor = Color.DarkGray;
            signUPbutton.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            signUPbutton.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            signUPbutton.FillColor = Color.WhiteSmoke;
            signUPbutton.FocusedColor = Color.Black;
            signUPbutton.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            signUPbutton.ForeColor = Color.Black;
            signUPbutton.Location = new Point(197, 379);
            signUPbutton.Name = "signUPbutton";
            signUPbutton.PressedColor = Color.FromArgb(128, 255, 128);
            signUPbutton.ShadowDecoration.CustomizableEdges = customizableEdges12;
            signUPbutton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            signUPbutton.Size = new Size(208, 88);
            signUPbutton.TabIndex = 8;
            signUPbutton.Text = "SIGN IN";
            signUPbutton.Click += signUPbutton_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(255, 128, 128);
            label2.Location = new Point(197, 492);
            label2.Name = "label2";
            label2.Size = new Size(383, 50);
            label2.TabIndex = 10;
            label2.Text = "If you don't have account then click on signup button";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(197, 567);
            button1.Name = "button1";
            button1.Size = new Size(214, 89);
            button1.TabIndex = 11;
            button1.Text = "Sign UP ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // SIGNIN
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "SIGNIN";
            Size = new Size(1132, 665);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2CircleButton signUPbutton;
        private Label label1;
        private TextBox userBox;
        private TextBox passwordbox;
        private Guna.UI2.WinForms.Guna2ComboBox usertype;
        private Label label2;
        private Button button1;
    }
}
