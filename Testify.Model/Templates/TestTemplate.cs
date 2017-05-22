using System;
using System.Collections.Generic;
using Testify.Model.Base;

namespace Testify.Model.Templates
{
    public class TestTemplate : DomainRootEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        private int _questionsPerPage;

        public int QuestionsPerPage
        {
            get { return _questionsPerPage; }
            set
            {
                if (value <=0)
                    throw new Exception("Incorrect Value for Questions Per Page");
                _questionsPerPage = value;
            }
        }

        public int MinutesToComplete { get; set; }
        public int ScoreToPass { get; set; }

        private IList<QuestionTemplate> Questions { get; }

        public TestTemplate()
        {
            QuestionsPerPage = 1;
            Questions = new List<QuestionTemplate>();
        }

        public override string ToString()
        {
            return Title;
        }

        public void AddQuestion(QuestionTemplate question)
        {
            if (!Questions.Contains(question))
            {
                question.TestTemplateId = this.Id;
                question.Template = this;
                Questions.Add(question);
            }
        }

        public void RemoveQuestion(QuestionTemplate question)
        {
            if (Questions.Contains(question))
                Questions.Remove(question);
        }

        public IList<QuestionTemplate> GetQuestions()
        {
            return Questions;
        }
    }
}
