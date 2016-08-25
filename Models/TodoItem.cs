using System;
using System.ComponentModel.DataAnnotations;

namespace demo_web_api.Models
{
    public class TodoItem
    {
        [Key]
        public int TodoId { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public bool isDone { get; set; }
    }
}