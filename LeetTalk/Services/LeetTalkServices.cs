using LeetTalk.Data;
using LeetTalk.Data.Entities;
using LeetTalk.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetTalk.Services
{
    public class LeetTalkServices : ILeetTalkServices
    {
        OurDbContext _context = new OurDbContext();
        //Kullanıcının yapmış olduğu eski işlemleri getirecek olan get metotu
        public IEnumerable<HistoryEntriesDto> GetHistoryEntries(int languagesID)
        {
            var historylist = _context.Results.Where(x => !x.IsDeleted && x.LanguagesID == languagesID).ToList();
            if (historylist.Any())
                return historylist.Select(x => new HistoryEntriesDto
                {
                    Guid = x.Guid,
                    SourceText = x.SourceText,
                    Id = x.Id,
                    LanguagesId = x.Id,
                    //LanguagesName = x.Languages.Title,
                    ResultText = x.ResultText
                }).ToList();
            else
                return new List<HistoryEntriesDto>();
        }
        //Kullanıcının silmek istediği resultları silen metot
        public ResultModel DeleteResult(Guid guid)
        {
            var result = _context.Results.FirstOrDefault(x => x.Guid == guid);
            if (result is null)
                return new ResultModel { IsSuccess = false, ResultMessage = "Böyle bir kayıt bulunamadı!!" };
            else
            {
                _context.Results.Remove(result);
                _context.SaveChanges();
                return new ResultModel { IsSuccess = true, ResultMessage = "Başarılı bir şekilde silinmiştir" };
            }
        }
        //Kullanıcının girmiş olduğu texti çeviren ve sonucu dönderen metot
        public ResultModel ConvertText(ConvertModel convertModel)
        {
            if (!String.IsNullOrEmpty(convertModel.SourceText))
            {
                var languages = _context.Languages.FirstOrDefault(x => x.Id == convertModel.LanguagesId);
                if (languages.Id == 0)
                    return new ResultModel { IsSuccess = false, ResultMessage = "Dönüştürülecek dil bulunamadı!!" };

                var rules = _context.ConvertRules.Where(x => x.LanguagesID == convertModel.LanguagesId).ToList();

                var result = "";

                if (languages.LanguagesType == Data.Entities.LanguagesType.Character)
                {
                    for (int i = 0; i < convertModel.SourceText.Length; i++)
                    {
                        //Boşluk 
                        if (string.IsNullOrWhiteSpace(convertModel.SourceText[i].ToString()))
                        {
                            result += convertModel.SourceText[i];
                            continue;
                        }
                        //Eşleşme
                        if (rules.Any(x => x.Source == convertModel.SourceText[i].ToString()))
                        {
                            result += rules.FirstOrDefault(x => x.Source.Equals(convertModel.SourceText[i].ToString())).Result.ToCharArray()[0];
                        }
                        //Eşleşme sağlanamadı
                        if (!rules.Any(x => x.Source == convertModel.SourceText[i].ToString()))
                        {
                            result += convertModel.SourceText[i];
                            continue;
                        }
                    }
                }
                else
                {
                    var wordList = convertModel.SourceText.Split(' ');
                    foreach (var word in wordList)
                    {
                        var s = rules.Any(x => x.Source.Equals(word));
                    }
                }
                _context.Results.Add(new Results
                {
                    LanguagesID = convertModel.LanguagesId,
                    SourceText = convertModel.SourceText,
                    ResultText = result                  
                });
                _context.SaveChanges();
                return new ResultModel { IsSuccess = true, ResultMessage = "Başarılı bir şekilde çevrilmiştir", Entity = result };
            }
            else
                return new ResultModel { IsSuccess = false, ResultMessage = "Kaynak metin boş olamaz" };
        }
    }
}