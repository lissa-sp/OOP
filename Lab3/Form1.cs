using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private List<Person> people = new List<Person>();
        private readonly BinaryPersonSerializer serializer = new BinaryPersonSerializer();

        // Register all types, configure grid, load sample data
        public Form1()
        {
            InitializeComponent();
            PersonTypes.Initialize();
            SetupGrid();
            LoadSampleData();
            RefreshGrid();
        }

        // Configure columns of the DataGridView
        private void SetupGrid()
        {
            dgwObjects.AutoGenerateColumns = false;
            dgwObjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgwObjects.MultiSelect = false;
            dgwObjects.ReadOnly = true;
            dgwObjects.AllowUserToAddRows = false;
            dgwObjects.AllowUserToDeleteRows = false;

            dgwObjects.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "Type", HeaderText = "Type", Width = 130 });
            dgwObjects.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "Name", HeaderText = "Name", Width = 150 });
            dgwObjects.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "Age", HeaderText = "Age", Width = 50 });
            dgwObjects.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "Sex", HeaderText = "Sex", Width = 70 });

            var detailsCol = new DataGridViewTextBoxColumn
                { Name = "Details", HeaderText = "Details", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            dgwObjects.Columns.Add(detailsCol);
        }

        // Rebuild grid rows from the current people list
        private void RefreshGrid()
        {
            dgwObjects.Rows.Clear();
            foreach (Person p in people)
                dgwObjects.Rows.Add(p.TypeName(), p.Name, p.Age, p.Sex, p.GetDetails());
        }

        // Fill the list with initial demo objects
        private void LoadSampleData()
        {
            people.Add(new FootbalPlayer("John Doe",  20, "Male",   10, 5, "Forward",   "Manchester United", 10));
            people.Add(new Boxer        ("Jane Doe",  25, "Female",  5, 3, 80));
            people.Add(new Jumper       ("Jim Doe",   30, "Male",    7, 4, 780));
            people.Add(new Skater       ("Jill Doe",  35, "Female",  8, 6, "Ice",        230));
            people.Add(new Swimmer      ("Jack Doe",  40, "Male",    9, 7, "Freestyle", "1:02:34"));
            people.Add(new Sportsman    ("Mike Smith", 28, "Male",   3, 6));
        }

        // Open Add dialog, append the new object if confirmed
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new PersonEditForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK && form.ResultPerson != null)
                {
                    people.Add(form.ResultPerson);
                    RefreshGrid();
                }
            }
        }

        // Edit a clone of the selected object, replace original only on OK
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();
            if (index < 0) return;

            Person clone = ClonePerson(people[index]);

            using (var form = new PersonEditForm(clone))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    people[index] = clone;
                    RefreshGrid();
                }
            }
        }

        // Remove the selected object after confirmation
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = GetSelectedIndex();
            if (index < 0) return;

            var answer = MessageBox.Show(
                $"Delete '{people[index].Name}' ({people[index].TypeName()})?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                people.RemoveAt(index);
                RefreshGrid();
            }
        }

        // Serialize the list to a binary file chosen by the user
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter     = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                dlg.DefaultExt = "bin";
                dlg.Title      = "Save persons list";

                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    serializer.Serialize(people, dlg.FileName);
                    MessageBox.Show("Saved successfully.", "Save",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file:\n{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Deserialize the list from a binary file chosen by the user
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                dlg.Title  = "Load persons list";

                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    people = serializer.Deserialize(dlg.FileName);
                    RefreshGrid();
                    MessageBox.Show("Loaded successfully.", "Load",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file:\n{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Return index of the selected row, or -1 if nothing is selected
        private int GetSelectedIndex()
        {
            if (dgwObjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.", "No selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return dgwObjects.SelectedRows[0].Index;
        }

        // Create a deep copy of a person via binary round-trip through a MemoryStream
        private Person ClonePerson(Person person)
        {
            using (var ms = new MemoryStream())
            {
                using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
                    person.WriteBinary(writer);

                ms.Position = 0;

                using (var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true))
                {
                    Person clone = PersonFactory.Create(person.TypeName());
                    clone.ReadBinary(reader);
                    return clone;
                }
            }
        }
    }
}
