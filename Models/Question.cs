﻿namespace Hospital.Models
{
    public class Question
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }

        public string Text { get; set; }
        public string Answer { get; set; }

        public Questionnaire Questionnaire { get; set; }
    }
}
