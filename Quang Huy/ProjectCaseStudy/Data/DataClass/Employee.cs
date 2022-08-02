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
            ID = "9" + id;
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
            int n = Math.Min(take, username.Length);
            for(int i = 0; i < n; i++)
            {
                result.Add(new Employee(i + 1, "Quang", "Huy", username[i], password));
            }
            return result;
        }
    }

    public class Account : IData<Account>
    {
        public string EmployeeName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account()
        {
            EmployeeName = "";
            Username = "";
            Password = "";
        }
        public Account(int id)
        {
            EmployeeName = "Admin 1";
            Username = "admin0" + id;
            Password = "Quanghuy@2807";
        }
        public List<Account> GetGenerateList(int take)
        {
            var result = new List<Account>(take);
            for(int i = 1; i <= take; i++)
            {
                result.Add(new Account(i));
            }
            return result;
        }
    }
}
