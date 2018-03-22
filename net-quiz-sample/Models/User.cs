using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_quiz_sample.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Key]
        [JsonProperty(PropertyName = "uid")]
        public string Identifier { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
    }
}