using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnersIndy.Data
{
    public   class Member
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Field can't be empty")]
        [DataType(DataType.EmailAddress,ErrorMessage ="E-Mail is not valid")]
        public string EmailAddress { get; set; }
        public virtual  MemberAddress MemberAddress { get; set; }
        [Required]
        [DataType(DataType.Date,ErrorMessage ="Invalid date")]
        public DateTime DateOfBirth { get; set; }
        public Guid OwnerId { get; set; }//admin
        public virtual ICollection<ServiceUnit> ListofServiceUnit { get; set; } 

        public Member()
        {
            ListofServiceUnit = new HashSet<ServiceUnit>();
        }

        
    }
}
//The member Table is in a one to one relatonship with Member address and  many to manay relationship with 
//Service Unit. Creating an Icollection  and using the vitual property for Service unit  and  doing the 
//the same on service unit Table creating an icollection for member  will create an imaginary Join 
//Table for the class which solves the Many  relationship.