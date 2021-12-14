using LeetTalk.Models;
using LeetTalk.Services;
using System.Web.Mvc;

namespace LeetTalk.Controllers
{
    public class HomeController : Controller
    {
        ILeetTalkServices _talkService;
        public HomeController(ILeetTalkServices leetTalkServices)
        {
            this._talkService = leetTalkServices;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ConvertText(string text)
        {
            var conv = _talkService.ConvertText(new Models.ConvertModel { LanguagesId = 1, SourceText = text });
            return Json(conv,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetConvertText(int languagesID)
        {
            var convHistories = _talkService.GetHistoryEntries(languagesID);
            return Json(convHistories, JsonRequestBehavior.AllowGet);
        }
    }
}