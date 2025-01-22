using static System.Net.Mime.MediaTypeNames;
using System.Text.Json.Serialization;


namespace ApiGithub.Models
{
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }
    }

    public class Owner
    {
        [JsonPropertyName("login")]
        public string UserName { get; set; }

    }

}

