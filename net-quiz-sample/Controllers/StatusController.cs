using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace net_quiz_sample.Controllers
{
    public class StatusController : ApiController
    {
        public class Status
        {
            [JsonProperty(PropertyName = "databaseConnected")]
            public Boolean DatabaseConnected { get; set; }

            [JsonProperty(PropertyName = "connectionString")]
            public String ConnectionString { get; set; }
        }

        // GET api/status
        public Status Get()
        {
            return new Status {
                DatabaseConnected = ConfigurationManager.AppSettings["UseEnvironmentDatabase"].Equals("true"),
                ConnectionString = ConfigurationManager.ConnectionStrings["QuizDbContext"].ConnectionString
            };
        }
    }
}
