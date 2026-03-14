using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Boxer : Sportsman
    {
        public int WeightCategory { get; set; }

        internal Boxer (string name, int age, string sex, int medals, int years, int weightCategory) : base(name, age, sex, medals, years)
        {
            WeightCategory = weightCategory;
        }

        public override string TypeName() {
            return "Boxer";
        }
        public override string GetDetails() {
            return $"Weight category: {WeightCategory}";
        }
    }
}
