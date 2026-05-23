using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    internal class Skater : Sportsman
    {
        public string SkatingType { get; set; }
        public int    BestScore   { get; set; }

        internal Skater() : base() { 
            SkatingType = ""; 
        }

        internal Skater(string name, int age, string sex, int medals, int years,
                        string skatingType, int bestScore)
            : base(name, age, sex, medals, years)
        {
            SkatingType = skatingType;
            BestScore   = bestScore;
        }

        public override string TypeName() => "Skater";

        public override string GetDetails() =>
            $"Type: {SkatingType}, Best score: {BestScore}, {base.GetDetails()}";

        public override IEnumerable<FieldDescriptor> GetFields()
        {
            foreach (var f in base.GetFields()) yield return f;
            yield return new StringField("Skating type", () => SkatingType, v => SkatingType = v);
            yield return new IntField   ("Best score",   () => BestScore,   v => BestScore   = v, 0, 99_999);
        }

        public override void WriteBinary(BinaryWriter w)
        {
            base.WriteBinary(w);
            w.Write(SkatingType ?? "");
            w.Write(BestScore);
        }

        public override void ReadBinary(BinaryReader r)
        {
            base.ReadBinary(r);
            SkatingType = r.ReadString();
            BestScore   = r.ReadInt32();
        }
    }
}
