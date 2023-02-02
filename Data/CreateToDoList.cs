using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAppz.Data
{
    public class CreateToDoList
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [ForeignKey("CreateUserId")]
        [JsonPropertyName("createUserId")]
        public Guid CreateUserId { get; set; }



        [JsonPropertyName("listTitle")]
        [Required]
        public string ListTitle { get; set; }
        [JsonPropertyName("task")]
        public ICollection<Task> Task { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("thisWeek")]
        public bool ThisWeek { get; set; }
        [JsonPropertyName("expired")]
        public bool Expired { get; set; }

        public CreateToDoList()
        {
            Task = new List<Task>();
        }


    }
}
