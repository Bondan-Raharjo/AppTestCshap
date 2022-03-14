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
            this.SuspendLayout();
            // 
            // msg_List
            // 
            this.msg_List.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msg_List.Location = new System.Drawing.Point(12, 162);
            this.msg_List.Name = "msg_List";
            this.msg_List.Size = new System.Drawing.Size(340, 76);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 285);
            this.Controls.Add(this.btn_conn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msg_port);
            this.Controls.Add(this.btn_Scan);
            this.Controls.Add(this.msg_List);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
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
    }
}