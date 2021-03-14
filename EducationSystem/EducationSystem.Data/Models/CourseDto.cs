﻿using System;
using System.Collections.Generic;
using EducationSystem.Data.Models;

namespace EducationSystem.Data.Models
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public bool IsDeleted { get; set; }
        public List<ThemeDto> Themes { get; set; }

        public object Clone()
        {
            return new CourseDto
            {
                Id = this.Id,
                Description = this.Description,
                Duration = this.Duration,
                Name = this.Name,
                IsDeleted = this.IsDeleted
            };
        }

        public override bool Equals(object obj)
        {
            CourseDto courseObj = (CourseDto)obj;

            return (Id == courseObj.Id &&
                    Name.Equals(courseObj.Name) &&
                    Description.Equals(courseObj.Description) &&
                    Duration == courseObj.Duration &&
                    IsDeleted == courseObj.IsDeleted);
           
           
        }
    }
}
