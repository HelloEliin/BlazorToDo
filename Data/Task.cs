using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BlazorAppz.Data
{
    public class Task
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("taskTitle")]
        [Required]
        public string TaskTitle { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }

        [JsonPropertyName("createToDoListId")]
        public Guid CreateToDoListId { get; set; }

    }
}
