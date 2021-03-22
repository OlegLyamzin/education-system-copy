﻿using EducationSystem.Core.Enums;
using EducationSystem.Data.Models;

namespace EducationSystem.Data.Tests.Mocks
{
    public static class HomeworkAttemptMockGetter
    {
        public static HomeworkAttemptDto GetHomeworkAttemptDtoMock(int id)
        {
            return id switch
            {
                1 => new HomeworkAttemptDto()
                {
                    Comment = "Test Comment1 (Description) Here",
                    HomeworkAttemptStatus = (HomeworkAttemptStatus)3,
                },
                2 => new HomeworkAttemptDto()
                {
                    Comment = "Test Comment2 (Description) Here",
                    HomeworkAttemptStatus = (HomeworkAttemptStatus)3,
                },
                3 => new HomeworkAttemptDto()
                {
                    Comment = "Test Comment3 (Description) Here",
                    HomeworkAttemptStatus = (HomeworkAttemptStatus)3,
                },
                4 => new HomeworkAttemptDto(),

                _ => null,
            };
        }
    }
}
