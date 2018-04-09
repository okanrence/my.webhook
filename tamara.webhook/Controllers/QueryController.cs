using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tamara.webhook.Models;
using Newtonsoft.Json;
//using tamara.webhook.Models.Request;
//using tamara.webhook.Models.Response;
//using tamara.webhook.Models.Request;
//using tamara.webhook.Models.Response;

namespace tamara.webhook.Controllers
{

    public class QueryController : ApiController
    {

        private const string invalidAction = "InvalidAction";
        // POST api/values
        public IHttpActionResult Post([FromBody]PayloadV2 payload)
        {
            string action = "";

     
            var body = JsonConvert.SerializeObject(payload);

            var cleaned = body.Replace('/', '.').Replace(',', '.').Replace('\\', '.').Replace('"', '.');
             cleaned = cleaned.Substring(0, 50);

            //logger.Info(body);


            //HttpContent requestContent = Request.Content;
            //var content = requestContent.ReadAsStringAsync().Result;

          
            //content = content.Substring(0, 50);


            //  logger.Info(Request.Content);

            try
            {
                action = payload?.queryResult?.action ?? invalidAction;

                if (string.IsNullOrEmpty(action))
                {
                    return Ok(WelcomeIntentErr("Error"));
                }
                if (action == invalidAction)
                {
                    return Ok(WelcomeIntentErr("Error"));
                }

            }
            catch (Exception ex)
            {
                return Ok(WelcomeIntentErr($"Error Occured ."));
            }

            return Ok(HandleIntents(action));
        }

        //private ResponseV1 HandleIntents(string action, PayloadV1 payload)
        //{
        //    switch (action)
        //    {
        //        case "Welcome":
        //            return WelcomeIntentV1(payload);
        //        default:
        //            return FallbackIntent(payload);
        //    }
        //}

        private ResponsePayload HandleIntents(string action)
        {
            switch (action)
            {
                case "Welcome":
                    return WelcomeIntent();
                default:
                    return FallbackIntent();
            }
        }
        //private ResponseV1 WelcomeIntentV1(PayloadV1 payload)
        //{
        //    var res = new ResponseV1()
        //    {
        //        messages = new List<Models.Response.Message>()
        //         {
        //           new Models.Response.Message()
        //           {
        //                speech = "I am Tamara from Webhook Api V1", type = 0
        //           } ,
        //            new Models.Response.Message()
        //           {
        //                speech = "How may i help you today", type = 0
        //           }
        //         }, source = "tamara-webhook"
        //    };

        //    return res;

        //}

        //private ResponseV1 WelcomeIntentErrV1(PayloadV1 payload, string msg)
        //{
        //    var res = new ResponseV1()
        //    {
        //        messages = new List<Models.Response.Message>()
        //         {
        //           new Models.Response.Message()
        //           {
        //                speech = $"I am Tamara, and i just encountered an error: {msg}", type = 0
        //           } ,
        //            new Models.Response.Message()
        //           {
        //                speech = "How may i help you today", type = 0
        //           }
        //         }
        //    };

        //    return res;

        //}
        private ResponsePayload WelcomeIntent()
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

            //var fulfillmentMessages = new List<Message>()
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

            //new  Message()
            //  {
            //      platform = Platforms.ACTIONS_ON_GOOGLE.ToString(),

            //     simpleResponses = new SimpleResponses()
            //       {
            //           simpleResponses = new List<SimpleResponse>()
            //            {
            //               new SimpleResponse()
            //               {
            //                   textToSpeech = "How can i help u today",
            //                   displayText = "How can i help u today"
            //               }
            //            }
            //       }
            //  }
            //  };

            //  payload.queryResult.fulfillmentMessages = fulfillmentMessages;

            var responseMsg = new ResponsePayload()
            {
                fulfillmentText = "Hello, I am Tamara from WebHook",
                fulfillmentMessages = new List<Message>()
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
                  },

                followupEventInput = new EventInput()
                {
                    
                        languageCode = "en",
                        name = "welcome"
                    
                },
                payload = new Payload()
                {

                },
                outputContexts = new List<Context>()
            {
                 new Context()
                 {
                     lifespanCount = 5,
                     name = "projects/tamara-499a3/agent/sessions/c06cec15-2bd9-40af-bd9b-265773b37aff/contexts/welcome-followup"
                 }

            },

                source = "tamara-webhook"
            };

            return responseMsg;

        }

        private ResponsePayload WelcomeIntentErr(string msg)
        {
            var responseMsg = new ResponsePayload()
            {
                fulfillmentText = $"Tamara from WebHook: {msg}",
                fulfillmentMessages = new List<Message>()
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
                                       textToSpeech = $"Hello, I am Tamara from WebHook {msg}",
                                       displayText = $"Hello, I am Tamara from WebHook {msg}"
                                   }
                                }
                           }
                      }
                  },

                followupEventInput = new EventInput()
                {

                    languageCode = "en",
                    name = "welcome"

                },

                outputContexts = new List<Context>()
            {
                 new Context()
                 {
                      lifespanCount = 5,
                     name = "projects/tamara-499a3/agent/sessions/c06cec15-2bd9-40af-bd9b-265773b37aff/contexts/welcome-followup"
                 }

            },

                source = "tamara-webhook"
            };

            return responseMsg;
        }

        //private ResponseV1 FallbackIntent(PayloadV1 payload)
        //{
        //    return new ResponseV1();
        //}

        private ResponsePayload FallbackIntent()
        {
            return new ResponsePayload();
        }
    }
}
