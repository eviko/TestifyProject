using Testify.Model.Base;
using Testify.Model.Templates;

namespace Testify.Model.UserRelated
{
    public class GivenAnswer : DomainRootEntity
    {        
        //public QuestionTemplate Question { get; set; }
        //public int QuestionId { get; set; }
        public PossibleAnswer Answer { get; set; }
        public int AnswerId { get; set; }
    }
}