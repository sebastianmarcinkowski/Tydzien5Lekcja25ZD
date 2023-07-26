using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tydzien5Lekcja25ZD
{
	public partial class AddEditStudent : Form
	{
		private FileHelper<List<Student>> _fileHelper =
			new FileHelper<List<Student>>(Program.FilePath);

		private int _studentId;
		private Student _student;

		public AddEditStudent(int id = 0)
		{
			InitializeComponent();
			_studentId = id;

			GetStudentData();
			tbFirstName.Select();
			FillStringListToComboBox(cbxGroup, Program.Groups);
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void btnConfirm_Click(object sender, EventArgs e)
		{
			var students = _fileHelper.DeserializeFromFile();

			if (_studentId != 0)
				students.RemoveAll(x => x.Id == _studentId);
			else
				AssignIdToNewStudent(students);

			AddNewUserToList(students);

			_fileHelper.SerializeToFile(students);

			Close();
		}

		private void AddNewUserToList(List<Student> students)
		{
			var student = new Student
			{
				Id = _studentId,
				FirstName = tbFirstName.Text,
				LastName = tbLastName.Text,
				Math = tbMath.Text,
				Technology = tbTechnology.Text,
				Physics = tbPhysics.Text,
				PolishLang = tbPolishLang.Text,
				ForeignLang = tbForeignLang.Text,
				Comments = rtbComments.Text,
				ExtraActivities = chbxExtraActivities.Checked,
				Group = cbxGroup.Text
			};

			students.Add(student);
		}
		private void AssignIdToNewStudent(List<Student> students)
		{
			var studentWithHighestId = students
				.OrderByDescending(x => x.Id)
				.FirstOrDefault();

			_studentId = studentWithHighestId == null ?
				1 : studentWithHighestId.Id + 1;
		}
		private void FillStringListToComboBox(ComboBox comboBox, List<string> items)
		{
			if (items.Count > 0)
			{
				comboBox.Items.Clear();

				foreach (var item in items)
					comboBox.Items.Add(item);
			}
		}
		private void FillTextBoxes()
		{
			tbId.Text = _student.Id.ToString();
			tbFirstName.Text = _student.FirstName;
			tbLastName.Text = _student.LastName;
			tbMath.Text = _student.Math;
			tbTechnology.Text = _student.Technology;
			tbPhysics.Text = _student.Physics;
			tbPolishLang.Text = _student.PolishLang;
			tbForeignLang.Text = _student.ForeignLang;
			chbxExtraActivities.Checked = _student.ExtraActivities;
			rtbComments.Text = _student.Comments;
			cbxGroup.Text = _student.Group;
		}
		private void GetStudentData()
		{
			if (_studentId != 0)
			{
				Text = "Edytowanie danych ucznia";

				var students = _fileHelper.DeserializeFromFile();
				_student = students.FirstOrDefault(x => x.Id == _studentId);

				if (_student == null)
					throw new Exception("Brak użytkownika o podanym Id.");

				FillTextBoxes();
			}
		}
	}
}
