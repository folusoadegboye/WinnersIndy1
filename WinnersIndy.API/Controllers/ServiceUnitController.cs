using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinnersIndy.Model.Service_Unit_Model;
using WinnersIndy.Services;

namespace WinnersIndy.API.Controllers
{
    public class ServiceUnitController : ApiController
    {
        private ServiceUnitServices CreateServiceUnitService()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var sserviceunit = new ServiceUnitServices(userid);
            return sserviceunit;
        }

        public IHttpActionResult Post(ServiceUnitCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model is null)
            {
                return BadRequest("you cannot have an empty model");
            }
            var sserviceunit = CreateServiceUnitService();
            if (!sserviceunit.CreateServiveUnit(model))
            {
                return BadRequest("Model could not be addeded");
            }
            return Ok(" Unit succesfully created");

            
        }
    }
}
