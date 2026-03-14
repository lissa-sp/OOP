using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Sportsman : Person
    {
        public int AmountOfMedals { get; set; }
        public int YearsInSport {  get; set; }

        internal Sportsman(string name, int age, string sex, int medals, int years) : base(name, age, sex)
        {
            AmountOfMedals = medals;
            YearsInSport = years;
        }

        public override string TypeName() {
            return "Sportsman";
        }
        public override string GetDetails() {
            return $"Amount of medals: {AmountOfMedals}, Years in sport: {YearsInSport}";
        }

    }
}
