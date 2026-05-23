using System;
using System.Windows.Forms;

namespace Lab3
{
    internal abstract class FieldDescriptor
    {
        public string Label { get; }

        protected FieldDescriptor(string label) { Label = label; }

        public abstract Control CreateControl();
        public abstract void Apply();
        public virtual string Validate() => null;
    }

    internal sealed class StringField : FieldDescriptor
    {
        private readonly Func<string>   _get;
        private readonly Action<string> _set;
        private readonly bool           _required;
        private TextBox _ctrl;

        public StringField(string label, Func<string> get, Action<string> set, bool required = false)
            : base(label)
        {
            _get = get; _set = set; _required = required;
        }

        public override Control CreateControl()
        {
            _ctrl = new TextBox { Text = _get() ?? "" };
            return _ctrl;
        }

        public override void Apply() => _set(_ctrl.Text.Trim());

        public override string Validate() =>
            _required && string.IsNullOrWhiteSpace(_ctrl.Text) ? $"'{Label}' is required." : null;
    }

    internal sealed class IntField : FieldDescriptor
    {
        private readonly Func<int>   _get;
        private readonly Action<int> _set;
        private readonly int         _min, _max;
        private NumericUpDown _ctrl;

        public IntField(string label, Func<int> get, Action<int> set, int min = 0, int max = 99_999)
            : base(label)
        {
            _get = get; _set = set; _min = min; _max = max;
        }

        public override Control CreateControl()
        {
            int clamped = Math.Max(_min, Math.Min(_max, _get()));
            _ctrl = new NumericUpDown { Minimum = _min, Maximum = _max, Value = clamped };
            return _ctrl;
        }

        public override void Apply() => _set((int)_ctrl.Value);
    }

    internal sealed class ChoiceField : FieldDescriptor
    {
        private readonly Func<string>   _get;
        private readonly Action<string> _set;
        private readonly string[]       _choices;
        private ComboBox _ctrl;

        public ChoiceField(string label, Func<string> get, Action<string> set, params string[] choices)
            : base(label)
        {
            _get = get; _set = set; _choices = choices;
        }

        public override Control CreateControl()
        {
            _ctrl = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
            _ctrl.Items.AddRange(_choices);
            _ctrl.SelectedItem = _get();
            if (_ctrl.SelectedIndex < 0 && _choices.Length > 0)
                _ctrl.SelectedIndex = 0;
            return _ctrl;
        }

        public override void Apply() => _set(_ctrl.Text);
    }
}
