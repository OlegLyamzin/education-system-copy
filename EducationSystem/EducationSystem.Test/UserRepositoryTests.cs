using NUnit.Framework;
using System;
using EducationSystem.Data.Models;
using EducationSystem.Data;
using System.Collections.Generic;
using System.Globalization;

namespace EducationSystem.Data.Tests
{
    public class UserTests : BaseTest
    {
        private List<int> _addedUserDtoIds;
        private UserRepository _repository;
      

        [OneTimeSetUp]
        public void UserRepositoryTestsSetup()
        {
            _addedUserDtoIds = new List<int>();
            _repository = new UserRepository(_options);

        }

        // entity tests are below:

        [TestCase(1)]
        public void UserAddPositiveTest(int mockId)
        {
            // Given
            var dto = (UserDto)MockGetter.GetUserDtoMock(mockId).Clone();
            var addedEntityId = _repository.AddUser(dto);
           //_repository.AddRoleToUser()
            Assert.Greater(addedEntityId, 0);
            
            _addedUserDtoIds.Add(addedEntityId);
            dto.Id = addedEntityId;

            // When
            var actual = _repository.GetUserById(addedEntityId);

            // Then
            Assert.AreEqual(dto, actual);
        }

        /*    
          [TestCase(1)]
          public void UserAddTests(int dtoMockNumber)
          {
              UserDto expected = GetMockUserAdd(dtoMockNumber);
              var added = _repository.AddUser(expected);
              _addedUserDtoIds.Add(added);
              expected.Id = added;

              if (_addedUserDtoIds.Count == 0) { Assert.Fail("User addition failed"); }
              else
              {
                  UserDto actual = _repository.GetUserById(_addedUserDtoIds[_addedUserDtoIds.Count - 1]);
                  Assert.AreEqual(expected, actual);
              }
          }

          //[TestCase(1)]
          //public void UserDelete(int dtoMockNumber)
          //{
          //    UserDto expected = GetMockUserAdd(dtoMockNumber);
          //    _userId.Add(_uRepo.AddUser(expected));
          //    if (_userId.Count == 0) { Assert.Fail("User addition failed"); }
          //    else
          //    {
          //        int newId = _userId[_userId.Count - 1];
          //        _uRepo.DeleteUser(newId);
          //        UserDto actual = _uRepo.GetUserById(newId);
          //        if (actual == null) { Assert.Pass(); }
          //        else Assert.Fail("Deletion went wrong");
          //    }
          //}

          [TestCase(1)]
          public void UserUpdate(int dtoMockNumber)
          {
              UserDto expected = GetMockUserAdd(dtoMockNumber);
              _addedUserDtoIds.Add(_uRepo.AddUser(expected));
              if (_addedUserDtoIds.Count == 0) { Assert.Fail("User addition failed"); }
              else
              {
                  int newId = _addedUserDtoIds[_addedUserDtoIds.Count - 1];
                  expected.Id = newId;
                  _uRepo.UpdateUser(expected);
                  UserDto actual = _uRepo.GetUserById(newId);
                  Assert.AreEqual(expected, actual);
              }
          }



          //[TestCase(1)]
          //public void RoleAddTests(int dtoMockNumber)
          //{
          //    RoleDto expected = GetMockRoleAdd(dtoMockNumber);
          //    var added = _uRepo.AddRole(expected);
          //    _roleId.Add(added);
          //    expected.Id = added;

          //    if (_roleId.Count == 0)
          //    {
          //        Assert.Fail("Role addition failed");
          //    }
          //    else
          //    {
          //        RoleDto actual = _uRepo.GetRoleById(_roleId[_roleId.Count - 1]);
          //        Assert.AreEqual(expected, actual);
          //    }
          //}

          //[TestCase(1)]
          //public void RoleDelete(int dtoMockNumber)
          //{
          //    RoleDto expected = GetMockRoleAdd(dtoMockNumber);
          //    _roleId.Add(_uRepo.AddRole(expected));
          //    if (_roleId.Count == 0) { Assert.Fail("Role addition failed"); }
          //    else
          //    {
          //        int newId = _roleId[_roleId.Count - 1];
          //        _uRepo.DeleteRole(newId);
          //        RoleDto actual = _uRepo.GetRoleById(newId);
          //        if (actual == null) { Assert.Pass(); }
          //        else Assert.Fail("Deletion went wrong");
          //    }
          //}

          //[TestCase(1)]
          //public void RoleUpdate(int dtoMockNumber)
          //{
          //    RoleDto expected = GetMockRoleAdd(dtoMockNumber);
          //    _roleId.Add(_uRepo.AddRole(expected));
          //    if (_roleId.Count == 0) 
          //    {
          //        Assert.Fail("Role addition failed"); 
          //    }
          //    else
          //    {
          //        int newId = _roleId[_roleId.Count - 1];
          //        expected.Id = newId;
          //        _uRepo.UpdateRole(expected);
          //        RoleDto actual = _uRepo.GetRoleById (newId);
          //        Assert.AreEqual(expected, actual);
          //    }
          //}
          //[TearDown]
          //public void UserRepositiryTestsTearDown()
          //{
          //    UserRepository uRepo = new UserRepository();
          //    foreach (int elem in _userRoleId)
          //    {
          //        uRepo.DeleteRoleToUser(elem);
          //    }
          //    foreach (int elem in _roleId)
          //    {
          //        uRepo.DeleteRole(elem);
          //    }
          //    foreach (int elem in _userId)
          //    {
          //        uRepo.DeleteUser(elem);
          //    }
          //}

          private UserDto GetMockUserAdd(int n)
          {
              switch (n)
              {
                  case 1:
                      UserDto userDto = new UserDto();
                      userDto.Email = "Use1r12@mail.ru";
                      userDto.FirstName = "Anton";
                      //userDto.RegistrationDate = DateTime.ParseExact("06.05.2000", "dd.MM.yyyy", CultureInfo.InvariantCulture);
                      userDto.BirthDate = DateTime.ParseExact("05.05.2000", "dd.MM.yyyy", CultureInfo.InvariantCulture);
                      //List<RoleDto> roles= new List<RoleDto>();
                      //roles.Add(GetMockRoleAdd(n));
                      //userDto.Roles =roles;
                      userDto.IsDeleted = false;
                      userDto.LastName = "Negodyaj";
                      userDto.Password = "1234567";
                      userDto.Phone = "9999999997";
                      userDto.UserPic = " 22";
                      userDto.Login = "AN711";
                      return userDto;
                  default:
                      throw new Exception();
              }
          }
        */
        //private RoleDto GetMockRoleAdd(int n)
        //{
        //    switch (n)
        //    {
        //        case 1:
        //            RoleDto roleDto = new RoleDto();
        //            roleDto.Name = "Teacher7";
        //            return roleDto;
        //        default:
        //            throw new Exception();
        //    }
        //}

        [TearDown]
        public void SampleTestTearDown()
        {
            _addedUserDtoIds.ForEach(id =>
            {
                _repository.HardDeleteUser(id); 
            });
        }


        public static class MockGetter
        {
            public static UserDto GetUserDtoMock(int mockId)
            {

                UserDto userDto = mockId switch
                {
                    1 => new UserDto()
                    {
                        Email = "Use1r13@mail.ru",
                        FirstName = "Anton",
                        BirthDate = DateTime.ParseExact("05.05.2000", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                        IsDeleted = false,
                        LastName = "Negodyaj",
                        Password = "1234567",
                        Phone = "9999999997",
                        UserPic = " 22",
                        Login = "AN712",
                    },
                    _ => throw new NotImplementedException()
                };

                return userDto;
            }

        }
    }
}
