using AutoMapper;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DataModels;
using Models.ViewModels;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, ILogger<CategoryController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("CreateCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCategory(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateCategory)}");
                return BadRequest(ModelState);
            }
            Category category = _mapper.Map<Category>(categoryVM);
            await _unitOfWork.Category.Create(category);
            return Ok();
        }

        [HttpGet("GetCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = await _unitOfWork.Category.Get(q => q.Id == id);
            var result = _mapper.Map<CategoryVM>(category);
            return Ok(result);
        }

        [HttpGet("GetCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.Category.GetEvery();
            var results = _mapper.Map<IList<Category>>(categories);
            return Ok(results);
        }

        [HttpPut("UpdateCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryVM categoryVM)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
                return BadRequest(ModelState);
            }

            var category = await _unitOfWork.Category.Get(q => q.Id == id);
            if (category == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateCategory)}");
                return BadRequest("Submitted data is invalid");
            }

            _mapper.Map(categoryVM, category);
            await _unitOfWork.Category.Update(category);
            return NoContent();
        }

        [HttpDelete("DeleteCategory")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
                return BadRequest();
            }

            var category = await _unitOfWork.Category.Get(q => q.Id == id);
            if (category == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteCategory)}");
                return BadRequest();
            }

            await _unitOfWork.Category.Delete(id);
            return NoContent();
        }

    }
}