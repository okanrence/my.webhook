using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tamara.webhook.Models
{


    public class ResponsePayload
    {
        public string fulfillmentText { get; set; }
        public ICollection<Message> fulfillmentMessages { get; set; }
        public string source { get; set; }
        public Payload payload { get; set; }
        public ICollection<Context> outputContexts { get; set; }
        public Followupeventinput followupEventInput { get; set; }
    }

    public class Payload
    {
    }

    public class Followupeventinput
    {
        public EventInput EventInput { get; set; }
    }


    public class EventInput
    {
        public string name { get; set; }
        public Parameters parameters { get; set; }
        public string languageCode { get; set; }
    }

}