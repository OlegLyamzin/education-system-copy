﻿using Dapper;
using EducationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EducationSystem.Data.Models
{
    public class HomeworkAttemptRepository : BaseRepository
    {

        public HomeworkAttemptRepository()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public List<HomeworkAttemptDto> GetHomeworkAttempts()
        {
            var homeworkAttempt = _connection
                .Query<HomeworkAttemptDto>("dbo.HomeworkAttempt_SelectAll", commandType: System.Data.CommandType.StoredProcedure)
                .ToList();
            return homeworkAttempt;
        }

        public HomeworkAttemptDto GetHomeworkAttemptById(int id)
        {
            var homeworkAttempt = _connection
                .Query<HomeworkAttemptDto>("dbo.HomeworkAttempt_SelectById", new { id }, commandType: System.Data.CommandType.StoredProcedure)
                .FirstOrDefault();
            return homeworkAttempt;
        }

        public int AddHomeworkAttempt(string comment, int userId, int homeworkAttemptId, int statusId)
        {
            var result = _connection
                .Execute("dbo.HomeworkAttempt_Add",
                new { comment, userId, homeworkAttemptId, statusId },
                commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public int UpdateHomeworkAttempt(int id, string comment, int statusId)
        {
            var result = _connection
                .Execute("dbo.HomeworkAttempt_Update",
                new { id, comment, statusId },
                commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        // Код размещен в HomeworkRepository

        //public int DeleteHomeworkAttempt(int id)
        //{
        //    var result = _connection
        //        .Execute("dbo.HomeworkAttempt_Delete", 
        //        new { id }, 
        //        commandType: System.Data.CommandType.StoredProcedure);
        //    return result;
        //}

        //public int RecoverHomeworkAttempt(int id)
        //{
        //    var result = _connection
        //        .Execute("dbo.HomeworkAttempt_Recover",
        //        new { id },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //    return result;
        //}

        //public int HardDeleteHomeworkAttempt(int id)
        //{
        //    var result = _connection
        //        .Execute("dbo.HomeworkAttempt_HardDelete",
        //        new { id },
        //        commandType: System.Data.CommandType.StoredProcedure);
        //    return result;
        //}


        public HomeworkAttempt_AttachmentDto GetHomeworkAttempt_AttachmentById(int id)
        {
            var data = _connection.
                QueryFirstOrDefault<HomeworkAttempt_AttachmentDto>(
                "dbo.HomeworkAttempt_Attachment_SelectById", new { id }, commandType: System.Data.CommandType.StoredProcedure);
            return data;
        }
        public int AddHomeworkAttempt_Attachment(HomeworkAttempt_AttachmentDto newObject)
        {
            var data = _connection
                .QueryFirst<int>("dbo.HomeworkAttempt_Attachment_Add",
                new
                {
                    HomeworkAttemptId = newObject.HomeworkAttemptId,
                    AttachmentId = newObject.AttachmentId
                },
                commandType: System.Data.CommandType.StoredProcedure);
            return data;
        }
        public int DeleteHomeworkAttempt_AttachmentById(int id)
        {
            int rowsAffected = _connection.Execute(
                "dbo.HomeworkAttempt_Attachment_Delete",
                new { id },
                commandType: System.Data.CommandType.StoredProcedure);
            return rowsAffected;
        }
    }
}
