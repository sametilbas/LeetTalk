using LeetTalk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetTalk.Services
{
    public interface ILeetTalkServices
    {
        IEnumerable<HistoryEntriesDto> GetHistoryEntries(int languagesID);
        ResultModel DeleteResult(Guid guid);
        ResultModel ConvertText(ConvertModel convertModel);
    }
}
