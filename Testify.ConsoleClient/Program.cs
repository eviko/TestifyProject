using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testify.Ef;
using Testify.Model;
using Testify.Model.Templates;

namespace Testify.ConsoleClient
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                TestifyContext context = new TestifyContext();
                var tests = context.TestTemplates.Where(x => x.Title.Contains("C#")).ToList();
                Console.WriteLine("Total Tests " + context.TestTemplates.Count());
                foreach (var test in tests)
                {
                    test.QuestionsPerPage = 231;
                    Console.WriteLine("Take test: " + test);
                }
                var testToDelete = context.TestTemplates.Where(x => x.Id == 5).FirstOrDefault();
                foreach (var test in context.TestTemplates)
                {
                    Console.WriteLine("Take test: " + test);
                }
                Console.WriteLine("Total Tests " + context.TestTemplates.Count());
                if (testToDelete != null)
                    context.TestTemplates.Remove(testToDelete);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }

        static IList<TestTemplate> Tests = new List<TestTemplate>();
        static void OldTest()
        {
            CreateDummyDb();
            foreach (var test in Tests)
            {
                int score = 0;
                Console.WriteLine("Take test" + test);
                var orderedQuestions = (from k in test.GetQuestions() orderby k.QuestionOrder select k).ToList();
                foreach (var q in orderedQuestions)
                {
                    Console.WriteLine(q.Question);
                    int count = 0;
                    foreach (var a in q.PossibleAnswers)
                    {
                        count++;
                        Console.WriteLine($"\t{count}){a.Answer}");
                    }
                    Console.WriteLine("Answer is ???");
                    var correct = Convert.ToInt32(Console.ReadLine());
                    if (q.PossibleAnswers[correct - 1].IsTheCorrect)
                    {
                        Console.WriteLine("Correct");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
                Console.WriteLine($"Your score is {score}");
            }
        }
        static void CreateDummyDb()
        {
            TestTemplate test = new TestTemplate();
            test.Id = 1;
            test.Title = "A C# Test";
            QuestionTemplate q1 = new QuestionTemplate();
            q1.Question = "What is delegate";
            q1.Id = 1;
            var answer1 = new PossibleAnswer();
            answer1.Answer = "A link to a function";
            answer1.IsTheCorrect = true;
            answer1.QuestionTemplateId = q1.Id;
            q1.PossibleAnswers.Add(answer1);

            answer1 = new PossibleAnswer();
            answer1.Answer = "An integer";
            answer1.IsTheCorrect = false;
            answer1.QuestionTemplateId = q1.Id;
            q1.PossibleAnswers.Add(answer1);

            test.AddQuestion(q1);
            Tests.Add(test);
        }
    }
}
