
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Model;
using ProductService.Persistence.Repositories;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _categoryRepository.ListAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(string categoryName)
        {
            var entity = new Category()
            {
                CategoryId = Guid.NewGuid(),
                Name = categoryName
            };
            _categoryRepository.Insert(entity);

            return Created(entity.CategoryId.ToString(), entity);
        }
    }
}
