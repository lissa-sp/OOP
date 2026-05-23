using System;
using System.Collections.Generic;

namespace Lab3
{
    internal static class PersonFactory
    {
        private static Dictionary<string, Func<Person>> dict = new Dictionary<string, Func<Person>>();

        public static void Register(string typeName, Func<Person> creator)
        {
            dict[typeName] = creator;
        }

        public static Person Create(string typeName)
        {
            if (dict.TryGetValue(typeName, out Func<Person> creator))
                return creator();

            throw new InvalidOperationException($"Unknown person type: '{typeName}'");
        }

        public static IEnumerable<string> RegisteredTypes => dict.Keys;
    }
}
