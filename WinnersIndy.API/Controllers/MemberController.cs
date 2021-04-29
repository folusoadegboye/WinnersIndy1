using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinnersIndy.Model;
using WinnersIndy.Services;

namespace WinnersIndy.API.Controllers
{ 
    [Authorize]
    public class MemberController : ApiController
    {
        private MemberServices CreateMemberServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var Mservices = new MemberServices(userid);
            return Mservices;
        }
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult CreateMember(MemberCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(model is null)
            {
                return BadRequest("You cannot have an empty model");
            }
            MemberServices services = CreateMemberServices();
            
            if (!services.CreateMember(model))
            {
                return InternalServerError();
            }
            return Ok("Member created successfully");

        }
        public IHttpActionResult GetAllMember()
        {
            var memberserice = CreateMemberServices();
            var Members = memberserice.GetAllMember();
            return Ok(Members);

        }
        
        public IHttpActionResult GetMemberById(int Id)
        {
            var memberservice = CreateMemberServices();
            var memberdetail = memberservice.GetMemberByMemberID(Id);
            return Ok(memberdetail);
        }
        [HttpPut]
        public IHttpActionResult UpdateMember(MemberEdit model, int id)
        {
            var memberservice = CreateMemberServices();
            var update = memberservice.UpdateMember(model, id);
            if(update is false)
            {
                return InternalServerError();
            }
            return Ok("Member suscessfully updated");

        }
        public IHttpActionResult DeleteMember(int id)
        {
            var memberservice = CreateMemberServices();
            var isdeleted = memberservice.DeleteMember(id);
            if (isdeleted)
            {
                return Ok("Member succesfully deleted");
            }
            return InternalServerError();
        }
    }
}
