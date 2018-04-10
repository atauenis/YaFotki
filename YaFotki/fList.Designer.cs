namespace YaFotki
{
	partial class fList
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
			this.lAuthor = new System.Windows.Forms.Label();
			this.lUpdated = new System.Windows.Forms.Label();
			this.bNext = new System.Windows.Forms.Button();
			this.lbItems = new System.Windows.Forms.ListBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.bSave = new System.Windows.Forms.Button();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lAuthor
			// 
			this.lAuthor.AutoSize = true;
			this.lAuthor.Location = new System.Drawing.Point(12, 9);
			this.lAuthor.Name = "lAuthor";
			this.lAuthor.Size = new System.Drawing.Size(37, 13);
			this.lAuthor.TabIndex = 0;
			this.lAuthor.Text = "Автор";
			// 
			// lUpdated
			// 
			this.lUpdated.AutoSize = true;
			this.lUpdated.Location = new System.Drawing.Point(12, 22);
			this.lUpdated.Name = "lUpdated";
			this.lUpdated.Size = new System.Drawing.Size(63, 13);
			this.lUpdated.TabIndex = 1;
			this.lUpdated.Text = "Обновлено";
			// 
			// bNext
			// 
			this.bNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bNext.Enabled = false;
			this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bNext.Location = new System.Drawing.Point(447, 9);
			this.bNext.Name = "bNext";
			this.bNext.Size = new System.Drawing.Size(75, 23);
			this.bNext.TabIndex = 2;
			this.bNext.Text = "Далее";
			this.bNext.UseVisualStyleBackColor = true;
			this.bNext.Click += new System.EventHandler(this.bNext_Click);
			// 
			// lbItems
			// 
			this.lbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbItems.FormattingEnabled = true;
			this.lbItems.Location = new System.Drawing.Point(15, 39);
			this.lbItems.Name = "lbItems";
			this.lbItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbItems.Size = new System.Drawing.Size(507, 485);
			this.lbItems.TabIndex = 3;
			this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lbItems_SelectedIndexChanged);
			this.lbItems.DoubleClick += new System.EventHandler(this.lbItems_DoubleClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 540);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(534, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lStatus
			// 
			this.lStatus.Name = "lStatus";
			this.lStatus.Size = new System.Drawing.Size(80, 17);
			this.lStatus.Text = "Подготовка...";
			// 
			// bSave
			// 
			this.bSave.Image = global::YaFotki.Properties.Resources.Save_6530;
			this.bSave.Location = new System.Drawing.Point(418, 9);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(23, 23);
			this.bSave.TabIndex = 5;
			this.bSave.TabStop = false;
			this.bSave.UseVisualStyleBackColor = true;
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// fList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 562);
			this.Controls.Add(this.bSave);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.lbItems);
			this.Controls.Add(this.bNext);
			this.Controls.Add(this.lUpdated);
			this.Controls.Add(this.lAuthor);
			this.Name = "fList";
			this.Text = "Каталог";
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lAuthor;
		private System.Windows.Forms.Label lUpdated;
		private System.Windows.Forms.Button bNext;
		private System.Windows.Forms.ListBox lbItems;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lStatus;
		private System.Windows.Forms.Button bSave;
	}
}