namespace YaFotki
{
	partial class fMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
			this.lLocal = new System.Windows.Forms.Label();
			this.tLocal = new System.Windows.Forms.TextBox();
			this.bBrowseLocal = new System.Windows.Forms.Button();
			this.lUser = new System.Windows.Forms.Label();
			this.lApi = new System.Windows.Forms.Label();
			this.tUser = new System.Windows.Forms.TextBox();
			this.bUser = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.lDetected = new System.Windows.Forms.Label();
			this.bAlbums = new System.Windows.Forms.Button();
			this.bAllPhoto = new System.Windows.Forms.Button();
			this.bTags = new System.Windows.Forms.Button();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.cbSave = new System.Windows.Forms.CheckBox();
			this.cbLocal = new System.Windows.Forms.CheckBox();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lLocal
			// 
			this.lLocal.AutoSize = true;
			this.lLocal.Location = new System.Drawing.Point(13, 13);
			this.lLocal.Name = "lLocal";
			this.lLocal.Size = new System.Drawing.Size(93, 13);
			this.lLocal.TabIndex = 0;
			this.lLocal.Text = "Локальная база:";
			// 
			// tLocal
			// 
			this.tLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tLocal.Location = new System.Drawing.Point(16, 30);
			this.tLocal.Name = "tLocal";
			this.tLocal.Size = new System.Drawing.Size(336, 20);
			this.tLocal.TabIndex = 1;
			// 
			// bBrowseLocal
			// 
			this.bBrowseLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bBrowseLocal.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bBrowseLocal.Location = new System.Drawing.Point(306, 13);
			this.bBrowseLocal.Name = "bBrowseLocal";
			this.bBrowseLocal.Size = new System.Drawing.Size(45, 13);
			this.bBrowseLocal.TabIndex = 2;
			this.bBrowseLocal.Text = "Обзор";
			this.bBrowseLocal.UseVisualStyleBackColor = true;
			this.bBrowseLocal.Click += new System.EventHandler(this.bBrowseLocal_Click);
			// 
			// lUser
			// 
			this.lUser.AutoSize = true;
			this.lUser.Location = new System.Drawing.Point(12, 61);
			this.lUser.Name = "lUser";
			this.lUser.Size = new System.Drawing.Size(173, 13);
			this.lUser.TabIndex = 3;
			this.lUser.Text = "Удалённая база (пользователь):";
			// 
			// lApi
			// 
			this.lApi.AutoSize = true;
			this.lApi.Location = new System.Drawing.Point(13, 74);
			this.lApi.Name = "lApi";
			this.lApi.Size = new System.Drawing.Size(183, 13);
			this.lApi.TabIndex = 4;
			this.lApi.Text = "https://api-fotki.yandex.ru/api/users/";
			// 
			// tUser
			// 
			this.tUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tUser.Location = new System.Drawing.Point(203, 66);
			this.tUser.Name = "tUser";
			this.tUser.Size = new System.Drawing.Size(148, 20);
			this.tUser.TabIndex = 3;
			this.tUser.Text = "atauenis";
			// 
			// bUser
			// 
			this.bUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bUser.Location = new System.Drawing.Point(276, 92);
			this.bUser.Name = "bUser";
			this.bUser.Size = new System.Drawing.Size(75, 23);
			this.bUser.TabIndex = 4;
			this.bUser.Text = "Загрузить";
			this.bUser.UseVisualStyleBackColor = true;
			this.bUser.Click += new System.EventHandler(this.bUser_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 175);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(364, 22);
			this.statusStrip1.TabIndex = 9;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lStatus
			// 
			this.lStatus.Name = "lStatus";
			this.lStatus.Size = new System.Drawing.Size(208, 17);
			this.lStatus.Text = "Не загружен пользователь или база.";
			// 
			// lDetected
			// 
			this.lDetected.AutoSize = true;
			this.lDetected.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lDetected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lDetected.Location = new System.Drawing.Point(16, 92);
			this.lDetected.Name = "lDetected";
			this.lDetected.Size = new System.Drawing.Size(23, 13);
			this.lDetected.TabIndex = 10;
			this.lDetected.Text = "    ";
			// 
			// bAlbums
			// 
			this.bAlbums.Enabled = false;
			this.bAlbums.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAlbums.Location = new System.Drawing.Point(16, 121);
			this.bAlbums.Name = "bAlbums";
			this.bAlbums.Size = new System.Drawing.Size(75, 23);
			this.bAlbums.TabIndex = 5;
			this.bAlbums.Text = "Альбомы";
			this.bAlbums.UseVisualStyleBackColor = true;
			this.bAlbums.Click += new System.EventHandler(this.bAlbums_Click);
			// 
			// bAllPhoto
			// 
			this.bAllPhoto.Enabled = false;
			this.bAllPhoto.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bAllPhoto.Location = new System.Drawing.Point(97, 121);
			this.bAllPhoto.Name = "bAllPhoto";
			this.bAllPhoto.Size = new System.Drawing.Size(75, 23);
			this.bAllPhoto.TabIndex = 6;
			this.bAllPhoto.Text = "Все фото";
			this.bAllPhoto.UseVisualStyleBackColor = true;
			this.bAllPhoto.Click += new System.EventHandler(this.bAllPhoto_Click);
			// 
			// bTags
			// 
			this.bTags.Enabled = false;
			this.bTags.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.bTags.Location = new System.Drawing.Point(178, 121);
			this.bTags.Name = "bTags";
			this.bTags.Size = new System.Drawing.Size(75, 23);
			this.bTags.TabIndex = 7;
			this.bTags.Text = "Теги";
			this.bTags.UseVisualStyleBackColor = true;
			this.bTags.Click += new System.EventHandler(this.bTags_Click);
			// 
			// fbd
			// 
			this.fbd.Description = "Выберите расположение локальной базы";
			// 
			// cbSave
			// 
			this.cbSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSave.AutoSize = true;
			this.cbSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbSave.Location = new System.Drawing.Point(276, 148);
			this.cbSave.Name = "cbSave";
			this.cbSave.Size = new System.Drawing.Size(85, 18);
			this.cbSave.TabIndex = 9;
			this.cbSave.Text = "Сохранять";
			this.cbSave.UseVisualStyleBackColor = true;
			this.cbSave.CheckedChanged += new System.EventHandler(this.cbSave_CheckedChanged);
			// 
			// cbLocal
			// 
			this.cbLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbLocal.AutoSize = true;
			this.cbLocal.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbLocal.Location = new System.Drawing.Point(276, 124);
			this.cbLocal.Name = "cbLocal";
			this.cbLocal.Size = new System.Drawing.Size(79, 18);
			this.cbLocal.TabIndex = 8;
			this.cbLocal.Text = "Из копии";
			this.cbLocal.UseVisualStyleBackColor = true;
			this.cbLocal.CheckedChanged += new System.EventHandler(this.cbLocal_CheckedChanged);
			// 
			// fMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 197);
			this.Controls.Add(this.cbLocal);
			this.Controls.Add(this.cbSave);
			this.Controls.Add(this.bTags);
			this.Controls.Add(this.bAllPhoto);
			this.Controls.Add(this.bAlbums);
			this.Controls.Add(this.lDetected);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.bUser);
			this.Controls.Add(this.tUser);
			this.Controls.Add(this.lApi);
			this.Controls.Add(this.lUser);
			this.Controls.Add(this.bBrowseLocal);
			this.Controls.Add(this.tLocal);
			this.Controls.Add(this.lLocal);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "fMain";
			this.Text = "Экспорт Яндекс.Фоток";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lLocal;
		private System.Windows.Forms.TextBox tLocal;
		private System.Windows.Forms.Button bBrowseLocal;
		private System.Windows.Forms.Label lUser;
		private System.Windows.Forms.Label lApi;
		private System.Windows.Forms.TextBox tUser;
		private System.Windows.Forms.Button bUser;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lStatus;
		private System.Windows.Forms.Label lDetected;
		private System.Windows.Forms.Button bAlbums;
		private System.Windows.Forms.Button bAllPhoto;
		private System.Windows.Forms.Button bTags;
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.CheckBox cbSave;
		private System.Windows.Forms.CheckBox cbLocal;
	}
}

