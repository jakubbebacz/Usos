using System;

namespace usos.API.Entities
{
    public class Questionnaire
    {
        public Guid QuestionnaireId { get; set; }

        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public Guid LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        public string Note { get; set; }

        public int Rating { get; set; }
    }
}