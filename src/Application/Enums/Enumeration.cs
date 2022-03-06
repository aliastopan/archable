using System.Reflection;

#nullable disable

namespace Archable.Application.Enums
{
    public abstract class Enumeration
    {
        public int Value { get; init; }
        public string Name { get; init; }

        protected Enumeration(int value, string name)
        {
            this.Value = value;
            this.Name = name;
        }

        public override string ToString() => Name;

        public static IEnumerable<TEnumeration> GetAll<TEnumeration>() where TEnumeration : Enumeration
        {
            var bindings = BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly;

            return typeof(TEnumeration).GetFields(bindings)
                .Select(field => field.GetValue(null))
                .Cast<TEnumeration>();
        }

        public static TEnumeration CastFrom<TEnumeration>(int value) where TEnumeration : Enumeration
        {
            return GetAll<TEnumeration>().Single(property => property.Value == value);
        }

        public static TEnumeration CastFrom<TEnumeration>(string name) where TEnumeration : Enumeration
        {
            return GetAll<TEnumeration>().Single(property => string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }
}