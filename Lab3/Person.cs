using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        internal Person(string name, int age, string sex)
        {
            Name = name;
            Age = age;
            Sex = sex;
        } 

        public virtual string TypeName() {
            return "Person";
        }
        public virtual string GetDetails() {
            return "";
        }
    }
}
