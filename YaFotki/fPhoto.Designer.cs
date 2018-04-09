namespace YaFotki
{
	partial class fPhoto
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
			this.lTitle = new System.Windows.Forms.Label();
			this.tMeta = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lTitle
			// 
			this.lTitle.AutoSize = true;
			this.lTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lTitle.Location = new System.Drawing.Point(13, 13);
			this.lTitle.Name = "lTitle";
			this.lTitle.Size = new System.Drawing.Size(114, 24);
			this.lTitle.TabIndex = 1;
			this.lTitle.Text = "Заголовок";
			// 
			// tMeta
			// 
			this.tMeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tMeta.Location = new System.Drawing.Point(502, 40);
			this.tMeta.Multiline = true;
			this.tMeta.Name = "tMeta";
			this.tMeta.ReadOnly = true;
			this.tMeta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tMeta.Size = new System.Drawing.Size(270, 377);
			this.tMeta.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Image = global::YaFotki.Properties.Resources.Save_6530;
			this.button1.Location = new System.Drawing.Point(749, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(23, 23);
			this.button1.TabIndex = 3;
			this.button1.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.pictureBox1.Location = new System.Drawing.Point(12, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(484, 377);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 420);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(784, 22);
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lStatus
			// 
			this.lStatus.Name = "lStatus";
			this.lStatus.Size = new System.Drawing.Size(80, 17);
			this.lStatus.Text = "Подготовка...";
			// 
			// fPhoto
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 442);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tMeta);
			this.Controls.Add(this.lTitle);
			this.Controls.Add(this.pictureBox1);
			this.Name = "fPhoto";
			this.Text = "Фотография";
			this.Load += new System.EventHandler(this.fPhoto_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lTitle;
		private System.Windows.Forms.TextBox tMeta;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lStatus;
	}
}