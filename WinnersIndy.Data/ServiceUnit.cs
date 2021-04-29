using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnersIndy.Data
{
    public class ServiceUnit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public virtual ICollection<Member> ListofMembers { get; set; }
        public virtual ICollection<ServiceUnitExecutive> ListofServiceUnitExecutives { get; set; }

        public ServiceUnit()
        {
            ListofServiceUnitExecutives = new HashSet<ServiceUnitExecutive>();
            ListofMembers = new HashSet<Member>();
        }
        



    }
}
