using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncrow.Models;

[Table("quickTasks")]
class QuickTask
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(128)]
    public string Title { get; set; }

    [MaxLength(1024)]
    public string Description { get; set; }

    public int Urgency { get; set; }
}
