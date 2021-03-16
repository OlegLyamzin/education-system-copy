﻿using EducationSystem.Data.Models;
using EducationSystem.Data.Tests.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationSystem.Data.Tests
{
    public class ThemeTests : BaseTest
    {

        private ICourseRepository _courseRepo;
        private IGroupRepository _groupRepo;
        private ILessonRepository _lessonRepo;
        private ITagRepository _tagRepo;
        private List<int> _themeIdList;
        private List<int> _courseIdList;
        private List<int> _groupIdList;
        private List<int> _lessonIdList;
        private List<int> _tagIdList;
        private List<(int, int)> _courseThemeList;
        private List<(int, int)> _lessonThemeList;
        private List<(int, int)> _tagThemeList;

        [OneTimeSetUp]
        public void SetUpTest()
        {
            _courseRepo = new CourseRepository(_options);
            _groupRepo = new GroupRepository(_options);
            _lessonRepo = new LessonRepository(_options);
            _tagRepo = new TagRepository(_options);

            _themeIdList = new List<int>();
            _courseIdList = new List<int>();
            _groupIdList = new List<int>();
            _lessonIdList = new List<int>();
            _tagIdList = new List<int>();
            _courseThemeList = new List<(int, int)>();
            _lessonThemeList = new List<(int, int)>();
            _tagThemeList = new List<(int, int)>();
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ThemeAddPositiveTest(int mockId)
        {
            // Given
            var dto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(mockId).Clone();
            var addedThemeId = _courseRepo.AddTheme(dto);
            Assert.Greater(addedThemeId, 0);

            _themeIdList.Add(addedThemeId);
            dto.Id = addedThemeId;

            // When
            var actual = _courseRepo.GetThemeById(addedThemeId);

            // Then
            Assert.AreEqual(dto, actual);
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        public void ThemeUpdatePositiveTest(int mockId, int updateMockId)
        {
            // Given
            var dto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(mockId).Clone();
            var addedThemeId = _courseRepo.AddTheme(dto);
            _themeIdList.Add(addedThemeId);

            dto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(updateMockId).Clone();
            dto.Id = addedThemeId;
            var affectedRowsCount = _courseRepo.UpdateTheme(dto);


            // When
            var actual = _courseRepo.GetThemeById(addedThemeId);

            // Then
            Assert.AreEqual(1, affectedRowsCount);
            Assert.AreEqual(dto, actual);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 2, 1, 3, 2, 1 })]
        public void GetThemesPositiveTest(int[] mockIds)
        {
            // Given
            var expected = _courseRepo.GetThemes();
            for (int i = 0; i < mockIds.Length; i++)
            {
                var dto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(mockIds[i]).Clone();
                var addedThemeId = _courseRepo.AddTheme(dto);
                _themeIdList.Add(addedThemeId);
                dto.Id = addedThemeId;
                expected.Add(dto);
            }

            // When
            var actual = _courseRepo.GetThemes();

            // Then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(1, true)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        public void ThemeDeleteOrRecoverPositiveTest(int mockId, bool isDeleted)
        {

            //Given
            var dto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(mockId).Clone();
            var addedThemeId = _courseRepo.AddTheme(dto);
            _themeIdList.Add(addedThemeId);
            dto.Id = addedThemeId;
            dto.IsDeleted = isDeleted;

            // When
            var affectedRowsCount = _courseRepo.DeleteOrRecoverTheme(addedThemeId, isDeleted);

            var actual = _courseRepo.GetThemeById(addedThemeId);

            // Then
            Assert.AreEqual(1, affectedRowsCount);
            Assert.AreEqual(dto, actual);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 2, 1, 3, 2, 1 })]
        public void GetThemesByCourseIdPositiveTest(int[] mockIds)
        {
            // Given
            var courseDto = (CourseDto)CourseMockGetter.GetCourseDtoMock(1).Clone();
            var addedCourseId = _courseRepo.AddCourse(courseDto);
            _courseIdList.Add(addedCourseId);

            var expected = new List<ThemeDto>();
            for (int i = 0; i < mockIds.Length; i++)
            {
                var dto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(mockIds[i]).Clone();
                var addedThemeId = _courseRepo.AddTheme(dto);
                _themeIdList.Add(addedThemeId);
                dto.Id = addedThemeId;
                expected.Add(dto);

                _courseRepo.AddCourse_Theme(addedCourseId, addedThemeId);
                _courseThemeList.Add((addedCourseId, addedThemeId));
            }

            // When
            var actual = _courseRepo.GetThemesByCourseId(addedCourseId);

            // Then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 2, 1, 3, 2, 1 })]
        public void GetUncoveredThemesByGroupIdPositiveTest(int[] mockIds)
        {
            // Given
            var courseDto = (CourseDto)CourseMockGetter.GetCourseDtoMock(1).Clone();
            var addedCourseId = _courseRepo.AddCourse(courseDto);
            _courseIdList.Add(addedCourseId);
            courseDto.Id = addedCourseId;

            var groupDto = (GroupDto)GroupMockGetter.GetGroupDtoMock(1).Clone();
            groupDto.Course = courseDto;
            var addedGroupId = _groupRepo.AddGroup(groupDto);
            _groupIdList.Add(addedGroupId);
            groupDto.Id = addedGroupId;

            var lessonDto = (LessonDto)LessonMockGetter.GetLessonDtoMock(1).Clone();
            lessonDto.Date = DateTime.Now.AddDays(10);
            lessonDto.Group = groupDto;
            var addedLessonId = _lessonRepo.AddLesson(lessonDto);
            _lessonIdList.Add(addedLessonId);

            var expected = AddThemeMocksToCourseAndLesson(mockIds, addedCourseId, addedLessonId);

            lessonDto.Date = DateTime.Now.AddDays(-10);
            addedLessonId = _lessonRepo.AddLesson(lessonDto);
            _lessonIdList.Add(addedLessonId);

            AddThemeMocksToCourseAndLesson(mockIds, addedCourseId, addedLessonId);

            // When
            var actual = _courseRepo.GetUncoveredThemesByGroupId(addedGroupId);

            // Then
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 2, 1, 3, 2, 1 })]
        public void AddThemeTagPositiveTest(int[] mockIds)
        {
            // Given
            var themeDto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(1).Clone();
            var addedThemeId = _courseRepo.AddTheme(themeDto);
            _themeIdList.Add(addedThemeId);
            themeDto.Id = addedThemeId;

            var expected = new List<TagDto>();
            for (int i = 0; i < mockIds.Length; i++)
            {
                var tagDto = (TagDto)TagMock.GetTagMock(mockIds[i]).Clone();
                var addedTagId = _tagRepo.TagAdd(tagDto);
                _tagIdList.Add(addedTagId);
                tagDto.Id = addedTagId;
                expected.Add(tagDto);

                _tagRepo.ThemeTagAdd(addedThemeId, addedTagId);
                _tagThemeList.Add((addedThemeId, addedTagId));
            }

            // When
            var actual = _courseRepo.GetThemeById(addedThemeId).Tags;

            // Then
            CollectionAssert.AreEqual(expected, actual);
        }

        [OneTimeTearDown]
        public void SampleTestTearDown()
        {
            DeleteCourseThemes();
            DeleteLessonThemes();
            DeleteTagThemes();
            DeleteTags();
            DeleteLessons();
            DeleteGroups();
            DeleteCourses();
            DeleteThemes();
        }

        private void DeleteTagThemes()
        {
            foreach (var tagTheme in _tagThemeList)
            {
                _tagRepo.ThemeTagDelete(tagTheme.Item1, tagTheme.Item2);
            }
        }

        private void DeleteTags()
        {
            foreach (var tagId in _tagIdList)
            {
                _tagRepo.TagDelete(tagId);
            }
        }

        private void DeleteLessons()
        {
            foreach (var lessonId in _lessonIdList)
            {
                _lessonRepo.HardDeleteLesson(lessonId);
            }
        }

        private void DeleteLessonThemes()
        {
            foreach (var lessonTheme in _lessonThemeList)
            {
                _lessonRepo.DeleteLessonTheme(lessonTheme.Item1, lessonTheme.Item2);
            }
        }

        private void DeleteGroups()
        {
            foreach (var groupId in _groupIdList)
            {
                _groupRepo.HardDeleteGroup(groupId);
            }
        }

        private void DeleteCourseThemes()
        {
            foreach (var courseTheme in _courseThemeList)
            {
                _courseRepo.DeleteCourse_Theme(courseTheme.Item1, courseTheme.Item2);
            }
        }

        private void DeleteCourses()
        {
            foreach (var courseId in _courseIdList)
            {
                _courseRepo.HardDeleteCourse(courseId);
            }
        }

        private void DeleteThemes()
        {
            foreach(var themeId in _themeIdList)
            {
                _courseRepo.HardDeleteTheme(themeId);
            }
        }

        private List<ThemeDto> AddThemeMocksToCourseAndLesson(int[] mockIds, int courseId, int lessonId)
        {

            var dtos = new List<ThemeDto>();
            for (int i = 0; i < mockIds.Length; i++)
            {
                var dto = (ThemeDto)ThemeMockGetter.GetThemeDtoMock(mockIds[i]).Clone();
                var addedThemeId = _courseRepo.AddTheme(dto);
                _themeIdList.Add(addedThemeId);
                dto.Id = addedThemeId;
                dtos.Add(dto);

                _courseRepo.AddCourse_Theme(courseId, addedThemeId);
                _courseThemeList.Add((courseId, addedThemeId));

                _lessonRepo.AddLessonTheme(lessonId, addedThemeId);
                _lessonThemeList.Add((lessonId, addedThemeId));
            }
            return dtos;
        }
    }
}
