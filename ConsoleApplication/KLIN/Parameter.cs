namespace KLIN
{
    internal sealed class Parameter : IEquatable<Parameter>
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public static Parameter Parse(string line)
        {
            string[] inputArr = line.Split(' ');
            return new()
            {
                Name = inputArr[0],
                Value = inputArr[1]
            };
        }

        public static string[] ToStringArray(List<Parameter> parameters)
        {
            string[] output = new string[parameters.Count];

            for (int i = 0; i < parameters.Count; i++)
            {
                output[i] = parameters[i].Name + " " + parameters[i].Value;
            }
            return output;
        }
        public bool Equals(Parameter other)
        {
            if (other == null) return false;
            return (this.Name.Equals(other.Name));
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parameter);
        }
    }
}
