using System;
using System.Collections.Generic;
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
            ID = "000" + id;
            FirstName = firstname;
            LastName = lastname;
            Username = username;
            Password = password;
        }
        public List<Employee> GetGenerateList(int take)
        {
            string[] firstname = new string[5];
            string[] lastname = new string[5];
            string[] username = new string[5];
            const string password = "Quanghuy@2807";

            var result = new List<Employee>();
            for(int i = 0; i < take; i++)
            {
                result.Add(new Employee(i + 1));
            }
            return result;
        }
    }
}
