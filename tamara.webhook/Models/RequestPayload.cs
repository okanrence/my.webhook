using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tamara.webhook.Models
{

    public class RequestPayload
    {
        public string session { get; set; }
        public string responseId { get; set; }
        public Queryresult queryResult { get; set; }
    }

    public class Queryresult
    {
        public string queryText { get; set; }
        public string languageCode { get; set; }
        public int speechRecognitionConfidence { get; set; }
        public string action { get; set; }
        public Parameters parameters { get; set; }
        public bool allRequiredParamsPresent { get; set; }
        public string fulfillmentText { get; set; }
        public ICollection<Message> fulfillmentMessages { get; set; }
        public string webhookSource { get; set; }
        public Webhookpayload webhookPayload { get; set; }
        public ICollection<Context> outputContexts { get; set; }
        public Intent intent { get; set; }
        public int intentDetectionConfidence { get; set; }
        public Diagnosticinfo diagnosticInfo { get; set; }
    }

    public class Parameters
    {
        public string name { get; set; }
    }

    public class Webhookpayload
    {
    }


    public class Diagnosticinfo
    {
    }

    public class Message
    {
        public string platform { get; set; }
        public SimpleResponses simpleResponses { get; set; }
    }

    public enum Platforms
    {
        PLATFORM_UNSPECIFIED,
        FACEBOOK,
        SLACK,
        TELEGRAM,
        KIK,
        SKYPE,
        LINE,
        VIBER,
        ACTIONS_ON_GOOGLE
    }

    public class Text
    {
        public string[] text { get; set; }
    }
    public class Context
    {
        public string name { get; set; }
        public int lifespanCount { get; set; }
        public Parameters parameters { get; set; }
    }


    public class SimpleResponses
    {
        public ICollection<SimpleResponse> simpleResponses { get; set; }
    }

    public class SimpleResponse
    {
        public string textToSpeech { get; set; }
       // public string ssml { get; set; }
        public string displayText { get; set; }
    }

    public class Intent
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public int priority { get; set; }
        public bool isFallback { get; set; }
        public bool mlEnabled { get; set; }
        public string[] inputContextNames { get; set; }
        public string[] events { get; set; }
        public string action { get; set; }
        public ICollection<Context> outputContexts { get; set; }
        public bool resetContexts { get; set; }
        public IntentParameters[] parameters { get; set; }
        public Message[] messages { get; set; }
        public object[] defaultResponsePlatforms { get; set; }
        public string rootFollowupIntentName { get; set; }
        public string parentFollowupIntentName { get; set; }
        public ICollection<Followupintentinfo> followupIntentInfo { get; set; }
    }

    public class Followupintentinfo
    {
        public string followupIntentName { get; set; }
        public string parentFollowupIntentName { get; set; }
    }

    public class IntentParameters
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public string value { get; set; }
        public string defaultValue { get; set; }
        public string entityTypeDisplayName { get; set; }
        public bool mandatory { get; set; }
        public string[] prompts { get; set; }
        public bool isList { get; set; }
    }
}