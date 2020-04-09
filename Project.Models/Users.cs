using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class Users : IdentityUser {
        public Guid UserId { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; } = new List<IdentityUserRole<string>>();

        // NavigationProperties
        public QuizAwnsers QuizAwnsers { get; set; }

        public UserQuiz UserQuiz { get; set; }
    }
}
