using System.IO;

namespace Lab3
{
    /// <summary>Represents a skater athlete with a skating discipline and personal best score.</summary>
    internal class Skater : Sportsman
    {
        /// <summary>Skating discipline, e.g. "Ice", "Roller", "Speed".</summary>
        public string SkatingType { get; set; }
        public int BestScore { get; set; }

        /// <summary>Parameterless constructor required by PersonFactory for deserialization.</summary>
        internal Skater() : base()
        {
            SkatingType = "";
        }

        internal Skater(string name, int age, string sex, int medals, int years,
            string skatingType, int bestScore)
            : base(name, age, sex, medals, years)
        {
            SkatingType = skatingType;
            BestScore = bestScore;
        }

        public override string TypeName() => "Skater";

        public override string GetDetails() =>
            $"Type: {SkatingType}, Best score: {BestScore}, {base.GetDetails()}";

        /// <summary>Writes Skater fields: base Sportsman fields, then SkatingType and BestScore.</summary>
        public override void WriteBinary(BinaryWriter writer)
        {
            base.WriteBinary(writer);
            writer.Write(SkatingType ?? "");
            writer.Write(BestScore);
        }

        /// <summary>Reads Skater fields: base Sportsman fields, then SkatingType and BestScore.</summary>
        public override void ReadBinary(BinaryReader reader)
        {
            base.ReadBinary(reader);
            SkatingType = reader.ReadString();
            BestScore = reader.ReadInt32();
        }
    }
}
