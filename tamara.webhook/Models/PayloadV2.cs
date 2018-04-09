using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tamara.webhook.Models
{
    public class PayloadV2
    {
        public string responseId { get; set; }
        public string session { get; set; }
        public Queryresult1 queryResult { get; set; }
        public Originaldetectintentrequest originalDetectIntentRequest { get; set; }
    }

    public class Queryresult1
    {
        public string queryText { get; set; }
        public string action { get; set; }
        public Parameters2 parameters { get; set; }
        public bool allRequiredParamsPresent { get; set; }
        public string fulfillmentText { get; set; }
        public Fulfillmentmessage[] fulfillmentMessages { get; set; }
        public Outputcontext[] outputContexts { get; set; }
        public Intent1 intent { get; set; }
        public int intentDetectionConfidence { get; set; }
        public Diagnosticinfo diagnosticInfo { get; set; }
        public string languageCode { get; set; }
    }

    public class Parameters1
    {
        public string param { get; set; }
    }

    public class Intent1
    {
        public string name { get; set; }
        public string displayName { get; set; }
    }

    public class Diagnosticinfo1
    {
    }

    public class Fulfillmentmessage
    {
        public Text1 text { get; set; }
    }

    public class Text1
    {
        public string[] text { get; set; }
    }

    public class Outputcontext
    {
        public string name { get; set; }
        public int lifespanCount { get; set; }
        public Parameters1 parameters { get; set; }
    }

    public class Parameters2
    {
        public string param { get; set; }
    }

    public class Originaldetectintentrequest
    {
    }


}