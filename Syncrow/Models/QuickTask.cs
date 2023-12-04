using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syncrow.Models;

[Table("quickTasks")]
public class QuickTask
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }

    public int Urgency { get; set; }
    
    public QuickTask Clone() => MemberwiseClone() as QuickTask;
}
