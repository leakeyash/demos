using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Attributes
{
    [AttributeUsage(AttributeTargets.Class,Inherited = true)]
    public class ConnectionNameAttribute:Attribute
    {
        public ConnectionNameAttribute(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentException("Empty connection name is not allowed",nameof(value));
            Name = value;
        }

        public virtual string Name { get; private set; }
    }
}
