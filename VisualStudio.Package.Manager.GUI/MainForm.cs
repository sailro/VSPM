﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace VisualStudio.Package.Manager.GUI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			var list = VisualStudioRegistry.GetConfigurations().ToList();
			ConfigurationSource.DataSource = list.Any() ? list.OrderByDescending(c => c.Name) : null;
		}

		private void ConfigurationSource_CurrentItemChanged(object sender, EventArgs e)
		{
			var configuration = ConfigurationSource.Current as VisualStudioConfiguration;
			if (configuration == null)
				return;

			configuration.RefreshState();
			PackageFilter_TextChanged(sender, e);
		}

		private void UpdateConfiguration_Click(object sender, EventArgs e)
		{
			UpdateConfiguration.Enabled = false;
			var configuration = ConfigurationSource.Current as VisualStudioConfiguration;
			configuration?.Update();
			UpdateConfiguration.Enabled = true;
		}

		private void PackageFilter_TextChanged(object sender, EventArgs e)
		{
			var configuration = ConfigurationSource.Current as VisualStudioConfiguration;
			if (configuration == null)
				return;

			var list = configuration.Packages
				.Where(p => p.Name != "?" && p.Name.ToLower().Contains(PackageFilter.Text.ToLower()))
				.ToList();

			var sortableList = new SortableBindingList<VisualStudioPackage>(list);
			PackageBindingSource.DataSource = sortableList;
		}
	}
}