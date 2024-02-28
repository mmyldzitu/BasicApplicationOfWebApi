using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;

namespace WebApi.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController:ControllerBase
    {
        private readonly ProductContext _productContext;

        public CategoriesController(ProductContext productContext)
        {
            _productContext = productContext;
        }
        [HttpGet("{id}/products")]
        public IActionResult GetWithProducts(int id)
        {
            var data=_productContext.Categories.Include(x => x.Products).SingleOrDefault(x=>x.Id==id);
            if (data == null)
            {
                return NotFound(id);
            }
            return Ok(data);

        }
    }
}
