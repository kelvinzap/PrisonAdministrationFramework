using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrisonAdministrationSystem.Dtos;
using PrisonAdministrationSystem.Models;

namespace PrisonAdministrationSystem.Controllers.Api
{
    [Authorize]
    public class StaffController : ApiController
    {
        public readonly ApplicationDbContext _context;
        
        public StaffController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Remove(string Id)
        {
            var staff = _context.Staffs.Single(p => p.Id == Id);

            if (staff == null)
                return BadRequest();

            if (staff.HasLeft)
                return NotFound();

            staff.Remove();
            
            _context.SaveChanges();
            return Ok();

        }
    }
}
