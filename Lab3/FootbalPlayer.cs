using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    internal class FootbalPlayer : Sportsman
    {
        public string Position      { get; set; }
        public string Club          { get; set; }
        public int    AmountOfGoals { get; set; }

        internal FootbalPlayer() : base() { Position = ""; Club = ""; }

        internal FootbalPlayer(string name, int age, string sex, int medals, int years,
                               string position, string club, int amountOfGoals)
            : base(name, age, sex, medals, years)
        {
            Position      = position;
            Club          = club;
            AmountOfGoals = amountOfGoals;
        }

        public override string TypeName() => "FootbalPlayer";

        public override string GetDetails() =>
            $"Position: {Position}, Club: {Club}, Goals: {AmountOfGoals}, {base.GetDetails()}";

        public override IEnumerable<FieldDescriptor> GetFields()
        {
            foreach (var f in base.GetFields()) yield return f;
            yield return new StringField("Position", () => Position,      v => Position      = v);
            yield return new StringField("Club",     () => Club,          v => Club          = v);
            yield return new IntField   ("Goals",    () => AmountOfGoals, v => AmountOfGoals = v, 0, 9999);
        }

        public override void WriteBinary(BinaryWriter w)
        {
            base.WriteBinary(w);
            w.Write(Position      ?? "");
            w.Write(Club          ?? "");
            w.Write(AmountOfGoals);
        }

        public override void ReadBinary(BinaryReader r)
        {
            base.ReadBinary(r);
            Position      = r.ReadString();
            Club          = r.ReadString();
            AmountOfGoals = r.ReadInt32();
        }
    }
}
