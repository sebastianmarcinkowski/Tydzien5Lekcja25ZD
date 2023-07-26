using Students.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tydzien5Lekcja25ZD
{
	public partial class Main : Form
	{
		private FileHelper<List<Student>> _fileHelper =
			new FileHelper<List<Student>>(Program.FilePath);

		public Main()
		{
			InitializeComponent();
			RefreshDiary();
			SetColumnHeader();
			FillGroupFilter(Program.Groups);

			if (IsMaximize)
				WindowState = FormWindowState.Maximized;

		}

		private void AddEditStudent_FormClosing(object sender, FormClosingEventArgs e)
		{
			RefreshDiary();
		}
		private void btnAdd_Click(object sender, EventArgs e)
		{
			var addEditStudent = new AddEditStudent();

			addEditStudent.FormClosing += AddEditStudent_FormClosing;

			addEditStudent.ShowDialog();

			addEditStudent.FormClosing -= AddEditStudent_FormClosing;
		}
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvDiary.SelectedRows.Count == 0)
			{
				MessageBox.Show("Proszę zaznacz ucznia, którego chcesz usunąć.");
				return;
			}

			var selectedStudent = dgvDiary.SelectedRows[0];

			var mboxStudent =
				(selectedStudent.Cells[1].Value.ToString() + " " +
				selectedStudent.Cells[2].Value.ToString()).Trim();

			var confirmDelete =
				MessageBox.Show($"Czy na pewno chcesz usunąć ucznia {mboxStudent}?",
				"Usuwanie ucznia",
				MessageBoxButtons.OKCancel);

			if (confirmDelete == DialogResult.OK)
			{
				DeleteStudent(Convert.ToInt32(selectedStudent.Cells[0].Value));
				RefreshDiary();
			}

		}
		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (dgvDiary.SelectedRows.Count == 0)
			{
				MessageBox.Show("Proszę zaznacz ucznia, którego dane chcesz edytować.");
				return;
			}

			var addEditStudent = new AddEditStudent(
				Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));

			addEditStudent.FormClosing += AddEditStudent_FormClosing;

			addEditStudent.ShowDialog();

			addEditStudent.FormClosing -= AddEditStudent_FormClosing;
		}
		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshDiary();
		}
		private void cbxGroupFilter_SelectedIndexChanged(object sender, EventArgs e)
		{
			FilterGroup();
		}
		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (WindowState == FormWindowState.Maximized)
				IsMaximize = true;
			else
				IsMaximize = false;

			Settings.Default.Save();
		}

		private void DeleteStudent(int id)
		{
			var students = _fileHelper.DeserializeFromFile();
			students.RemoveAll(x => x.Id == id);
			_fileHelper.SerializeToFile(students);
		}
		private void FillGroupFilter(List<string> groups)
		{
			cbxGroupFilter.Items.Clear();

			cbxGroupFilter.Items.Add("Wszyscy");

			if (groups.Count > 1)
			{
				foreach (var group in groups)
					cbxGroupFilter.Items.Add(group);
			}

			cbxGroupFilter.SelectedIndex = 0;
		}
		private void FilterGroup()
		{
			var students = _fileHelper.DeserializeFromFile();

			if (cbxGroupFilter.Text != "Wszyscy")
				students = students.Where(x => x.Group == cbxGroupFilter.Text).ToList();

			dgvDiary.DataSource = students;
		}
		private bool IsMaximize
		{
			get
			{
				return Settings.Default.isMaximize;
			}
			set
			{
				Settings.Default.isMaximize = value;
			}
		}
		private void RefreshDiary()
		{
			var students = _fileHelper.DeserializeFromFile();
			dgvDiary.DataSource = students;

			FilterGroup();
		}
		private void SetColumnHeader()
		{
			dgvDiary.Columns[0].HeaderText = "Numer";
			dgvDiary.Columns[1].HeaderText = "Imię";
			dgvDiary.Columns[2].HeaderText = "Nazwisko";
			dgvDiary.Columns[3].HeaderText = "Klasa";
			dgvDiary.Columns[4].HeaderText = "Uwagi";
			dgvDiary.Columns[5].HeaderText = "Matematyka";
			dgvDiary.Columns[6].HeaderText = "Technologia";
			dgvDiary.Columns[7].HeaderText = "Fizyka";
			dgvDiary.Columns[8].HeaderText = "Język polski";
			dgvDiary.Columns[9].HeaderText = "Język obcy";
			dgvDiary.Columns[10].HeaderText = "Zajęcia dodatkowe";
		}
	}
}
