using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Priorities Priority { get; set; }
        public Statuses Status { get; set; }
        public DateTime Deadline { get; set; }


        public Task(int id, string description, Priorities priority, Statuses status)
        {
            Id = id;
            Description = description;
            Priority = priority;
            Status = status;
        }
        public Task(int id, string description, Priorities priority, Statuses status, DateTime deadline) : this(id, description, priority, status)
        {
            Deadline = deadline;
        }

    }
}
