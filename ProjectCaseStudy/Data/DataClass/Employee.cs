using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaseStudy.Data
{
    public class Employee : IData<Employee>
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Employee()
        {
            ID = "";
            FirstName = "";
            LastName = "";
            Username = "";
            Password = "";
        }
        public Employee(int id, string firstname, string lastname, string username, string password)
        {
            ID = "employee " + id;
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Password = password;
        }
        public List<Employee> GetGenerateList(int take)
        {
            string[] username = File.ReadAllLines("Data\\randomCharacters.txt");
            const string password = "Quanghuy@2807";

            var result = new List<Employee>();
            for(int i = 0; i < take; i++)
            {
                result.Add(new Employee(i + 1, "Quang", "Huy", username[i], password));
            }
            return result;
        }
    }
}
