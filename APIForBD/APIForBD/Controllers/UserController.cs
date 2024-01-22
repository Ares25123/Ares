using APIForBD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIForBD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public praktikaContext Context { get; }

        public UserController(praktikaContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll() // Получение всех записей
        {
            List<User> user = Context.Users.ToList();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) // Получение одной записи
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(User user) // Создание одной записи
        {
            Context.Users.Add(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(User user) // Изменение существующей записи
        {
            Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) // Удаление существующей записи
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}
