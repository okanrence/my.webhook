using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tamara.core.Model;
using tamara.webhook.core.services;

namespace tamara.middleware.Controllers
{
    public class ConversationsController : ApiController
    {
        private readonly IUserProfileServices _userProfileServices;


        public ConversationsController()
        {
            _userProfileServices =  new UserProfileServices();
        }
        // GET api/values
        [Route("api/v1/conversations")]
        public IHttpActionResult Get(string query, string sessionId)
        {
            try
            {
                IEnumerable<string> deviceIdHeaders = Request.Headers.GetValues("deviceId");
                var deviceId = deviceIdHeaders.FirstOrDefault();

                IEnumerable<string> actionHeaders = Request.Headers.GetValues("action");
                var action = actionHeaders.FirstOrDefault();


                //Use deviceId to check if user already exists
                IRestResponse response = RouteMessage(query, sessionId, deviceId, action);

                if (response.StatusCode == HttpStatusCode.OK)
                    return Ok(JsonConvert.DeserializeObject<Payload>(response.Content));

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }

        }

        private IRestResponse RouteMessage(string query, string sessionId, string deviceId, string action)
        {
            RestRequest request;
            RestClient client;
            string baseUrl;

            var userProfile = _userProfileServices.GetByDeviceId(deviceId);
            var useBackend = (userProfile != null && action == "welcome");

            if (!useBackend)
            {
                baseUrl = ConfigurationManager.AppSettings["conversations_platform_base_url"];
                client = new RestClient(baseUrl);
                request = new RestRequest("v1/query", Method.GET);
                request.AddParameter("v", "20170712");
                request.AddParameter("query", query);
                request.AddParameter("lang", "en");
                request.AddParameter("sessionId", sessionId);
                request.AddParameter("timezone", "Africa/Lagos");
                request.AddHeader("Authorization", "Bearer 28bed29f5b62412bbac420c11946cb0e");

            }
            else
            {
                baseUrl = ConfigurationManager.AppSettings["conversations_platform_base_url"];
                client = new RestClient(baseUrl);
                request = new RestRequest("v1/query", Method.POST);

                var payload = new Payload()
                {
                    lang = "en",
                    sessionId = sessionId,
                    result = new Result()
                    {
                        action = action,
                        parameters = new Parameters()
                        {
                            deviceId = deviceId
                        }

                    }
                };

                request.AddJsonBody(payload);
            }

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            if (bool.Parse(ConfigurationManager.AppSettings["use_proxy"]))
            {
                client.Proxy = new WebProxy(ConfigurationManager.AppSettings["proxy_url"]);
                client.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }

            IRestResponse response = client.Execute(request);

            // var responseBody = JsonConvert.DeserializeObject<Payload>(response.Content);
            return response;
        }
    }
}
