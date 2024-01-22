using APIForBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIForBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public praktikaContext Context { get; }

        public ProductController(praktikaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Product> product = Context.Products.ToList();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Product? product = Context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product product) // Создание одной записи
        {
            Context.Products.Add(product);
            Context.SaveChanges();
            return Ok(product);
        }

        [HttpPut]
        public IActionResult Update(Product product) // Изменение существующей записи
        {
            Context.Products.Update(product);
            Context.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Product? product = Context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return BadRequest("Not Found");
            }
            Context.Products.Remove(product);
            Context.SaveChanges();
            return Ok(product);
        }
    }
}
