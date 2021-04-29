using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnersIndy.Data
{
    public class MemberAddress// One to One relationship Member class
    {
        [Key,ForeignKey(nameof(Member))]
        public int MemberAddressID { get; set; }
        public virtual Member Member { get; set; }
        
        public string StreetName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
       
        

    }
}



//This is a one to one relationship with memeber class. The MemberAddress ID is the both 
//the foreign key and the primary key for the Memberaddress Table. The memeberAddressID is
//is the primary key for the member Table , is just been called MemberAddressID in the Memberaddress
//Table for easy identification. The parent is table is Member and the child is MemberAddress. The child 
// cannot exist without the parent but the parent can exist without wthe child. The foreign key will 
//always be placed inside the child Table.

