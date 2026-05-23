using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    internal class Swimmer : Sportsman
    {
        public string Style    { get; set; }
        public string BestTime { get; set; }

        internal Swimmer() : base() { Style = ""; BestTime = ""; }

        internal Swimmer(string name, int age, string sex, int medals, int years,
                         string style, string bestTime)
            : base(name, age, sex, medals, years)
        {
            Style    = style;
            BestTime = bestTime;
        }

        public override string TypeName() => "Swimmer";

        public override string GetDetails() =>
            $"Style: {Style}, Best time: {BestTime}, {base.GetDetails()}";

        public override IEnumerable<FieldDescriptor> GetFields()
        {
            foreach (var f in base.GetFields()) yield return f;
            yield return new StringField("Style",     () => Style,    v => Style    = v);
            yield return new StringField("Best time", () => BestTime, v => BestTime = v);
        }

        public override void WriteBinary(BinaryWriter w)
        {
            base.WriteBinary(w);
            w.Write(Style    ?? "");
            w.Write(BestTime ?? "");
        }

        public override void ReadBinary(BinaryReader r)
        {
            base.ReadBinary(r);
            Style    = r.ReadString();
            BestTime = r.ReadString();
        }
    }
}
