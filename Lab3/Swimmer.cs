using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Swimmer : Sportsman
    {
        public string Style { get; set; }
        public string BestTime { get; set; }

        internal Swimmer(string name, int age, string sex, int medals, int years, string style, string bestTime) : base(name, age, sex, medals, years)
        {
            Style = style;
            BestTime = bestTime;
        }

        public override string TypeName() {
            return "Swimmer";
        }
        public override string GetDetails() {
            return $"Style: {Style}, Best time: {BestTime}";
        }
    }
}
