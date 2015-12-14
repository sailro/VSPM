namespace VisualStudio.Package.Manager.GUI
{
    partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.ConfigurationSource = new System.Windows.Forms.BindingSource(this.components);
			this.Configurations = new System.Windows.Forms.ComboBox();
			this.Packages = new System.Windows.Forms.DataGridView();
			this.PackageBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.UpdateConfiguration = new System.Windows.Forms.Button();
			this.ConfigurationLabel = new System.Windows.Forms.Label();
			this.PackagesLabel = new System.Windows.Forms.Label();
			this.PackageFilter = new System.Windows.Forms.TextBox();
			this.EnabledColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SourceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.ConfigurationSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Packages)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PackageBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// ConfigurationSource
			// 
			this.ConfigurationSource.DataSource = typeof(VisualStudio.Package.Manager.VisualStudioConfiguration);
			this.ConfigurationSource.CurrentItemChanged += new System.EventHandler(this.ConfigurationSource_CurrentItemChanged);
			// 
			// Configurations
			// 
			this.Configurations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Configurations.DataSource = this.ConfigurationSource;
			this.Configurations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Configurations.FormattingEnabled = true;
			this.Configurations.Location = new System.Drawing.Point(243, 6);
			this.Configurations.Name = "Configurations";
			this.Configurations.Size = new System.Drawing.Size(740, 24);
			this.Configurations.TabIndex = 0;
			// 
			// Packages
			// 
			this.Packages.AllowUserToAddRows = false;
			this.Packages.AllowUserToDeleteRows = false;
			this.Packages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Packages.AutoGenerateColumns = false;
			this.Packages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Packages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnabledColumn,
            this.NameColumn,
            this.SourceColumn});
			this.Packages.DataSource = this.PackageBindingSource;
			this.Packages.Location = new System.Drawing.Point(21, 71);
			this.Packages.MultiSelect = false;
			this.Packages.Name = "Packages";
			this.Packages.RowTemplate.Height = 24;
			this.Packages.Size = new System.Drawing.Size(962, 590);
			this.Packages.TabIndex = 1;
			// 
			// PackageBindingSource
			// 
			this.PackageBindingSource.DataSource = typeof(VisualStudio.Package.Manager.VisualStudioPackage);
			this.PackageBindingSource.Sort = "Name";
			// 
			// UpdateConfiguration
			// 
			this.UpdateConfiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.UpdateConfiguration.Location = new System.Drawing.Point(21, 681);
			this.UpdateConfiguration.Name = "UpdateConfiguration";
			this.UpdateConfiguration.Size = new System.Drawing.Size(170, 28);
			this.UpdateConfiguration.TabIndex = 2;
			this.UpdateConfiguration.Text = "Update configuration";
			this.UpdateConfiguration.UseVisualStyleBackColor = true;
			this.UpdateConfiguration.Click += new System.EventHandler(this.UpdateConfiguration_Click);
			// 
			// ConfigurationLabel
			// 
			this.ConfigurationLabel.AutoSize = true;
			this.ConfigurationLabel.Location = new System.Drawing.Point(18, 9);
			this.ConfigurationLabel.Name = "ConfigurationLabel";
			this.ConfigurationLabel.Size = new System.Drawing.Size(219, 17);
			this.ConfigurationLabel.TabIndex = 3;
			this.ConfigurationLabel.Text = "Select VisualStudio configuration:";
			// 
			// PackagesLabel
			// 
			this.PackagesLabel.AutoSize = true;
			this.PackagesLabel.Location = new System.Drawing.Point(21, 40);
			this.PackagesLabel.Name = "PackagesLabel";
			this.PackagesLabel.Size = new System.Drawing.Size(144, 17);
			this.PackagesLabel.TabIndex = 4;
			this.PackagesLabel.Text = "Packages name filter:";
			// 
			// PackageFilter
			// 
			this.PackageFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.PackageFilter.Location = new System.Drawing.Point(243, 37);
			this.PackageFilter.Name = "PackageFilter";
			this.PackageFilter.Size = new System.Drawing.Size(740, 22);
			this.PackageFilter.TabIndex = 5;
			this.PackageFilter.TextChanged += new System.EventHandler(this.PackageFilter_TextChanged);
			// 
			// EnabledColumn
			// 
			this.EnabledColumn.DataPropertyName = "Enabled";
			this.EnabledColumn.HeaderText = "Enabled";
			this.EnabledColumn.Name = "EnabledColumn";
			this.EnabledColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// NameColumn
			// 
			this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.NameColumn.DataPropertyName = "Name";
			this.NameColumn.HeaderText = "Name";
			this.NameColumn.Name = "NameColumn";
			this.NameColumn.ReadOnly = true;
			// 
			// SourceColumn
			// 
			this.SourceColumn.DataPropertyName = "Source";
			this.SourceColumn.HeaderText = "Source";
			this.SourceColumn.Name = "SourceColumn";
			this.SourceColumn.ReadOnly = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 721);
			this.Controls.Add(this.PackageFilter);
			this.Controls.Add(this.PackagesLabel);
			this.Controls.Add(this.ConfigurationLabel);
			this.Controls.Add(this.UpdateConfiguration);
			this.Controls.Add(this.Packages);
			this.Controls.Add(this.Configurations);
			this.MinimumSize = new System.Drawing.Size(640, 200);
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "VisualStudio Package Manager";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.ConfigurationSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Packages)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PackageBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource ConfigurationSource;
        private System.Windows.Forms.ComboBox Configurations;
        private System.Windows.Forms.DataGridView Packages;
        private System.Windows.Forms.BindingSource PackageBindingSource;
        private System.Windows.Forms.Button UpdateConfiguration;
        private System.Windows.Forms.Label ConfigurationLabel;
        private System.Windows.Forms.Label PackagesLabel;
        private System.Windows.Forms.TextBox PackageFilter;
		private System.Windows.Forms.DataGridViewTextBoxColumn SourceColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn EnabledColumn;
	}
}

