using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnersIndy.Data

{
    public class Chat
    {
        public int ChatId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? dateTimeOffset { get; set; }
        [ForeignKey(nameof(Member))]
        public int MemberID { get; set; }
        public virtual Member Member { get; set; }



    }
}
