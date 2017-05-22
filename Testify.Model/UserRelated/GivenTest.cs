using System;
using System.Collections.Generic;
using Testify.Model.Base;
using Testify.Model.Templates;

namespace Testify.Model.UserRelated
{
    public class GivenTest : DomainRootEntity
    {
        public DateTime DateGiven { get; set; }
        public int Score { get; set; }
        public TestTemplate TheTestGiven { get; set; }
        public EnumTestResult TestResult { get; set; }

        public List<GivenAnswer> Answers { get; set; }

        public GivenTest()
        {
            Answers = new List<GivenAnswer>();
        }
    }
}