using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab3
{
    internal class BinaryPersonSerializer
    {
        public void Serialize(List<Person> people, string path)
        {
            using (var stream = File.Open(path, FileMode.Create))
            using (var writer = new BinaryWriter(stream, Encoding.UTF8))
            {
                writer.Write(people.Count);
                foreach (Person person in people)
                {
                    writer.Write(person.TypeName());
                    person.WriteBinary(writer);
                }
            }
        }

        public List<Person> Deserialize(string path)
        {
            var result = new List<Person>();

            using (var stream = File.OpenRead(path))
            using (var reader = new BinaryReader(stream, Encoding.UTF8))
            {
                int count = reader.ReadInt32();
                for (int i = 0; i < count; i++)
                {
                    string typeName = reader.ReadString();
                    Person person   = PersonFactory.Create(typeName);
                    person.ReadBinary(reader);
                    result.Add(person);
                }
            }

            return result;
        }
    }
}
