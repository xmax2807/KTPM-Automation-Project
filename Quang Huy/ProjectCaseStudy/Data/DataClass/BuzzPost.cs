using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaseStudy.Data
{
    [Serializable]
    public class BuzzPost : IData<BuzzPost>
    {
        public string Content { get; set; }
        public string[] Images { get;set; }
        
        public BuzzPost()
        {
            string filePath = "Data\\0.png";
            string path = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            Images = new string[2] { path, path };
            Content = "Disciple";
        }
        List<BuzzPost> IData<BuzzPost>.GetGenerateList(int take)
        {
            List<BuzzPost> result = new(take);
            for(int i = 0; i < take; i++)
            {
                result.Add(new BuzzPost());
            }
            return result;
        }
    }
}
