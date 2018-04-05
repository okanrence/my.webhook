using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tamara.webhook.Models.Request
{
    public class PayloadV1
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public string lang { get; set; }
        public Result result { get; set; }
        public Status status { get; set; }
        public string sessionId { get; set; }
    }

    public class Result
    {
        public string source { get; set; }
        public string resolvedQuery { get; set; }
        public string action { get; set; }
        public bool actionIncomplete { get; set; }
        public Parameters parameters { get; set; }
        public Context[] contexts { get; set; }
        public Metadata metadata { get; set; }
        public Fulfillment fulfillment { get; set; }
        public int score { get; set; }
    }

    public class Parameters
    {
        public string accountNumber { get; set; }
    }

    public class Metadata
    {
        public string intentId { get; set; }
        public string webhookUsed { get; set; }
        public string webhookForSlotFillingUsed { get; set; }
        public string intentName { get; set; }
    }

    public class Fulfillment
    {
        public string speech { get; set; }
        public Message[] messages { get; set; }
    }

    public class Message
    {
        public object type { get; set; }
        public string platform { get; set; }
        public string textToSpeech { get; set; }
        public string speech { get; set; }
    }

    public class Context
    {
        public string name { get; set; }
        public Parameters parameters { get; set; }
        public int lifespan { get; set; }
    }

   
    public class Status
    {
        public int code { get; set; }
        public string errorType { get; set; }
        public bool webhookTimedOut { get; set; }
    }

}
