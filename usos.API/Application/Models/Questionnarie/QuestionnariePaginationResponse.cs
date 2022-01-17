using System;

namespace usos.API.Application.Models.Questionnarie
{
    public class QuestionnariePaginationResponse
    {
        public Guid LecturerId { get; set; }
        public string LecturerName { get; set; }

        public string Note { get; set; }

        public int Rating { get; set; }
    }
}