namespace MethodTest
{
    public class TestObject
    {
        public TestObject(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }

        public override bool Equals(object obj)
        {
            var o = obj as TestObject;
            return o != null && Equals(o);
        }

        protected bool Equals(TestObject other)
        {
            return string.Equals(Name, other.Name) && string.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}