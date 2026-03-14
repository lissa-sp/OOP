using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Jumper : Sportsman
    {
        public int LongestJump { get; set; }
        public Jumper(string name, int age, string sex, int medals, int years, int jump) : base(name, age, sex, medals, years)
        {
            LongestJump = jump;
        }

        public override string TypeName() {
            return "Jumper";
        }
        public override string GetDetails() {
            return $"Longest jump: {LongestJump}";
        }
    }
}
