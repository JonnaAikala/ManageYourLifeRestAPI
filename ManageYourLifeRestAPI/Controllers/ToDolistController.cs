using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ManageYourLifeRestAPI.Models;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace ManageYourLifeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDolistController : ControllerBase
    {
        //Alustettiin tietokantayhteys
        ManageYourLifeReactDbContext db = new ManageYourLifeReactDbContext();

        //Hakee kaikki asiakkaat
        [HttpGet]
        public ActionResult GetAllTasks()
        {
            var tehtävät = db.ToDolists.ToList();
            return Ok(tehtävät);

        }

        //Hakee tekemättömät tehtävät
        [HttpGet]
        [Route("{completed}")]
        public ActionResult GetAllTasksByCompleted(string completed)
        {
            try
            {
                var tasks = db.ToDolists
                              .Where(t => t.Completed.ToLower() == completed.ToLower())
                              .ToList();

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest("Tapahtui virhe. Lue lisää: " + ex);  
            }
        }

        //Lisää uuden tehtävän
        [HttpPost]

        public ActionResult AddNew([FromBody]ToDolist task)
        {
            try
            {
                db.ToDolists.Add(task);
                db.SaveChanges();
                return Ok($"Lisättiin uusi tehtävä {task.Task} ,joka tulee tehdä {task.Date} mennessä.");
            }
            catch(Exception ex) {

              return BadRequest("Virhe: " + ex.Message +
                      (ex.InnerException != null ? " | " + ex.InnerException.Message : ""));
            }


        }
    }
}
