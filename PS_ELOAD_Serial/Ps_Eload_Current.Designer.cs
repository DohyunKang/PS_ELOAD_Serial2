﻿namespace PS_ELOAD_Serial
{
    partial class Ps_Eload_Current
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblVoltage_DAQ = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrent_DAQ = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ReadButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox5.Controls.Add(this.StopButton);
            this.groupBox5.Controls.Add(this.ReadButton);
            this.groupBox5.Controls.Add(this.lblVoltage_DAQ);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.lblCurrent_DAQ);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox5.Location = new System.Drawing.Point(13, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(459, 372);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "P/S <----> ELOAD";
            // 
            // lblVoltage_DAQ
            // 
            this.lblVoltage_DAQ.AutoSize = true;
            this.lblVoltage_DAQ.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVoltage_DAQ.Location = new System.Drawing.Point(301, 82);
            this.lblVoltage_DAQ.Name = "lblVoltage_DAQ";
            this.lblVoltage_DAQ.Size = new System.Drawing.Size(38, 37);
            this.lblVoltage_DAQ.TabIndex = 29;
            this.lblVoltage_DAQ.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(24, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 37);
            this.label1.TabIndex = 28;
            this.label1.Text = "AI VOLTAGE";
            // 
            // lblCurrent_DAQ
            // 
            this.lblCurrent_DAQ.AutoSize = true;
            this.lblCurrent_DAQ.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrent_DAQ.Location = new System.Drawing.Point(301, 210);
            this.lblCurrent_DAQ.Name = "lblCurrent_DAQ";
            this.lblCurrent_DAQ.Size = new System.Drawing.Size(38, 37);
            this.lblCurrent_DAQ.TabIndex = 27;
            this.lblCurrent_DAQ.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(17, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(237, 37);
            this.label11.TabIndex = 25;
            this.label11.Text = "AI CURRENT";
            // 
            // ReadButton
            // 
            this.ReadButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ReadButton.Location = new System.Drawing.Point(220, 297);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(88, 50);
            this.ReadButton.TabIndex = 42;
            this.ReadButton.Text = "READ";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.StopButton.Location = new System.Drawing.Point(346, 297);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(88, 50);
            this.StopButton.TabIndex = 43;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // Ps_Eload_Current
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 386);
            this.Controls.Add(this.groupBox5);
            this.Name = "Ps_Eload_Current";
            this.Text = "Ps_Eload_Current";
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblCurrent_DAQ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblVoltage_DAQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReadButton;
        private System.Windows.Forms.Button StopButton;
    }
}