﻿using Dapper;
using EducationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace EducationSystem.Data
{
    public class PaymentRepository
    {

        private SqlConnection _connection;

        private string _connectionString = "Data Source=80.78.240.16;Initial Catalog=DevEdu;Persist Security Info=True;User ID=student;Password=qwe!23";
       
        public PaymentRepository()
        {           
            _connection = new SqlConnection(_connectionString);
        }

        public List<PaymentDto> GetPayments()
        {
            var payments = _connection.Query<PaymentDto, UserDto, PaymentDto>(
                    "dbo.Payment_SelectAll",
                    (payment, user) =>
                    {
                        payment.Student = user;
                        return payment;
                    },
                            splitOn: "Id",
                    commandType: System.Data.CommandType.StoredProcedure)               
                .ToList();
            return payments;
        }

        public PaymentDto GetPaymentById(int id)
        {
            var payment = _connection.Query<PaymentDto, UserDto, PaymentDto>(
                    "dbo.Payment_SelectById",
                    (payment, user) =>
                    {
                        payment.Student = user;
                        return payment;
                    },
                    new { id },
                    splitOn: "Id",
                    commandType: System.Data.CommandType.StoredProcedure)
                .FirstOrDefault();
            return payment;
        }

        public PaymentDto GetPaymentByContractNumber(int contractNumber)
        {           
            var payment = _connection.Query<PaymentDto, UserDto, PaymentDto>(
                    "dbo.Payment_SelectByContractNumber",
                    (payment, user) =>
                    {
                        payment.Student = user;
                        return payment;
                    },
                    new { contractNumber },
                    splitOn: "Id",
                    commandType: System.Data.CommandType.StoredProcedure)
                .FirstOrDefault();
            return payment;
        }

        // should return id of inserted entity, use 'QuerySingle' method
        public int AddPayment(int contractNumber, decimal amount, DateTime date, string period, bool IsPaid)
        {
            var result = _connection
                .QuerySingle<int>("dbo.Payment_Add",
                new
                {
                   contractNumber,
                   amount,
                   date,
                   period,
                   IsPaid
                },
                commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        // should return affected rows' count, use 'Execute' method
        public int UpdatePayment(int contractNumber, decimal amount, DateTime date, string period, bool IsPaid)
        {
            var result = _connection
                .Execute("dbo.Course_Update",
                new
                {
                    contractNumber,
                    amount,
                    date,
                    period,
                    IsPaid
                },
                commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        // should return affected rows' count, use 'Execute' method
        public int DeletePayment(int id)
        {
            var result = _connection
                .Execute("dbo.Payment_Delete",
                new
                {
                    id
                },
                commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
       
    }
}