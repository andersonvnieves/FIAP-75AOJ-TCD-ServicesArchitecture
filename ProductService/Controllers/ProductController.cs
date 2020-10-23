using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.DTO;
using ProductService.Model;
using ProductService.Persistence.Repositories;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private CategoryRepository _categoryRepository;
        private KeyWordRepository _keyWordRepository;
        private ProductRepository _productRepository;


        public ProductController(CategoryRepository categoryRepository, KeyWordRepository keyWordRepository, ProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _keyWordRepository = keyWordRepository;
            _productRepository = productRepository;
        }

        
        /// <summary>
        /// Possibilidade de visualizar os detalhes de cada produto;
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetProductById")]
        public IActionResult GetProductById(Guid productId)
        {
            var product = _productRepository.ProductById(productId);
            product.Views++;
            _productRepository.Update(product);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post (ProductDTO entity)
        {
            var keyWordList = new List<KeyWord>();
            foreach (var keyword in entity.KeyWords)
            {
                var kw = _keyWordRepository.KeyWordByName(keyword);
                if (kw != null)
                {
                    keyWordList.Add(kw);
                }
                else
                {
                    keyWordList.Add(_keyWordRepository.Insert(new KeyWord()
                    {
                        Name = keyword
                    }));
                }
            }

            var prod = new Product()
            {
                ProductId = Guid.NewGuid(),
                Name = entity.Name,
                Description = entity.Description,
                UnitPrice = entity.UnitPrice,
                CategoryId = entity.CategoryId,
                KeyWords = keyWordList

            };
            _productRepository.Insert(prod);

            return Created(prod.ProductId.ToString(), prod);
        }

        /// <summary>
        /// Possibilidade de buscar um produto por palavra-chave
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("SearchByKeyWord")]
        public IActionResult SearchByKeyWord(string keyWord)
        {
            var data = _productRepository.ProductsByKeyWord(keyWord);
            return Ok(data);
        }


        /// <summary>
        /// Possibilidade de visualizar os produtos de um determinado categorias
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ListProductByCategoryId")]
        public IActionResult ListProductByCategoryId(Guid categoryId)
        {
            var data = _productRepository.ProductsByCategoryId(categoryId);
            return Ok(data);
        }


        /// <summary>
        /// Possibilidade de exibir os produtos mais vistos por categorias
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostViewdProductByCategoryId")]
        public IActionResult MostViewdProductByCategoryId(Guid categoryId)
        {
            var data = _productRepository.MostViewsdByCategoryId(categoryId);
            return Ok(data);
        }
    }
}
