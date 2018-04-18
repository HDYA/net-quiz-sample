using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_quiz_sample.Models
{
    public class Problem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public byte Difficulty { get; set; }

        [JsonProperty(PropertyName = "options")]
        public string Options { get; set; }

        [JsonProperty(PropertyName = "answer")]
        public byte Answer { get; set; }

        public static ICollection<Problem> DefaultProblems = new List<Problem> {
            new Problem
            {
                Id = 1,
                Content = "How many regions does Microsoft Azure currently have around the world",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"32\", \"36\", \"40\", \"44\" ]",
                Answer = 1
            },
            new Problem
            {
                Id = 2,
                Content = "Which one is the best programming language as a standing joke",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"C#\", \"Java\", \"Javascript\", \"PHP\" ]",
                Answer = 3
            },
            new Problem
            {
                Id = 3,
                Content = "Which one is NOT a Recursive Acronym",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"TINT\", \"GNU\", \"PCF\", \"YAML\" ]",
                Answer = 2
            },
            new Problem
            {
                Id = 4,
                Content = "When is Open Source Cloud Foundry available on Microsoft Azure",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"2015.11\", \"2016.6\", \"2017.1\", \"2017.8\" ]",
                Answer = 0
            },
            new Problem
            {
                Id = 5,
                Content = "ASP.NET applications can run on Cloud Foundry with",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"Windows Stack\", \"HWC Buildpack\", \"cf push\", \"All of the above\" ]",
                Answer = 3
            },
            new Problem
            {
                Id = 6,
                Content = "What are supported when you run .NET core apps on Cloud Foundry",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \".Net Core Buildpacks\", \"Steeltoe\", \"Service Broker\", \"All of above\" ]",
                Answer = 3
            },
            new Problem
            {
                Id = 7,
                Content = "When did Microsoft join the Cloud Foundry Foundation",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"June, 2017\", \"Nov, 2017\", \"June 2016\", \"Nov.2016\" ]",
                Answer = 0
            },
            new Problem
            {
                Id = 8,
                Content = "What are supported when you run .NET  Framework apps on Cloud Foundry",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"SSH into running containers\", \"Steeltoe\", \"Service Broker\", \"All of above\" ]",
                Answer = 3
            },
            new Problem
            {
                Id = 9,
                Content = "Which organization on GitHub hosts projects used by this Cloud Foundry environments",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"cloudfoundry\", \"cloudfoundry-community\", \"cloudfoundry-incubator\", \"All of above\" ]",
                Answer = 3
            },
            new Problem
            {
                Id = 10,
                Content = "Which VM is optional in a Small Footprint PAS",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"Compute\", \"Control\", \"HAProxy\", \"Database\" ]",
                Answer = 2
            },
        };
    }
}