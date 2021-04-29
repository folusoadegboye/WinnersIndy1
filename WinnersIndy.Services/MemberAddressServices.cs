using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinnersIndy.API.Models;
using WinnersIndy.Data;
using WinnersIndy.Model;

namespace WinnersIndy.Services
{
    public class MemberAddressServices
    {
        private readonly Guid _useriD;

        public MemberAddressServices(Guid userid)
        {
            _useriD = userid;
        }

        public bool CreateMemberAddress(MemberAddressCreate model,int customerid)
        {
            var entity = new MemberAddress()
            {
                StreetName = model.StreetName,
                City = model.City,
                State = model.State,
                Zipcode = model.Zipcode,
                MemberAddressID=customerid

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MemberAddresses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AddressListItem> GetAllAddress()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                  .MemberAddresses
                                  .Where(e => e.Member.OwnerId == _useriD)
                                  .Select(e => new AddressListItem
                                  {
                                      FirstName = e.Member.FirstName,
                                      LastName = e.Member.LastName,
                                      StreetName = e.StreetName,
                                      City = e.City,
                                      Zipcode = e.Zipcode,
                                      MemberAddressId = e.MemberAddressID
                                  });
                return query.ToArray();

            }

        }
        public MemberaddressDetail GetMemberAddressById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .MemberAddresses
                                .SingleOrDefault(e => e.Member.OwnerId == _useriD && e.MemberAddressID == id);

                if (query is null)
                    return null;
                var memberaddressdetail = new MemberaddressDetail
                {
                    FirstName = query.Member.FirstName,
                    LastName = query.Member.LastName,
                    StreetName = query.StreetName,
                    City = query.City,
                    Zipcode = query.Zipcode,
                    State = query.State,
                    Id = query.MemberAddressID

                };
                return memberaddressdetail;
                

            }   
        }
        public bool UpdateMemberAddresss(MemberAddressEdit model, int id)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var query = ctx
                                .MemberAddresses
                                .SingleOrDefault(e => e.MemberAddressID == id && e.Member.OwnerId == _useriD);
                if (query is null)
                {
                    return false;
                }
                {
                    query.StreetName = model.StreetName;
                    query.City = model.City;
                    query.State = model.State;
                    query.Zipcode = model.Zipcode;
                    
                }
                return ctx.SaveChanges() == 1;


            }
        }
        public bool DeleteMemberAddress(int id)
        {
            using (var ctx =new ApplicationDbContext())
            {
                var query = ctx.MemberAddresses.SingleOrDefault(e => e.Member.OwnerId == _useriD && e.MemberAddressID == id);
                if (query is null)
                    return false;
                ctx.MemberAddresses.Remove(query);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
