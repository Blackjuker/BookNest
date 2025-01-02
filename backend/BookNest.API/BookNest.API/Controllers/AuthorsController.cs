using BookNest.API.Data;
using BookNest.API.Mapper;
using BookNest.API.Models.Domain;
using BookNest.API.Models.DTO;
using BookNest.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookNest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthorMapper _authorMapper;
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(ApplicationDbContext context, AuthorMapper authorMapper, IAuthorRepository authorRepository)
        {
            _context = context;
            _authorMapper = authorMapper;
            _authorRepository = authorRepository;
        }

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorDto authorDto)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Name == authorDto.Name);

            if (author != null)
            {
                ModelState.AddModelError("erreur", "Cet utilisateur existe déjà");
                return BadRequest(ModelState);
            }

            author = _authorMapper.AuthorDtoToAuthor(authorDto);

            _context.Add(author);
            await _context.SaveChangesAsync();

            return Ok(author);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            var response = new List<AuthorDto>();

            foreach (var author in authors)
            {
                response.Add(_authorMapper.AthorToAuthorDto(author));
            }
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetAuthorId([FromRoute] Guid id)
        {
            var existingAuthor = await _authorRepository.GetAuthorById(id);

            if (existingAuthor is null)
            {
                return NotFound();
            }

            var response = _authorMapper.AthorToAuthorDto(existingAuthor);
            return Ok(response);
        }

        // PUT: https//localhost:7012/api/authors/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditAuthor([FromRoute] Guid id, UpdateAuthorDto updateAuthor)
        {
            // convert DTO to domain model
            var author = _authorMapper.UpdateAuthorDtoToAuthor(updateAuthor);
            author.AuthorId = id;

            author = await _authorRepository.UpdateAsync(author);

            if (author is null)
            {
                return NotFound();
            }

            //convert to dto object

            var response = _authorMapper.AthorToAuthorDto(author);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(typeof(AuthorDto),200)]
        public async Task<IActionResult> DeleteAuthor([FromRoute] Guid id)
        {
            var author = await _authorRepository.DeleteAsync(id);

            if (author is null)
            {
                return NotFound();
            }

            // Convert Domain to DTO
            var response = _authorMapper.AthorToAuthorDto(author);
            return Ok(response);
        }


    }
}
