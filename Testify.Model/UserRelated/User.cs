using System.Collections.Generic;
using Testify.Model.Base;

namespace Testify.Model.UserRelated
{
    public class User : DomainRootEntity
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }

        public List<GivenTest> TestsGiven { get; set; }

        public User()
        {
            TestsGiven = new List<GivenTest>();
        }
    }
}
