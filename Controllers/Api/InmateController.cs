using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrisonAdministrationSystem.Models;

namespace PrisonAdministrationSystem.Controllers.Api
{
    [Authorize]
    public class InmateController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public InmateController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Remove(string Id)
        {
            var inmate = _context.Inmates
                .Single(p => p.Id == Id);

            if (inmate == null)
                return BadRequest();

            inmate.Remove();
            _context.SaveChanges();

            return Ok();
        }
    }
}
