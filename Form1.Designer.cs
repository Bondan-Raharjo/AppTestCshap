namespace AppTestCshap
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
            this.msg_List = new System.Windows.Forms.RichTextBox();
            this.btn_Scan = new System.Windows.Forms.Button();
            this.msg_port = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_conn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_reci = new System.Windows.Forms.Button();
            this.multi_Read = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // msg_List
            // 
            this.msg_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msg_List.Location = new System.Drawing.Point(12, 225);
            this.msg_List.Name = "msg_List";
            this.msg_List.Size = new System.Drawing.Size(340, 53);
            this.msg_List.TabIndex = 0;
            this.msg_List.Text = "";
            // 
            // btn_Scan
            // 
            this.btn_Scan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Scan.AutoSize = true;
            this.btn_Scan.Location = new System.Drawing.Point(196, 68);
            this.btn_Scan.Name = "btn_Scan";
            this.btn_Scan.Size = new System.Drawing.Size(75, 25);
            this.btn_Scan.TabIndex = 1;
            this.btn_Scan.Text = "Scan";
            this.btn_Scan.UseVisualStyleBackColor = true;
            this.btn_Scan.Click += new System.EventHandler(this.btn_Scan_Click);
            // 
            // msg_port
            // 
            this.msg_port.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msg_port.FormattingEnabled = true;
            this.msg_port.Location = new System.Drawing.Point(12, 30);
            this.msg_port.Name = "msg_port";
            this.msg_port.Size = new System.Drawing.Size(340, 23);
            this.msg_port.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Port List";
            // 
            // btn_conn
            // 
            this.btn_conn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_conn.AutoSize = true;
            this.btn_conn.Location = new System.Drawing.Point(277, 68);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(75, 25);
            this.btn_conn.TabIndex = 4;
            this.btn_conn.Text = "Connect";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Send Data";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 23);
            this.textBox1.TabIndex = 6;
            // 
            // btn_Send
            // 
            this.btn_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Send.AutoSize = true;
            this.btn_Send.Location = new System.Drawing.Point(277, 132);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 25);
            this.btn_Send.TabIndex = 7;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Console";
            // 
            // btn_reci
            // 
            this.btn_reci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reci.AutoSize = true;
            this.btn_reci.Location = new System.Drawing.Point(277, 184);
            this.btn_reci.Name = "btn_reci";
            this.btn_reci.Size = new System.Drawing.Size(75, 25);
            this.btn_reci.TabIndex = 9;
            this.btn_reci.Text = "Recived";
            this.btn_reci.UseVisualStyleBackColor = true;
            this.btn_reci.Click += new System.EventHandler(this.btn_reci_Click);
            // 
            // multi_Read
            // 
            this.multi_Read.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multi_Read.AutoSize = true;
            this.multi_Read.Location = new System.Drawing.Point(173, 187);
            this.multi_Read.Name = "multi_Read";
            this.multi_Read.Size = new System.Drawing.Size(98, 19);
            this.multi_Read.TabIndex = 10;
            this.multi_Read.TabStop = true;
            this.multi_Read.Text = "Multiple Read";
            this.multi_Read.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(364, 299);
            this.Controls.Add(this.multi_Read);
            this.Controls.Add(this.btn_reci);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_conn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msg_port);
            this.Controls.Add(this.btn_Scan);
            this.Controls.Add(this.msg_List);
            this.MinimumSize = new System.Drawing.Size(380, 338);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Console App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox msg_List;
        private Button btn_Scan;
        private ComboBox msg_port;
        private Label label1;
        private Button btn_conn;
        private Label label2;
        private TextBox textBox1;
        private Button btn_Send;
        private Label label3;
        private Button btn_reci;
        private RadioButton multi_Read;
    }
}