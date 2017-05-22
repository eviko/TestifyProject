using Testify.Model.Base;

namespace Testify.Model.Templates
{
    public class PossibleAnswer : DomainRootEntity
    {        
        public int QuestionTemplateId { get; set; }
        public string Answer { get; set; }
        public string Explanation { get; set; }
        public bool IsTheCorrect { get; set; }
    }
}