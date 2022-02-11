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
    public class InmateController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public InmateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpDelete]
        public IHttpActionResult Remove(string Id)
        {
            var inmate = _unitOfWork.inmates.GetInmate(Id);

            if (inmate == null)
                return BadRequest();

            inmate.Remove();
            
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
