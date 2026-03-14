using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class FootbalPlayer : Sportsman
    {
        public string Position { get; set; }
        public string Club {  get; set; }
        public int AmountOfGoals { get; set; }

        internal FootbalPlayer(string name, int age, string sex, int medals, int years, string position, string club, int amountOfGoals) : base(name, age, sex, medals, years)
        {
            Position = position;
            Club = club;
            AmountOfGoals = amountOfGoals;
        }

        public override string TypeName() {
            return "FootbalPlayer";
        }
        public override string GetDetails() {
            return $"Position: {Position}, Club: {Club}, Amount of goals: {AmountOfGoals}";
        }
    }
}
