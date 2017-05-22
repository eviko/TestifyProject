using System.Collections.Generic;
using Testify.Model.Base;

namespace Testify.Model.Templates
{
    public class QuestionTemplate : DomainRootEntity
    {        
        public int TestTemplateId { get; set; }
        public TestTemplate Template { get; set; }
        public int QuestionOrder { get; set; }
        public string Question { get; set; }

        public IList<PossibleAnswer> PossibleAnswers { get; set; }

        public QuestionTemplate()
        {
            PossibleAnswers = new List<PossibleAnswer>();
        }

        public override string ToString()
        {
            return Question;
        }
    }
}