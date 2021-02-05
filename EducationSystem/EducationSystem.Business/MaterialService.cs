﻿using EducationSystem.Data;
using EducationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationSystem.Business
{
    public class MaterialService
    {
        private MaterialRepository _materialRepository;
        public MaterialService()
        {
            _materialRepository = new MaterialRepository();
        }
        public List<MaterialDto> GetMaterials() { return _materialRepository.GetMaterials(); }
        public MaterialDto GetMaterialById(int id) { return _materialRepository.GetMaterialById(id); }
        public int AddMaterial(MaterialDto material) { return _materialRepository.AddMaterial(material); }
        public int UpdateMaterial(int id, MaterialDto material) { return _materialRepository.UpdateMaterial(id, material); }
        public int DeleteMaterialById(int id) { return _materialRepository.DeleteMaterialById(id); }


    }
}