﻿using Dapper;
using EducationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EducationSystem.Data
{
    public class MaterialRepository: BaseRepository
    {
        public MaterialRepository()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public List<MaterialDto> GetMaterials()
        {
            var materials = _connection
                .Query<MaterialDto>("dbo.Material_SelectAll", commandType: System.Data.CommandType.StoredProcedure)
                .ToList();
            return materials;
        }

        public MaterialDto GetMaterialById(int id)
        {
            var materials = _connection
                .Query<MaterialDto>("dbo.Material_SelectById", new { id }, commandType: System.Data.CommandType.StoredProcedure)
                .FirstOrDefault();
            return materials;
        }

        public int GetMaterialsAdd(MaterialDto material)
        {
            int rows = _connection
                .Execute("dbo.Material_Add", 
                new 
                { 
                    material.Link,
                    material.Description,
                    material.IsDeleted
                }, 
                commandType: System.Data.CommandType.StoredProcedure);
            return rows;
        }

        public int UpdateMaterial(MaterialDto material)
        {
            int rows = _connection
                .Execute("dbo.Material_Update", 
                new 
                {
                    material.Id,
                    material.Link,
                    material.Description
                }, 
                commandType: System.Data.CommandType.StoredProcedure);
            return rows;
        }

        public int DeleteMaterialById(int id)
        {
            int rows = _connection
                .Execute("dbo.Material_Delete", new { id }, commandType: System.Data.CommandType.StoredProcedure);
            return rows;
        }
    }
}
