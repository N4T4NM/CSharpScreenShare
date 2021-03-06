﻿namespace ScreenShare
{
    partial class MainForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ShareScreenButton = new System.Windows.Forms.Button();
            this.ImageHolderPanel = new System.Windows.Forms.Panel();
            this.MouseInputBox = new System.Windows.Forms.CheckBox();
            this.KeyboardInputBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.KeyboardInputBox);
            this.panel1.Controls.Add(this.MouseInputBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.IPBox);
            this.panel1.Controls.Add(this.ConnectButton);
            this.panel1.Controls.Add(this.ShareScreenButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 42);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(87, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(87, 16);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(152, 20);
            this.IPBox.TabIndex = 2;
            // 
            // ConnectButton
            // 
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ConnectButton.Location = new System.Drawing.Point(245, 3);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(96, 36);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            this.ConnectButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ConnectButton_KeyUp);
            // 
            // ShareScreenButton
            // 
            this.ShareScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShareScreenButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ShareScreenButton.Location = new System.Drawing.Point(3, 3);
            this.ShareScreenButton.Name = "ShareScreenButton";
            this.ShareScreenButton.Size = new System.Drawing.Size(46, 36);
            this.ShareScreenButton.TabIndex = 0;
            this.ShareScreenButton.Text = "Share";
            this.ShareScreenButton.UseVisualStyleBackColor = true;
            this.ShareScreenButton.Click += new System.EventHandler(this.ShareScreenButton_Click);
            // 
            // ImageHolderPanel
            // 
            this.ImageHolderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageHolderPanel.Location = new System.Drawing.Point(0, 42);
            this.ImageHolderPanel.Name = "ImageHolderPanel";
            this.ImageHolderPanel.Size = new System.Drawing.Size(719, 465);
            this.ImageHolderPanel.TabIndex = 1;
            // 
            // MouseInputBox
            // 
            this.MouseInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MouseInputBox.AutoSize = true;
            this.MouseInputBox.Checked = true;
            this.MouseInputBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MouseInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MouseInputBox.ForeColor = System.Drawing.Color.White;
            this.MouseInputBox.Location = new System.Drawing.Point(405, 20);
            this.MouseInputBox.Name = "MouseInputBox";
            this.MouseInputBox.Size = new System.Drawing.Size(126, 19);
            this.MouseInputBox.TabIndex = 4;
            this.MouseInputBox.Text = "Send Mouse Input";
            this.MouseInputBox.UseVisualStyleBackColor = true;
            this.MouseInputBox.Enter += new System.EventHandler(this.MouseInputBox_Enter);
            // 
            // KeyboardInputBox
            // 
            this.KeyboardInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyboardInputBox.AutoSize = true;
            this.KeyboardInputBox.Checked = true;
            this.KeyboardInputBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KeyboardInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyboardInputBox.ForeColor = System.Drawing.Color.White;
            this.KeyboardInputBox.Location = new System.Drawing.Point(567, 20);
            this.KeyboardInputBox.Name = "KeyboardInputBox";
            this.KeyboardInputBox.Size = new System.Drawing.Size(140, 19);
            this.KeyboardInputBox.TabIndex = 5;
            this.KeyboardInputBox.Text = "Send Keyboard Input";
            this.KeyboardInputBox.UseVisualStyleBackColor = true;
            this.KeyboardInputBox.Enter += new System.EventHandler(this.KeyboardInputBox_Enter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(719, 507);
            this.Controls.Add(this.ImageHolderPanel);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Screen Share";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ShareScreenButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Panel ImageHolderPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.CheckBox MouseInputBox;
        private System.Windows.Forms.CheckBox KeyboardInputBox;
    }
}

