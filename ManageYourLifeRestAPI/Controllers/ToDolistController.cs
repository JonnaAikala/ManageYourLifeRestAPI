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
    }
}
