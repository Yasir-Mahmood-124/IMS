namespace IME
{
    partial class SignUp
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            signUPbutton = new Guna.UI2.WinForms.Guna2CircleButton();
            nameBox = new TextBox();
            label1 = new Label();
            emailBox = new TextBox();
            passwordbox = new TextBox();
            userbox = new TextBox();
            phonebox = new TextBox();
            usertype = new Guna.UI2.WinForms.Guna2ComboBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
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
            tableLayoutPanel1.Size = new Size(1180, 689);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.i;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(515, 683);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(224, 224, 224);
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 433F));
            tableLayoutPanel2.Controls.Add(signUPbutton, 0, 6);
            tableLayoutPanel2.Controls.Add(nameBox, 1, 1);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(emailBox, 1, 2);
            tableLayoutPanel2.Controls.Add(passwordbox, 1, 3);
            tableLayoutPanel2.Controls.Add(userbox, 1, 4);
            tableLayoutPanel2.Controls.Add(phonebox, 1, 5);
            tableLayoutPanel2.Controls.Add(usertype, 1, 6);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(524, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857132F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857161F));
            tableLayoutPanel2.Size = new Size(653, 683);
            tableLayoutPanel2.TabIndex = 1;
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
            signUPbutton.Location = new Point(3, 585);
            signUPbutton.Name = "signUPbutton";
            signUPbutton.PressedColor = Color.FromArgb(128, 255, 128);
            signUPbutton.ShadowDecoration.CustomizableEdges = customizableEdges1;
            signUPbutton.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            signUPbutton.Size = new Size(214, 95);
            signUPbutton.TabIndex = 8;
            signUPbutton.Text = "SIGN UP";
            signUPbutton.Click += signUPbutton_Click;
            // 
            // nameBox
            // 
            nameBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameBox.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nameBox.Location = new Point(223, 130);
            nameBox.Name = "nameBox";
            nameBox.PlaceholderText = "Name";
            nameBox.Size = new Size(427, 30);
            nameBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 35);
            label1.Name = "label1";
            label1.Size = new Size(214, 26);
            label1.TabIndex = 2;
            label1.Text = "SIGN UP NOW";
            // 
            // emailBox
            // 
            emailBox.AllowDrop = true;
            emailBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            emailBox.BackColor = Color.White;
            emailBox.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            emailBox.Location = new Point(223, 227);
            emailBox.Name = "emailBox";
            emailBox.PlaceholderText = "Email";
            emailBox.Size = new Size(427, 30);
            emailBox.TabIndex = 3;
            emailBox.Validating += emailBox_Validating;
            // 
            // passwordbox
            // 
            passwordbox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            passwordbox.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordbox.Location = new Point(223, 324);
            passwordbox.Name = "passwordbox";
            passwordbox.PlaceholderText = "Password";
            passwordbox.Size = new Size(427, 30);
            passwordbox.TabIndex = 4;
            passwordbox.Validating += passwordbox_Validating;
            // 
            // userbox
            // 
            userbox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            userbox.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            userbox.Location = new Point(223, 421);
            userbox.Name = "userbox";
            userbox.PlaceholderText = "User Name";
            userbox.Size = new Size(427, 30);
            userbox.TabIndex = 5;
            // 
            // phonebox
            // 
            phonebox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            phonebox.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point);
            phonebox.Location = new Point(223, 518);
            phonebox.Name = "phonebox";
            phonebox.PlaceholderText = "Phone_Number(03XX)";
            phonebox.Size = new Size(427, 30);
            phonebox.TabIndex = 6;
            phonebox.Validating += phonebox_Validating;
            // 
            // usertype
            // 
            usertype.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            usertype.BackColor = Color.White;
            usertype.BorderColor = Color.Black;
            usertype.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            usertype.CustomizableEdges = customizableEdges2;
            usertype.DrawMode = DrawMode.OwnerDrawFixed;
            usertype.DropDownStyle = ComboBoxStyle.DropDownList;
            usertype.FocusedColor = Color.FromArgb(94, 148, 255);
            usertype.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            usertype.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point);
            usertype.ForeColor = Color.FromArgb(68, 88, 112);
            usertype.ItemHeight = 30;
            usertype.Items.AddRange(new object[] { "Teacher", "Student" });
            usertype.Location = new Point(223, 614);
            usertype.Name = "usertype";
            usertype.ShadowDecoration.CustomizableEdges = customizableEdges3;
            usertype.Size = new Size(427, 36);
            usertype.TabIndex = 9;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "SignUp";
            Size = new Size(1180, 689);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox nameBox;
        private Label label1;
        private TextBox emailBox;
        private TextBox passwordbox;
        private TextBox userbox;
        private TextBox phonebox;
        private Guna.UI2.WinForms.Guna2CircleButton signUPbutton;
        private Guna.UI2.WinForms.Guna2ComboBox usertype;
    }
}
