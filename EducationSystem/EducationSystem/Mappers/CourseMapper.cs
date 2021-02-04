﻿using EducationSystem.API.Models;
using EducationSystem.API.Models.OutputModels;
using EducationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationSystem.API.Mappers
{
    public class CourseMapper
    {
        public CourseDto ToDto(CourseInputModel inputModel)
        {
            var themeMapper = new ThemeMapper();

            if (string.IsNullOrWhiteSpace(inputModel.Name))
                throw new Exception("Ошибка! Не было передано значение Name!");
            if (string.IsNullOrWhiteSpace(inputModel.Description))
                throw new Exception("Ошибка! Не было передано значение Description!");
            if (inputModel.Duration<1)
                throw new Exception("Ошибка! Неверное значение Duration!");
            return new CourseDto
            {
                Id=inputModel.Id,
                Name = inputModel.Name,
                Description=inputModel.Description,
                Duration=inputModel.Duration                //TODO list of theme ids 
            };
        }

        public List<CourseDto> ToDtos(List<CourseInputModel> inputModels)
        {
            List<CourseDto> courses = new List<CourseDto>();
            if (inputModels == null || inputModels.Count == 0)
            {
                throw new Exception("Ошибка! Курсы не найдены!");
            }
            if (inputModels != null)
            {
                foreach (var model in inputModels)
                {
                    courses.Add(ToDto(model));
                }
            }
            return courses;
        }

        public CourseOutputModel FromDto(CourseDto courseDto)
        {
            if (courseDto == null)
            {
                throw new Exception("Ошибка! Курс не найден!");
            }
            var themeMapper = new ThemeMapper();
            var groupMapper = new GroupMapper();
            var themes = new List<ThemeOutputModel>();
            var groups = new List<GroupOutputModel>();
            if(courseDto.Themes!=null && courseDto.Themes.Count>0)
            {
                themes = themeMapper.FromDtos(courseDto.Themes);
            }
            if (courseDto.Groups != null && courseDto.Groups.Count > 0)
            {
                groups = groupMapper.FromDtos(courseDto.Groups);
            }
            return new CourseOutputModel()
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Description = courseDto.Description,
                Duration = courseDto.Duration,
                Themes = themes,
                Groups = groups
            };
        }

        public List<CourseOutputModel> FromDtos(List<CourseDto> courseDtos)
        {
            if (courseDtos == null || courseDtos.Count == 0)
            {
                throw new Exception("Ошибка! Курсы не найдены!");
            }
            List<CourseOutputModel> models = new List<CourseOutputModel>();
            if (courseDtos != null)
            {
                foreach (var course in courseDtos)
                {
                    models.Add(FromDto(course));
                }
            }
            return models;
        }
    }
}