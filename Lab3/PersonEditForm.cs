using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    internal class PersonEditForm : Form
    {
        public Person ResultPerson { get; private set; }

        private Person                _person;
        private List<FieldDescriptor> _fields;
        private readonly bool         _editMode;

        private ComboBox _cmbType;
        private Panel    _fieldsPanel;

        private const int FormWidth = 450;
        private const int TypeRowH  = 32;
        private const int FieldRowH = 30;
        private const int FieldGap  = 5;
        private const int BtnRowH   = 42;
        private const int LabelW    = 160;
        private const int MarginX   = 12;
        private const int MarginTop = 12;

        public PersonEditForm() : this(null) { }

        public PersonEditForm(Person existing)
        {
            _editMode = existing != null;
            _person   = existing;
            BuildShell();
        }

        private void BuildShell()
        {
            Text            = _editMode ? "Edit Person" : "Add Person";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            StartPosition   = FormStartPosition.CenterParent;
            Width           = FormWidth;

            int y = MarginTop;

            Controls.Add(new Label
            {
                Text      = "Type:",
                Left      = MarginX,
                Top       = y + 5,
                Width     = LabelW,
                TextAlign = ContentAlignment.MiddleLeft
            });

            _cmbType = new ComboBox
            {
                Left          = MarginX + LabelW,
                Top           = y,
                Width         = FormWidth - MarginX * 2 - LabelW - 20,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Enabled       = !_editMode
            };
            foreach (string typeName in PersonFactory.RegisteredTypes)
                _cmbType.Items.Add(typeName);

            _cmbType.SelectedIndexChanged += OnTypeChanged;
            Controls.Add(_cmbType);
            y += TypeRowH + 4;

            _fieldsPanel = new Panel { Left = 0, Top = y, Width = FormWidth };
            Controls.Add(_fieldsPanel);

            var btnOk     = new Button { Text = "OK",     Width = 90, Height = 28 };
            var btnCancel = new Button { Text = "Cancel",  Width = 90, Height = 28,
                                         DialogResult = DialogResult.Cancel };
            btnOk.Click += BtnOk_Click;
            Controls.Add(btnOk);
            Controls.Add(btnCancel);
            AcceptButton = btnOk;
            CancelButton = btnCancel;

            if (_editMode)
            {
                _cmbType.SelectedIndexChanged -= OnTypeChanged;
                _cmbType.SelectedItem          = _person.TypeName();
                _cmbType.SelectedIndexChanged += OnTypeChanged;
                RebuildFields();
            }
            else
            {
                _cmbType.SelectedIndex = 0;
            }

            PositionButtons(btnOk, btnCancel);
        }

        private void OnTypeChanged(object sender, EventArgs e)
        {
            if (!_editMode)
                _person = PersonFactory.Create(_cmbType.Text);

            RebuildFields();
            PositionButtons(
                Controls["btnOk"]     as Button,
                Controls["btnCancel"] as Button);
        }

        private void RebuildFields()
        {
            _fieldsPanel.Controls.Clear();
            _fields = new List<FieldDescriptor>(_person.GetFields());

            int y = 6;
            foreach (FieldDescriptor field in _fields)
            {
                var label = new Label
                {
                    Text      = field.Label + ":",
                    Left      = MarginX,
                    Top       = y + 4,
                    Width     = LabelW,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Control ctrl = field.CreateControl();
                ctrl.Left  = MarginX + LabelW;
                ctrl.Top   = y;
                ctrl.Width = _fieldsPanel.Width - MarginX * 2 - LabelW - 20;

                _fieldsPanel.Controls.Add(label);
                _fieldsPanel.Controls.Add(ctrl);

                y += FieldRowH + FieldGap;
            }

            _fieldsPanel.Height = y + 4;

            ClientSize = new Size(ClientSize.Width,
                MarginTop + TypeRowH + 4 + _fieldsPanel.Height + BtnRowH);
        }

        private void PositionButtons(Button btnOk, Button btnCancel)
        {
            if (btnOk == null || btnCancel == null) return;

            int btnY = ClientSize.Height - BtnRowH + 7;
            btnOk.Name     = "btnOk";
            btnCancel.Name = "btnCancel";
            btnOk.Left     = ClientSize.Width - 210;
            btnCancel.Left = ClientSize.Width - 110;
            btnOk.Top      = btnY;
            btnCancel.Top  = btnY;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            foreach (FieldDescriptor field in _fields)
            {
                string error = field.Validate();
                if (error != null)
                {
                    MessageBox.Show(error, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            foreach (FieldDescriptor field in _fields)
                field.Apply();

            ResultPerson = _person;
            DialogResult = DialogResult.OK;
        }
    }
}
