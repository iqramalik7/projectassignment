using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using projectv2.Server.Controllers.Data;
using projectv2.Shared.Models;

namespace projectv2.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : Controller
    {
        private readonly DatabaseContext dataobj;
        public ContactController(DatabaseContext Dataobj)
        {
            dataobj = Dataobj;
        }

        [HttpPost]
        public async Task<IActionResult> PostData(Contact c)
        {
            if (ModelState.IsValid)
            {
                Contact mail = new Contact();
                mail.Name = c.Name;
                mail.Email = c.Email;
                mail.Message = c.Message;

                dataobj.contactus.Add(mail);
                dataobj.SaveChangesAsync();
                
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetData()
        {
            if (dataobj == null)
            {
                return new JsonResult(new { message = "Nothing to show" });
            }

            var students = await dataobj.contactus.ToListAsync();
            return new JsonResult(students);
        }
    }
}
