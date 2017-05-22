using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testify.Ef.Migrations;
using Testify.Model.Templates;
using Testify.Model.UserRelated;

namespace Testify.Ef
{
    public class TestifyContext : DbContext
    {

        static TestifyContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestifyContext, Configuration>());
        }

        public DbSet<TestTemplate> TestTemplates { get; set; }
        public DbSet<QuestionTemplate> QuestionTemplates { get; set; }
        public DbSet<PossibleAnswer> PossibleAnswers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
