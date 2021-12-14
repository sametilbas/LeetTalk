using LeetTalk.Data.Entities;
using System.Data.Entity;

namespace LeetTalk.Data
{
    public class OurDbContext:DbContext
    {
        public OurDbContext() : base("LeetTalkDbString")
        {
            Database.SetInitializer(new OurDbInitializer());      
        }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<ConvertRules> ConvertRules { get; set; }
        public virtual DbSet<Results> Results { get; set; }

    }

    public class OurDbInitializer : DropCreateDatabaseIfModelChanges<OurDbContext>
    {
        protected override void Seed(OurDbContext context)
        {
            var languages = new Languages();
            languages.LanguagesType = LanguagesType.Character;
            languages.Title = "LeetTalk";
            context.Languages.Add(languages);

            //var rules = new ConvertRules();
            //rules.LanguagesID = 1;
            //rules.Source = 'A';
            //rules.Result = '4';
            //context.ConvertRules.Add(rules);

            base.Seed(context);
        }
    }
}