﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EducationSystem.Data.Models
{
    public class ThemeDto : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TagDto> Tags { get; set; }

        public bool IsDeleted { get; set; }

        public object Clone()
        {
            return new ThemeDto
            {
                Id = Id,
                Name = Name,
                Tags = Tags,
                IsDeleted = IsDeleted
            };
        }

        public override bool Equals(object obj)
        {
            ThemeDto themeObj = (ThemeDto)obj;
            if (themeObj.Id != Id || themeObj.Name != Name || themeObj.IsDeleted != IsDeleted)
            {
                return false;
            }
            return true;
        }
    }
}
