using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnersIndy.Model
{
    public class AddressListItem
    {
        public int MemberAddressId { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
