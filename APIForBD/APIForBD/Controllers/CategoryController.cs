using APIForBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIForBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public praktikaContext Context { get; }

        public CategoryController(praktikaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Category> category = Context.Categories.ToList();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Category? category = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (category == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add(Category category) // Создание одной записи
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
            return Ok(category);
        }

        [HttpPut]
        public IActionResult Update(Category category) // Изменение существующей записи
        {
            Context.Categories.Update(category);
            Context.SaveChanges();
            return Ok(category);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Category? category = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (category == null)
            {
                return BadRequest("Not Found");
            }
            Context.Categories.Remove(category);
            Context.SaveChanges();
            return Ok(category);
        }
    }
}
