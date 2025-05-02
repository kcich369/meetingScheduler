using System.Reflection;

namespace MeetingScheduler.Shared.Domain.Enumerations;

public abstract class Enumeration(int id, string name) : IComparable
{
    public string Name { get; } = name;
    public int Id { get; } = id;

    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        return typeof(T)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<T>();
    }

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration otherValue)
            return false;

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static T FromId<T>(int id) where T : Enumeration
    {
        return GetAll<T>().FirstOrDefault(x => x.Id == id) 
               ?? throw new InvalidOperationException($"Id {id} not found in {typeof(T)}");
    }

    public static T FromName<T>(string name) where T : Enumeration
    {
        return GetAll<T>().FirstOrDefault(x => x.Name == name) 
               ?? throw new InvalidOperationException($"Name {name} not found in {typeof(T)}");
    }

    public int CompareTo(object other) => Id.CompareTo(((Enumeration)other).Id);
}
