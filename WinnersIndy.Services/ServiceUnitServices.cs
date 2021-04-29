using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinnersIndy.API.Models;
using WinnersIndy.Data;
using WinnersIndy.Model;
using WinnersIndy.Model.Service_Unit_Model;

namespace WinnersIndy.Services
{
    public class ServiceUnitServices
    {
        private readonly Guid _Userid;

        public ServiceUnitServices(Guid userid)
        {
            _Userid = userid;
        }
        public bool CreateServiveUnit(ServiceUnitCreate model)
        {
            using (var ctx =new ApplicationDbContext())
            {
                var entity = new ServiceUnit();
                entity.Name = model.Name;
                entity.OwnerId = _Userid;

                ctx.ServiceUnits.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<ServiceUnitList> GetAllServiceUnit()
        {
            using(var ctx= new ApplicationDbContext())
            {
                var query = ctx
                                .ServiceUnits
                                .Select(s => new ServiceUnitList()
                                {
                                    Id = s.Id,
                                    Name=s.Name
                                }).ToArray();
                return query;
                                
            }
        }

        public bool AddMemberToServiceUnit(int memberid, int serviceUnitid)
        {

            using(var ctx=new ApplicationDbContext())
            {
                var member = ctx.Members.SingleOrDefault(m => m.Id == memberid);
                //return member == null ? null : member;
                var serviceunit = ctx.ServiceUnits.Single(s => s.Id == serviceUnitid);
                serviceunit.ListofMembers.Add(member);
                return ctx.SaveChanges() == 1;

                

            }
        }
        //public ServiceUnitDetail GetServiceUnitByID(int id)
        //{
        //    using (var ctx =new ApplicationDbContext())
        //    {
        //        var serviceunit = ctx
        //                            .ServiceUnits
        //                            .SingleOrDefault(s => s.Id == id);
        //        if (serviceunit is null)
        //            return null;
        //        var serviceunitdetail = new ServiceUnitDetail
        //        {
        //            Name = serviceunit.Name,
        //            Id=serviceunit.Id,
                    

        //        };

                
                                   
        //        if(serviceunit==null)?return null :return serviceunit;
        //        return serviceunit == null ? null : serviceunit;
        //    }
        //}
        public bool UpdateSeviceUnit(int id, ServiceUnitEdit model)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var serviceunit = ctx
                                    .ServiceUnits
                                    .SingleOrDefault(s=>s.OwnerId==_Userid&&s.Id==id);
                if (serviceunit is null)
                {
                    return false;
                }
                serviceunit.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteServiceUnit(int id)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var student = ctx
                                  .ServiceUnits
                                  .SingleOrDefault(s=>s.Id==id && s.OwnerId==_Userid);
                if(student is null)
                {
                    return false;
                }
                 ctx.ServiceUnits.Remove(student);
                return ctx.SaveChanges() == 1;
                
                
            }
        }

    }
}
