using LeetTalk.Data.Base;

namespace LeetTalk.Data.Entities
{
    public class Results:BaseEntities
    {
        public string SourceText { get; set; }
        public string ResultText { get; set; }
        public int LanguagesID { get; set; }
        public Languages Languages { get; set; }
    }
}