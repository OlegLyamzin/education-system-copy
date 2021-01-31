using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationSystem.API.Models;
using EducationSystem.API.Mappers;
using EducationSystem.Data;
using EducationSystem.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace EducationSystem.Controllers
{
    // https://localhost:50221/api/tag/
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private TagRepository _repo;
        private TagMapper _groupMapper;

        public TagController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _repo = new TagRepository();
        }

        // https://localhost:50221/api/tag/add
        [HttpPost]
        public ActionResult AddNewTag([FromBody] TagInputModel tag)
        {
            var tagDto = _groupMapper.ToDto(tag);
            var result=_repo.TagAdd(tagDto);
            return Ok($"Тег№{result} добавлен");
        }

        // https://localhost:50221/api/tag
        [HttpGet]
        public ActionResult GetTags()
        {
            var tags = _repo.GetTags();
            return Ok(tags);
        }

        // https://localhost:50221/api/tag/3
        [HttpGet("{id}")]
        public dynamic GetTag(int id)
        {
            var tag = _repo.GetTagById(id);
            return Ok(tag);
        }

        // https://localhost:50221/api/tag/3
        [HttpPut]
        public ActionResult UpdateTag( [FromBody] TagDto data)
        {
            _repo.TagUpdate(data);
            return Ok("Tag обновлён");
        }

        // https://localhost:50221/api/tag/3
        [HttpDelete("{id}")]
        public ActionResult DeleteTag(int id)
        {
            _repo.TagDelete(id);
            return Ok("Tag удалён");
        }
    }
}