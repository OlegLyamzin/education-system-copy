﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSystem.API.Models.InputModels
{
    public class FeedbackInputModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Messege { get; set; }
        public int LessonID { get; set; }
        public int UnderstandingLevelID { get; set; }
        public LessonInputModel Lesson { get; set; }
        public UserInputModel User { get; set; }
        public UnderstandingLevelInputModel UnderstandingLevel { get; set; }
    }
}