using System.Collections.Generic;
using System.IO;

namespace Lab3
{
    internal abstract class Person
    {
        public string Name { get; set; }
        public int    Age  { get; set; }
        public string Sex  { get; set; }

        protected Person() { 
            Name = ""; 
            Sex = "Male"; 
        }

        internal Person(string name, int age, string sex)
        {
            Name = name; 
            Age = age; 
            Sex = sex;
        }

        public abstract string TypeName();
        public virtual string GetDetails() => "";

        public virtual IEnumerable<FieldDescriptor> GetFields()
        {
            yield return new StringField("Name", () => Name, v => Name = v, required: true);
            yield return new IntField   ("Age",  () => Age,  v => Age  = v, min: 1, max: 120);
            yield return new ChoiceField("Sex",  () => Sex,  v => Sex  = v, "Male", "Female");
        }

        public virtual void WriteBinary(BinaryWriter w)
        {
            w.Write(Name ?? "");
            w.Write(Age);
            w.Write(Sex ?? "");
        }

        public virtual void ReadBinary(BinaryReader r)
        {
            Name = r.ReadString();
            Age  = r.ReadInt32();
            Sex  = r.ReadString();
        }
    }
}
