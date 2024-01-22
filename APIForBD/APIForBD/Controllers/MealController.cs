using APIForBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIForBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        public praktikaContext Context { get; }

        public MealController(praktikaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<Meal> meal = Context.Meals.ToList();
            return Ok(meal);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            Meal? meal = Context.Meals.Where(x => x.MealId == id).FirstOrDefault();
            if (meal == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(meal);
        }

        [HttpPost]
        public IActionResult Add(Meal meal) // Создание одной записи
        {
            Context.Meals.Add(meal);
            Context.SaveChanges();
            return Ok(meal);
        }

        [HttpPut]
        public IActionResult Update(Meal meal) // Изменение существующей записи
        {
            Context.Meals.Update(meal);
            Context.SaveChanges();
            return Ok(meal);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            Meal? meal = Context.Meals.Where(x => x.MealId == id).FirstOrDefault();
            if (meal == null)
            {
                return BadRequest("Not Found");
            }
            Context.Meals.Remove(meal);
            Context.SaveChanges();
            return Ok(meal);
        }
    }
}
