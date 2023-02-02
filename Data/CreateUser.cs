using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorAppz.Data
{
    public class CreateUser
    {

        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("firstName")]
        [Required]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        [Required]
        public string LastName { get; set; }


        [JsonPropertyName("userName")]
        [MinLength(6, ErrorMessage = "Must be atleast 6 characters.")]
        [Required]
        public string UserName { get; set; }


        [JsonPropertyName("email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }



        [JsonPropertyName("password")]
        [MinLength(6, ErrorMessage = "Must be atleast 6 characters.")]
        [Required]
        public string Password { get; set; }



        [JsonPropertyName("access")]
        public Access Access { get; set; }
        [JsonPropertyName("toDoList")]
        public List<CreateToDoList> ToDoList { get; set; }


    }
}
