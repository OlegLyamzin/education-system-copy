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
using Microsoft.AspNetCore.Authorization;
using EducationSystem.Business;
using AutoMapper;
using EducationSystem.API.Models.OutputModels;
using System.Net;
using Microsoft.AspNetCore.Http;
using EducationSystem.Core.CustomExceptions;

namespace EducationSystem.Controllers
{
    // https://localhost:50221/api/tag/
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TagController : ControllerBase
    {
        private ITagService _tagService;
        private readonly IMapper _mapper;
        public TagController(ITagRepository tagRepository, ITagService tagService, IMapper mapper)
        {
            _mapper = mapper;
            _tagService = tagService;
        }
        /// <summary>
        /// Creates Tag
        /// </summary>
        /// <param name="tag"> is used to get all the information about new tag that is necessary to create it</param>
        /// <returns>Returns the TagOutputModel which includes  Id and Name-property</returns>
        // https://localhost:50221/api/tag/
        [ProducesResponseType(typeof(TagOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        [Authorize(Roles = "�������������, �������������, ������, ��������")]
        public ActionResult<TagOutputModel> AddTag([FromBody] TagInputModel tag)
        {
            if (!ModelState.IsValid)
                throw new ValidationException(ModelState);

            var id = _tagService.AddTag(_mapper.Map<TagDto>(tag));
            var result = _mapper.Map<TagOutputModel>(_tagService.GetTagById(id));
            return Ok(result);
        }
        /// <summary>
        /// Gets all the tags
        /// </summary>
        /// <returns>Returns the list of TagOutputModels</returns>
        // https://localhost:50221/api/tag
        [ProducesResponseType(typeof(List<TagOutputModel>), StatusCodes.Status200OK)]
        [HttpGet]
        [Authorize(Roles = "�������������, �������������, ������, ��������, �������")]
        public ActionResult<List<TagOutputModel>> GetTags()
        {
            var tagsDtos = _tagService.GetTags();
            var tags = _mapper.Map<List<TagOutputModel>>(tagsDtos);
            return Ok(tags);
        }
        /// <summary>
        /// Gets only one tag by Id
        /// </summary>
        /// <param name="id"> is used to find necessary tag</param>
        /// <returns>Returns the TagOutputModel which includes Id and Name-property</returns>
        // https://localhost:50221/api/tag/3
        [ProducesResponseType(typeof(TagOutputModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        [Authorize(Roles = "�������������, �������������, ������, ��������, �������")]
        public ActionResult<TagOutputModel> GetTag(int id)
        {
            var tagDto = _tagService.GetTagById(id);
            if (tagDto is null)
                return NotFound($"Tag {id} was not found!");
            var tag = _mapper.Map<TagOutputModel>(tagDto);
            return Ok(tag);
        }
        /// <summary>
        /// Deletes Tag
        /// </summary>
        /// /// <param name="id"> is used to find the tag user wants to delete</param>
        /// <returns>Returns NoContent result</returns>
        //https://localhost:50221/api/tag/3
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        [Authorize(Roles = "�������������, �������������, ������, ��������")]
        public ActionResult DeleteTag(int id)
        {
            if (_tagService.GetTagById(id) is null)
                return NotFound($"Tag {id} was not found!");
            _tagService.DeleteTag(id);
            return NoContent();
        }
    }
}


