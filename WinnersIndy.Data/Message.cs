using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinnersIndy.Data
{
    public enum MessageCategory
    {
        SundayService=1,
        MidweekService,
        WeekOfSpiritualEmphasis
    }
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public MessageCategory MessageType { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
