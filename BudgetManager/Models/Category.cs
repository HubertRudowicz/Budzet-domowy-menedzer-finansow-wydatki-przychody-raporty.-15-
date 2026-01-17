using System;

namespace projekttest.Models
{
    public class Category
    {
        public string Name { get; set; }
        public bool IsSystem { get; set; } = false;

        public Category() { }
        public Category(string name, bool isSystem = false) 
        {
            Name = name;
            IsSystem = isSystem;
        }

        public override string ToString()
        {
            return Name;
        }
        
        public override bool Equals(object? obj)
        {
            if (obj is Category other)
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
