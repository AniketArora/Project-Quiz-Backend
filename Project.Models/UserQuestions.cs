using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models {
    public class UserQuestions {
        public Guid UserQuestionsID { get; set; }

        public String UserId { get; set; }

        public Guid QuestionId { get; set; }

        public Guid AwnserID { get; set; }


        // NavigationProperties

        public Questions Questions { get; set; }

        public Awnsers Awnsers { get; set; }
    }
}
