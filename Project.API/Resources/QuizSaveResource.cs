using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Resources {
    public class QuizSaveResource {
        public Guid Id { get; set; }

        [Required]
        public String QuizName { get; set; }

        public enum DifficultyLevel {
            Easy = 0,
            Medium = 1,
            Hard = 2
        }

        public DifficultyLevel Difficulty { get; set; }

        public String ThemeColor { get; set; }

        // NavigationProperties

        public ICollection<Guid> QuizSubjectsId { get; set; }

    }
}
