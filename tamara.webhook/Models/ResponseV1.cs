using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tamara.webhook.Models.Response
{
    public class ResponseV1
    {
        public string speech { get; set; }
        public ICollection<Message> messages { get; set; }
        public string source { get; set; }
    }

    public class Message
    {
        public int type { get; set; }
        public string speech { get; set; }
    }

 
}