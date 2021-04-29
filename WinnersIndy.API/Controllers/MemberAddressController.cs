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
    public class MemberAddressController : ApiController
    {
        private MemberAddressServices CreateMemberAddressServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var Mservices = new MemberAddressServices(userid);
            return Mservices;

        }
        public IHttpActionResult Post(MemberAddressCreate model,int CustomerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            if (model is null)
            {
                return BadRequest("you cannot have a null model");

            }
            var services = CreateMemberAddressServices();
            if (!services.CreateMemberAddress(model,CustomerId))
            {
                return InternalServerError();
            }
            return Ok("addrress addeded");

        }
        public IHttpActionResult GetAllAddress()
        {
            var services = CreateMemberAddressServices();
            var AddressList = services.GetAllAddress();
            return Ok(AddressList);
        }
        public IHttpActionResult GetMemberAddressByID(int id)
        {
            var services = CreateMemberAddressServices();
            var memberaddress=services.GetMemberAddressById(id);
            if(memberaddress is null)
            {
                return NotFound();
            }
            return Ok(memberaddress);
        }
        public IHttpActionResult Put(MemberAddressEdit model,int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model?.Id!= id)
            {
                return BadRequest("Id do not match");
            }
            var services = CreateMemberAddressServices();
            var newaadress = services.UpdateMemberAddresss(model, id);
            if(newaadress is false)
            {
                return BadRequest("Update Failed");
            }
            return Ok("update succesfull");

        }
        public IHttpActionResult DeleteMemberAddress(int id)
        {
            var services = CreateMemberAddressServices();
            var isdeleted = services.DeleteMemberAddress(id);
            if (isdeleted)
            {
                return Ok("Address removed successfully");
            }
            return InternalServerError();
        }
    }
}
