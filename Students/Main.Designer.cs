namespace Tydzien5Lekcja25ZD
{
	partial class Main
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
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.dgvDiary = new System.Windows.Forms.DataGridView();
			this.cbxGroupFilter = new System.Windows.Forms.ComboBox();
			this.lbGroupFilter = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
			this.btnAdd.Location = new System.Drawing.Point(12, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Dodaj";
			this.btnAdd.UseVisualStyleBackColor = false;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.Color.Goldenrod;
			this.btnEdit.Location = new System.Drawing.Point(93, 12);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(75, 23);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Edytuj";
			this.btnEdit.UseVisualStyleBackColor = false;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
			this.btnDelete.Location = new System.Drawing.Point(174, 12);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Usuń";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.BackColor = System.Drawing.Color.CornflowerBlue;
			this.btnRefresh.Location = new System.Drawing.Point(819, 13);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(75, 23);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Odśwież";
			this.btnRefresh.UseVisualStyleBackColor = false;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// dgvDiary
			// 
			this.dgvDiary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvDiary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvDiary.BackgroundColor = System.Drawing.Color.White;
			this.dgvDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDiary.Location = new System.Drawing.Point(13, 42);
			this.dgvDiary.Name = "dgvDiary";
			this.dgvDiary.RowHeadersVisible = false;
			this.dgvDiary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvDiary.Size = new System.Drawing.Size(881, 396);
			this.dgvDiary.TabIndex = 4;
			// 
			// cbxGroupFilter
			// 
			this.cbxGroupFilter.FormattingEnabled = true;
			this.cbxGroupFilter.Location = new System.Drawing.Point(310, 12);
			this.cbxGroupFilter.Name = "cbxGroupFilter";
			this.cbxGroupFilter.Size = new System.Drawing.Size(121, 21);
			this.cbxGroupFilter.TabIndex = 5;
			this.cbxGroupFilter.SelectedIndexChanged += new System.EventHandler(this.cbxGroupFilter_SelectedIndexChanged);
			// 
			// lbGroupFilter
			// 
			this.lbGroupFilter.AutoSize = true;
			this.lbGroupFilter.Location = new System.Drawing.Point(255, 17);
			this.lbGroupFilter.Name = "lbGroupFilter";
			this.lbGroupFilter.Size = new System.Drawing.Size(49, 13);
			this.lbGroupFilter.TabIndex = 6;
			this.lbGroupFilter.Text = "Wyświetl";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(906, 450);
			this.Controls.Add(this.lbGroupFilter);
			this.Controls.Add(this.cbxGroupFilter);
			this.Controls.Add(this.dgvDiary);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dziennik ucznia";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.dgvDiary)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.DataGridView dgvDiary;
		private System.Windows.Forms.ComboBox cbxGroupFilter;
		private System.Windows.Forms.Label lbGroupFilter;
	}
}

