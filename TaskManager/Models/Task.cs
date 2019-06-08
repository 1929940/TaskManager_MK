using System;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime Deadline { get; set; }


        public Task(int id, string description, string priority, string status, DateTime deadline)
        {
            Id = id;
            Description = description;
            Priority = priority;
            Status = status;
            Deadline = deadline;
        }
    }
}
