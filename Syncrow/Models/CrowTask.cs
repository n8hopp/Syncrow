using System;
using SQLite;
using System.Text.Json;

namespace Syncrow.Models;
	
[Table("crowTasks")]
public class CrowTask
{
	[MaxLength(128)]
	public string Title { get; set; }

	[MaxLength(1024)]
	public string Description { get; set; }
	public int Urgency { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
    public int Completion
    {
		get { return Completion; }
        set
        {
            if (value >= 0 && value <= 100) Completion = value;
            else throw new ArgumentOutOfRangeException("Completion must be >=0 && <= 100");
        }
    }

    public bool Repeating { get; set; }
	public bool Pinned { get; set; }

	public CrowTask(string title)
	{
		Title = title;
		Description = "";
		Urgency = 0;
		StartDate = DateTime.Now;
		EndDate = DateTime.Now;
		Completion = 0;
		Repeating = false;
		Pinned = false;
		// then prompt user for filling out rest of fields
	}

}


