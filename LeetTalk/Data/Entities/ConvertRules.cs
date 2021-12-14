using LeetTalk.Data.Base;

namespace LeetTalk.Data.Entities
{
    public class ConvertRules:BaseEntities
    {
        public string Source { get; set; }
        public string Result { get; set; }
        public int LanguagesID { get; set; }
        public Languages Languages { get; set; }
    }
}