﻿using Students.Properties;
using System;
using System.Collections.Generic;
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

			if (IsMaximize)
				WindowState = FormWindowState.Maximized;
		}

		public bool IsMaximize
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

		private void SetColumnHeader()
		{
			dgvDiary.Columns[0].HeaderText = "Numer";
			dgvDiary.Columns[1].HeaderText = "Imię";
			dgvDiary.Columns[2].HeaderText = "Nazwisko";
			dgvDiary.Columns[3].HeaderText = "Uwagi";
			dgvDiary.Columns[4].HeaderText = "Matematyka";
			dgvDiary.Columns[5].HeaderText = "Technologia";
			dgvDiary.Columns[6].HeaderText = "Fizyka";
			dgvDiary.Columns[7].HeaderText = "Język polski";
			dgvDiary.Columns[8].HeaderText = "Język obcy";
		}

		private void RefreshDiary()
		{
			var students = _fileHelper.DeserializeFromFile();
			dgvDiary.DataSource = students;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var addEditStudent = new AddEditStudent();

			addEditStudent.ShowDialog();
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
			addEditStudent.ShowDialog();
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

		private void DeleteStudent(int id)
		{
			var students = _fileHelper.DeserializeFromFile();
			students.RemoveAll(x => x.Id == id);
			_fileHelper.SerializeToFile(students);
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshDiary();
		}

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (WindowState == FormWindowState.Maximized)
				IsMaximize = true;
			else
				IsMaximize = false;

			Settings.Default.Save();
		}
	}
}
