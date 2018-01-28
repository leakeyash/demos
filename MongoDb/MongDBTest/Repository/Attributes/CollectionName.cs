using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Attributes
{
    [AttributeUsage(AttributeTargets.Class,Inherited = true)]
    public class CollectionNameAttribute:Attribute
    {
        public virtual string Name { get; private set; }
        public CollectionNameAttribute(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Empty colletion name is not allowed",nameof(value));
            Name = value;
        }
    }
}
