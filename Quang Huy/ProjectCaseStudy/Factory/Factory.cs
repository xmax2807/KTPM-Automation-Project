using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaseStudy.Data
{
    public interface IData<T>
    {
        List<T> GetGenerateList(int take); 
    }
    public abstract class Generator<T>
    {
        public List<T> Generate(int num)
        {
            var instance = CreateInstance();
            return instance.GetGenerateList(num);
        }

        public abstract IData<T> CreateInstance();
    }
    public class JobTitleFactory : Generator<JobTitleData>
    {

        public override JobTitleData CreateInstance() => new JobTitleData();
        
    }

    public class BuzzPostFactory : Generator<BuzzPost>
    {
        public override BuzzPost CreateInstance() => new BuzzPost();
        
    }

    public class EmployeeFactory : Generator<Employee>
    {
        public override Employee CreateInstance() => new Employee();
    }

    public class AccountFactory : Generator<Account>
    {
        public override Account CreateInstance() => new Account();
    }

    public class BugReportFactory : Generator<BugReportData>
    {
        public override BugReportData CreateInstance() => new BugReportData();
    }
}
