using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tamara.webhook.Models;
//using tamara.webhook.Models.Request;
//using tamara.webhook.Models.Response;

namespace tamara.webhook.Controllers
{

    public class QueryController : ApiController
    {

        private const string invalidAction = "InvalidAction";
        // POST api/values
        public IHttpActionResult Post([FromBody]RequestPayload payload)
        {
            var action = payload?.queryResult.action ?? invalidAction;

            if (action == invalidAction)
            {
                return BadRequest(invalidAction);
            }

            return Ok(HandleIntents(action, payload));
        }

        private RequestPayload HandleIntents(string action, RequestPayload payload)
        {
            switch (action)
            {
                case "Welcome":
                    return WelcomeIntent(payload);
                default:
                    return FallbackIntent(payload);
            }
        }

        private RequestPayload WelcomeIntent(RequestPayload payload)
        {
            //var responseMsg = new ResponseMsg()
            //{
            //    messages = new List<Models.Response.Message>()
            //     {
            //          new Models.Response.Message { speech = "Hello, I am Tamara from WebHook", type = 0 },
            //          new Models.Response.Message { speech = "What can i do you for?", type = 0 }
            //     },
            //    speech = "Hello, I am Tamara from WebHook",
            //    source = "tamara-webhook"
            //};

            var fulfillmentMessages = new List<Message>()
                  {
                      new  Message()
                      {
                          platform = Platforms.ACTIONS_ON_GOOGLE.ToString(),

                         simpleResponses = new SimpleResponses()
                           {
                               simpleResponses = new List<SimpleResponse>()
                                {
                                   new SimpleResponse()
                                   {
                                       textToSpeech = "Hello, I am Tamara from WebHook",
                                       displayText = "Hello, I am Tamara from WebHook"
                                   }
                                }
                           }
                      },

                    new  Message()
                      {
                          platform = Platforms.ACTIONS_ON_GOOGLE.ToString(),

                         simpleResponses = new SimpleResponses()
                           {
                               simpleResponses = new List<SimpleResponse>()
                                {
                                   new SimpleResponse()
                                   {
                                       textToSpeech = "How can i help u today",
                                       displayText = "How can i help u today"
                                   }
                                }
                           }
                      }
                  };

            payload.queryResult.fulfillmentMessages = fulfillmentMessages;

            //var responseMsg = new ResponsePayload()
            //{
            //    fulfillmentText = "Hello, I am Tamara from WebHook",
            //    fulfillmentMessages = new List<Message>()
            //      {
            //          new  Message()
            //          {
            //              platform = Platforms.ACTIONS_ON_GOOGLE.ToString(),

            //             simpleResponses = new SimpleResponses()
            //               {
            //                   simpleResponses = new List<SimpleResponse>()
            //                    {
            //                       new SimpleResponse()
            //                       {
            //                           textToSpeech = "Hello, I am Tamara from WebHook",
            //                           displayText = "Hello, I am Tamara from WebHook"
            //                       }
            //                    }
            //               }
            //          },

            //            new  Message()
            //          {
            //              platform = Platforms.ACTIONS_ON_GOOGLE.ToString(),

            //             simpleResponses = new SimpleResponses()
            //               {
            //                   simpleResponses = new List<SimpleResponse>()
            //                    {
            //                       new SimpleResponse()
            //                       {
            //                           textToSpeech = "How can i help u today",
            //                           displayText = "How can i help u today"
            //                       }
            //                    }
            //               }
            //          }
            //      },

            //    followupEventInput = new Followupeventinput()
            //    {
            //        EventInput = new EventInput()
            //    },

            //    outputContexts = new List<Context>()
            //    {
            //         new Context()

            //    },

            //    source = "tamara-webhook"
            //};

            return payload;
        }

        private RequestPayload FallbackIntent(RequestPayload payload)
        {

            return payload;
        }
    }
}
