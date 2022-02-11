using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PrisonAdministrationSystem.Core;
using PrisonAdministrationSystem.Persistence;

namespace PrisonAdministrationSystem.Controllers.Api
{
    [Authorize]
    public class StaffController : ApiController
    {
        public readonly IUnitOfWork _unitOfWork;

        public StaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpDelete]
        public IHttpActionResult Remove(string Id)
        {
            var staff = _unitOfWork.staffs.GetStaff(Id);

            if (staff == null)
                return BadRequest();

            if (staff.HasLeft)
                return NotFound();

            staff.Remove();
            
           _unitOfWork.Complete();
            return Ok();

        }
    }
}
