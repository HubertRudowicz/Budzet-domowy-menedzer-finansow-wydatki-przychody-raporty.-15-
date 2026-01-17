using System;

namespace projekttest.Models
{
    public class Person
    {
        public string Name { get; set; }

        public Person() { }
        public Person(string name) 
        {
            Name = name;
        }

        // Override ToString to maintain compatibility with UI controls (ComboBoxes)
        // that display the object directly.
        public override string ToString()
        {
            return Name;
        }

        // Override Equality to allow easy comparison
        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name?.GetHashCode() ?? 0;
        }
    }
}
