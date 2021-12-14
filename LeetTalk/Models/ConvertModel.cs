using LeetTalk.Data.Base;

namespace LeetTalk.Models
{
    public class ConvertModel:BaseDto
    {
        public string SourceText { get; set; }
        public string ResultText { get; set; }
        public int LanguagesId { get; set; }
    }
}