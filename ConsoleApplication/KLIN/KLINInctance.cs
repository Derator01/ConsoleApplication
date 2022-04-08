namespace KLIN
{
    internal sealed class KLINInstanse
    {
        private readonly string _klinFilePath;

        private List<Parameter> _config;

        internal KLINInstanse(string desiredName)
        {
            if (desiredName.Length < 2)
                return;
            _klinFilePath = @".\" + desiredName + ".klin";
            Init();
        }

        internal KLINInstanse()
        {
            _klinFilePath = @".\Config.klin";
            Init();
        }

        private void Init()
        {
            if (!File.Exists(_klinFilePath))
            {
                var file = File.Create(_klinFilePath);
                file.Close();
            }

            string[] contents = File.ReadAllLines(_klinFilePath);
            _config = new();

            if (contents.Length == 0)
                return;

            for (int i = 0; i < contents.Length; i++)
            {
                _config.Add(Parameter.Parse(contents[i]));
            }
            return;
        }

        internal void AddElement(string name, string value)
        {
            if (_config == null)
                return;
            if (_config.Contains(new Parameter { Name = name, Value = "" }))
                return;
            _config.Add(new Parameter { Name = name, Value = value });
            SaveChanges();
        }

        internal string GetValue(string name, string defaultValue)
        {
            if (_config == null)
                return null;
            if (!_config.Contains(new Parameter { Name = name, Value = "" }))
            {
                AddElement(name, defaultValue);
                SaveChanges();
                return defaultValue;
            }
            return _config.Find(x => x.Name == name).Value;
        }

        internal void ChangeValue(string name, string value)
        {
            if (_config == null)
                return;
            if (!_config.Contains(new Parameter { Name = name }))
            {
                AddElement(name, value);
                SaveChanges();
                return;
            }
            _config.Find(x => x.Name == name).Value = value;
            SaveChanges();
        }

        internal void SaveChanges()
        {
            if (!File.Exists(_klinFilePath))
                return;

            var file = File.Create(_klinFilePath);
            file.Close();

            File.WriteAllLines(_klinFilePath, Parameter.ToStringArray(_config));
        }
    }
}
