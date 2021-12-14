using LeetTalk.Data.Base;

namespace LeetTalk.Data.Entities
{
    public class Languages:BaseEntities
    {
        public string Title { get; set; }
        public LanguagesType LanguagesType { get; set; }
    }
    public enum LanguagesType{
        Word=10,
        Character=20
    }
}