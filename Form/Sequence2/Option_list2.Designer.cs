namespace PS_ELOAD_Serial
{
    partial class Option_list2
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewOptions2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridViewOptions2 = new System.Windows.Forms.DataGridView();
            this.DeleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOptions2
            // 
            this.dataGridViewOptions2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOptions2.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewOptions2.Name = "dataGridViewOptions2";
            this.dataGridViewOptions2.Size = new System.Drawing.Size(560, 300);
            this.dataGridViewOptions2.TabIndex = 0;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(472, 329);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 30);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // Option_list2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 379);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.dataGridViewOptions2);
            this.Name = "Option_list2";
            this.Text = "Program Setting Options";
            this.Load += new System.EventHandler(this.Option_list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOptions2)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button DeleteButton;
    }
}
