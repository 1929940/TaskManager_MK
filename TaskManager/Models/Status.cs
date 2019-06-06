using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TaskManager
{
    public enum Statuses
    {
        New,
        [Description("In Progress")]
        InProgress,
        Completed
    }
}
