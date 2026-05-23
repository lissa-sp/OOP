using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    internal class Jumper : Sportsman
    {
        public int LongestJump { get; set; }

        internal Jumper() : base() { }

        internal Jumper(string name, int age, string sex, int medals, int years, int jump)
            : base(name, age, sex, medals, years)
        {
            LongestJump = jump;
        }

        public override string TypeName() => "Jumper";

        public override string GetDetails() =>
            $"Longest jump: {LongestJump} cm, {base.GetDetails()}";

        public override IEnumerable<FieldDescriptor> GetFields()
        {
            foreach (var f in base.GetFields()) yield return f;
            yield return new IntField("Longest jump (cm)", () => LongestJump, v => LongestJump = v, 0, 99_999);
        }

        public override void WriteBinary(BinaryWriter w)
        {
            base.WriteBinary(w);
            w.Write(LongestJump);
        }

        public override void ReadBinary(BinaryReader r)
        {
            base.ReadBinary(r);
            LongestJump = r.ReadInt32();
        }
    }
}
