﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAppz.Data
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string TaskTitle { get; set; }
        public bool Completed { get; set; }

        [ForeignKey("CreateToDoListId")]
        public Guid CreateToDoListId { get; set; }

    }
}
