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
    public class MemberServices
    {
        private readonly Guid _userId;

        public MemberServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMember(MemberCreate model)
        {
            var entity = new Member()
            {
                OwnerId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
                DateOfBirth = model.DateOfBirth
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Members.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<MemberListItem> GetAllMember()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Members
                                    .Select(e => new MemberListItem
                                    {
                                        FirstName = e.FirstName,
                                        Lastname = e.LastName,
                                        PhoneNumber = e.PhoneNumber,
                                        //Null Coalescing, if memberaddress.streetname is null then do "No Address" if not put the address
                                        streetName = e.MemberAddress.StreetName ?? "No Address",
                                        Zipcode = e.MemberAddress.Zipcode == null ? "No Zip-code" : e.MemberAddress.Zipcode,
                                        MemberID = e.Id
                                    });
                return query.ToArray();
            }
        }
        public MemberDetails GetMemberByMemberID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Members
                                .SingleOrDefault(e => e.Id == id && e.OwnerId == _userId);
                if (query is null)
                    return null;

                var Member = new MemberDetails
                {
                    FirstName = query.FirstName,
                    LastName = query.LastName,
                    DateOfBirth = query.DateOfBirth,
                    EmailAddress = query.EmailAddress,
                    StreetName = query.MemberAddress == null ? "No Address" : query.MemberAddress.StreetName,
                    ZipCode = query.MemberAddress == null ? "No Zip-Code" : query.MemberAddress.Zipcode,
                    PhoneNumber = query.PhoneNumber,
                    Id = query.Id
                };
                return Member;
            }

        }
        public bool UpdateMember(MemberEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Members
                                            .SingleOrDefault(e => e.OwnerId == _userId && e.Id == id);
                if (query is null)
                {
                    return false;
                }
                {
                    query.FirstName = model.FirstName;
                    query.LastName = model.LastName;
                    query.PhoneNumber = model.PhoneNumber;
                    query.EmailAddress = model.EmailAddress;

                    return ctx.SaveChanges() == 1;
                }
            }
        }
        public bool DeleteMember(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                    .Members
                                    .SingleOrDefault(e => e.Id == id && e.OwnerId == _userId);

                ctx.Members.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool MemberJoinServiceUnit(int memberid, int serviceUnitid)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var member = ctx.Members.SingleOrDefault(m => m.Id == memberid);
                //return member == null ? null : member;
                var serviceunit = ctx.ServiceUnits.Single(s => s.Id == serviceUnitid);
                member.ListofServiceUnit.Add(serviceunit);
                return ctx.SaveChanges() == 1;



            }
        }
    }
}
