using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using ProjectCaseStudy.Data;
using System.Text.Json.Serialization;

namespace ProjectCaseStudy
{

    public abstract class JsonIO<T>
    {
        protected abstract Generator<T> _generator { get; }
        public List<T>? LoadFile(string filePath)
        {
            try
            {
                var data = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<T>>(data);
            }
            catch
            {
                return SerializeToFile(filePath,1000);
            }
        }

        public List<T> SerializeToFile(string filePath, int number)
        {
            if (!File.Exists(filePath)) File.Create(filePath);

            var data = _generator.Generate(number);
            string jsonString = JsonSerializer.Serialize(data);
            File.WriteAllText(filePath, jsonString);

            return data;
        }
    }

    public class JobTitleIO : JsonIO<JobTitleData>
    {
        private JobTitleFactory _factory;
        protected override Generator<JobTitleData> _generator => _factory;

        public JobTitleIO()
        {
            _factory = new JobTitleFactory();
        }
    }

    public class BuzzPostIO: JsonIO<BuzzPost>
    {
        private BuzzPostFactory _factory;
        protected override Generator<BuzzPost> _generator => _factory;

        public BuzzPostIO()
        {
            _factory = new BuzzPostFactory();
        }
    }

    public class EmployeeIO : JsonIO<Employee>
    {
        private EmployeeFactory _factory;
        protected override Generator<Employee> _generator => _factory;
        
        public EmployeeIO()
        {
            _factory = new EmployeeFactory()
        }
    }
}
