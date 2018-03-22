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
                Content = "How many regions Microsoft Azure has GAed across the globe",
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
                Content = "Where is the headquarter of Microsoft",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"Cupertino\", \"Mountain View\", \"Redmond\", \"Seattle\" ]",
                Answer = 2
            },
            new Problem
            {
                Id = 4,
                Content = "When is Opensource Cloud Foundry GAed on Microsoft Azure",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"2015.11\", \"2016.6\", \"2017.1\", \"2017.8\" ]",
                Answer = 0
            },
            new Problem
            {
                Id = 5,
                Content = "Microsoft has the mission of",
                Category = "Technology",
                Difficulty = 0,
                Options = "[ \"Connect the world’s professionals to make them more productive and successful\", \"Be the fabric of real-time communication on the web\", \"Empower every person and every organization on the planet to achieve more\", \"Make it fast, easy and fun to build great mobile apps\" ]",
                Answer = 2
            }
        };
    }
}