using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController:ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result= await _productRepository.GetAllAsync();
            if (result.Count==0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result= await _productRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(id);
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var newProduct = await _productRepository.CreateAsync(product);
            return Created(string.Empty, newProduct);
        }
        [HttpPut]
        public async Task<IActionResult> Update (Product product)
        {
            var checkProduct = await _productRepository.GetByIdAsync(product.Id);
            if (checkProduct == null)
            {
                return NotFound(product.Id);
            }
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var deletedEntity = await _productRepository.GetByIdAsync(id);
            if (deletedEntity == null)
            {
                return NotFound(id);
            }
            await _productRepository.RemoveAsync(id);
            return NoContent();
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm]IFormFile formFile)
        {
            var newName = Guid.NewGuid() + "." + Path.GetExtension(formFile.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newName);
            var stream = new FileStream(path, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return Created(string.Empty, formFile);
        }
    }
}
