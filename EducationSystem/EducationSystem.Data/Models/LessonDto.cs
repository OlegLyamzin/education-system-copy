﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationSystem.Data.Models
{
   public  class LessonDto
   {
        public int Id { get; set; }
        public GroupDto Group { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public List<ThemeDto> Themes { get; set; }


        public override bool Equals(object obj)
        {
            LessonDto lesson = (LessonDto)obj;
            if(!Id.Equals(lesson.Id) || !Comment.Equals(lesson.Comment) || !Date.Equals(lesson.Date))
            {
                return false;
            }
            return true;
        }
   }
}
