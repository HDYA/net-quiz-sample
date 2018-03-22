using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_quiz_sample.Models
{
    public class User
    {
        [Key]
        [JsonProperty(PropertyName = "identifier")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        public static ICollection<User> DefaultUsers = new List<User>
        {
            new User
            {
                Identifier = "sample-user",
                Username = "Sample User",
            }
        };
    }
}