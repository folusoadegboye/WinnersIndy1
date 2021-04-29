using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnersIndy.Data
{
    public class ServiceUnitExecutive
    {
        public int Id { get; set; }
        public string UnitHeadName { get; set; }
        public string UnitAssistanceName { get; set; }
        public string UnitSecretaryName { get; set; }
        public virtual ICollection<ServiceUnit> ListofServiceUnit{ get; set; }
        
        

    }
}
