using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class UserQuiz {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Guid QuizId { get; set; }

        public int Score { get; set; }

        //NavigationProperties

        public IdentityUser User { get; set; }

        public Quiz Quiz { get; set; }

        public ICollection<QuizAnswer> QuizAnswers { get; set; }
    }
}
