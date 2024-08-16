using hometask_webappi_intro.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPiPractice.Dtos;

namespace hometask_webappi_intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public List<Product> list = new()
        {
            new(){Name="Product1",Description="bbbbbbbbbbbbbbb"},
            new(){Name="Product2",Description="bbbbbbbbbbbbbbb"},
            new(){Name="Product3",Description="bbbbbbbbbbbbbbb"},
            new(){Name="Product4",Description="bbbbbbbbbbbbbbb"}
        };
        [HttpGet]
        public IActionResult Get()
        {
            return StatusCode(200, list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var existProduct = list.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return StatusCode(StatusCodes.Status404NotFound);
            return Ok(existProduct);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Description = product.Description,
            };
            list.Add(newProduct);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            var existProduct = list.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.Name = product.Name;
            existProduct.Description = product.Description;
            return StatusCode(204);
        }

        [HttpPatch("{id}")]
        public IActionResult ChangeStatus(int id, bool status)
        {
            var existProduct = list.FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return NotFound();
            existProduct.IsAvaliable = status;
            return Ok(existProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult ChangeStatus(int id)
        {
            var existProduct = list.FirstOrDefault(p => p.Id == id);
            if (existProduct is null) return NotFound();
            list.Remove(existProduct);
            return StatusCode(204);
        }
    }
}
