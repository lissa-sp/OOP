using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    internal class Boxer : Sportsman
    {
        public int WeightCategory { get; set; }

        internal Boxer() : base() { }

        internal Boxer(string name, int age, string sex, int medals, int years, int weightCategory)
            : base(name, age, sex, medals, years)
        {
            WeightCategory = weightCategory;
        }

        public override string TypeName() => "Boxer";

        public override string GetDetails() =>
            $"Weight category: {WeightCategory} kg, {base.GetDetails()}";

        public override IEnumerable<FieldDescriptor> GetFields()
        {
            foreach (var f in base.GetFields()) yield return f;
            yield return new IntField("Weight category (kg)", () => WeightCategory, v => WeightCategory = v, 40, 200);
        }

        public override void WriteBinary(BinaryWriter w)
        {
            base.WriteBinary(w);
            w.Write(WeightCategory);
        }

        public override void ReadBinary(BinaryReader r)
        {
            base.ReadBinary(r);
            WeightCategory = r.ReadInt32();
        }
    }
}
