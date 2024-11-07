using System.Reflection;

namespace Theatre.Domain.Common;

public abstract class Enumeration : IComparable
{
    public string Name { get; private set; }
    
    public int Id { get; private set; }

    protected Enumeration(int id, string name) => (Id, Name) = (id, name);

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();

    public static bool TryFromName<T>(string name, out T? enumeration) where T : Enumeration
    {
        var isElementExists = false;
        var all = GetAll<T>();
        var element = all.FirstOrDefault(e => e.Name == name);

        if (element is null)
        {
            enumeration = null;
            return isElementExists;
        }

        enumeration = element;
        isElementExists = true;
        return isElementExists;
    }

    public static T EnumFromName<T>(string name) where T : Enumeration
    {
        var enumerationInstance = TryFromName(name, out T? enumeration);
        ArgumentNullException.ThrowIfNull(enumeration);
        return enumeration;
    }

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType().Equals(obj.GetType());
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
}