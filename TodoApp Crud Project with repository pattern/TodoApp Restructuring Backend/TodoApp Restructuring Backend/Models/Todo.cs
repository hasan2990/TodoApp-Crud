using System.ComponentModel.DataAnnotations;

namespace TodoApp_Restructuring_Backend.Models
{
    public class Todo
    {
        public int? id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string description { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime? due_date { get; set; }
        public Boolean? iscompleted { get; set; }
    }
}
