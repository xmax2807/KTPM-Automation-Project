using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaseStudy.Data
{
    public class BugReportData : IData<BugReportData>
    {
        public string Reproducibility;
        public string Severity;
        public string Priority;
        public string Summary;
        public string Description;
        public string Steps;
        public string Addition;

        public BugReportData() { }

        public BugReportData(string reprod, string serverity, string prior, string sum, string description, string steps, string addition)
        {
            this.Reproducibility = reprod;
            this.Severity = serverity;
            this.Priority = prior;
            this.Summary = sum;
            this.Description = description.Replace("\\n", "\n");
            this.Steps = steps.Replace("\\n", "\n");
            this.Addition = addition.Replace("\\n", "\n");
        }

        public static BugReportData? Parse(string data, string separator)
        {
            var info = data.Split(separator);
            if (info.Length < 7) return null;
            return new BugReportData(info[0], info[1], info[2], info[3], info[4], info[5], info[6]);
        }

        public List<BugReportData> GetGenerateList(int take)
        {
            throw new NotImplementedException();
        }
    }
}
