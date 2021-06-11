namespace client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.richTextBox_response = new System.Windows.Forms.RichTextBox();
            this.richTextBox_request = new System.Windows.Forms.RichTextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Response";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Request:";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(58, 74);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(243, 20);
            this.textBox_port.TabIndex = 3;
            // 
            // richTextBox_response
            // 
            this.richTextBox_response.Enabled = false;
            this.richTextBox_response.Location = new System.Drawing.Point(330, 74);
            this.richTextBox_response.Name = "richTextBox_response";
            this.richTextBox_response.Size = new System.Drawing.Size(430, 362);
            this.richTextBox_response.TabIndex = 4;
            this.richTextBox_response.Text = "";
            // 
            // richTextBox_request
            // 
            this.richTextBox_request.Location = new System.Drawing.Point(30, 145);
            this.richTextBox_request.Name = "richTextBox_request";
            this.richTextBox_request.Size = new System.Drawing.Size(271, 194);
            this.richTextBox_request.TabIndex = 5;
            this.richTextBox_request.Text = "";
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(93, 359);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(119, 44);
            this.button_send.TabIndex = 6;
            this.button_send.Text = "Send Request";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 479);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.richTextBox_request);
            this.Controls.Add(this.richTextBox_response);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.RichTextBox richTextBox_response;
        private System.Windows.Forms.RichTextBox richTextBox_request;
        private System.Windows.Forms.Button button_send;
    }
}

