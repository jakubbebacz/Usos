using System;

namespace usos.API.Application.Models.Questionnarie
{
    public class QuestionnarieRequest
    {
        public Guid StudentId { get; set; }

        public Guid LecturerId { get; set; }

        public string Note { get; set; }

        public int Rating { get; set; }
    }
}