using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MerchandiseService.Domain.Root
{
    public abstract class Enumeration<T> : IComparable where T : Enumeration<T>
    {
        public string Name { get; }

        public int Id { get; }

        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => Name;

        public static IEnumerable<T> GetAll() =>
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>();

        public static T Parse(string name) =>
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>().Single(x => x.Name == name);
        
        public static T Parse(int id) =>
            typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Select(f => f.GetValue(null))
                .Cast<T>().Single(x => x.Id == id);

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration<T> otherValue)
            {
                return false;
            }

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        protected bool Equals(Enumeration<T> other)
        {
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Enumeration<T> left, Enumeration<T> right)
        {
            if (left is null && right is null) return true;
            return left is not null && left.Equals(right);
        }

        public static bool operator !=(Enumeration<T> left, Enumeration<T> right)
        {
            return !(left == right);
        }

        public int CompareTo(object other) => Id.CompareTo(((Enumeration<T>)other).Id);
    }
}
