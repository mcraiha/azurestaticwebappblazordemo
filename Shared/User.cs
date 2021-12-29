using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Shared
{
    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("roles")]
        public string[] Roles { get; set; }
    }
}