using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    internal class Sportsman : Person
    {
        public int AmountOfMedals { get; set; }
        public int YearsInSport   { get; set; }

        internal Sportsman() : base() { }

        internal Sportsman(string name, int age, string sex, int medals, int years)
            : base(name, age, sex)
        {
            AmountOfMedals = medals;
            YearsInSport   = years;
        }

        public override string TypeName() => "Sportsman";

        public override string GetDetails() =>
            $"Medals: {AmountOfMedals}, Years in sport: {YearsInSport}";

        public override IEnumerable<FieldDescriptor> GetFields()
        {
            foreach (var f in base.GetFields()) yield return f;
            yield return new IntField("Medals",         () => AmountOfMedals, v => AmountOfMedals = v, 0, 9999);
            yield return new IntField("Years in sport", () => YearsInSport,   v => YearsInSport   = v, 0, 100);
        }

        public override void WriteBinary(BinaryWriter w)
        {
            base.WriteBinary(w);
            w.Write(AmountOfMedals);
            w.Write(YearsInSport);
        }

        public override void ReadBinary(BinaryReader r)
        {
            base.ReadBinary(r);
            AmountOfMedals = r.ReadInt32();
            YearsInSport   = r.ReadInt32();
        }
    }
}
