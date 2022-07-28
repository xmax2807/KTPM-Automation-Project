using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaseStudy.Data
{
    [Serializable]
    public class JobTitleData : IData<JobTitleData>
    {
        public string Title { get;  set; }
        public string Description { get;  set; }
        public string File { get;  set; }
        public string Note { get;  set; }

        public JobTitleData() : base()
        {
            Title = "";
            Description = "";
            File = "";
            Note = "";
        }
        public JobTitleData(int id)
        {
            Title = "job " + id;
            Description = "Desciption";
            File = "D:/bin/Study/Y3/HK3/Testing/Project/Automation/ProjectCaseStudy/ProjectCaseStudy/Data/1.gif";
            Note = "Note";
        }

        public List<JobTitleData> GetGenerateList(int take)
        {
            List<JobTitleData> result = new(take);
            for (int i = 0; i < take; i++)
            {
                result.Add(new JobTitleData(i + 1));
            }

            return result;
        }
    }
}
