using System;
using System.Text.Json;

namespace Syncrow.Classes
{
	public class CrowTask
	{
		private string title;
		private string description;
		private int urgency;
		private DateTime startDate;
		private DateTime endDate;
		private int completion;
		private bool repeating;
		private bool pinned;
		//private Category category;
		private TaskType taskType;

		public CrowTask(string title)
		{
			Title = title;
			description = "";
			urgency = 0;
			startDate = DateTime.Now;
			endDate = DateTime.Now;
			completion = 0;
			repeating = false;
			pinned = false;
			// then prompt user for filling out rest of fields
		}

		public string Jsonify()
		{
			return JsonSerializer.Serialize(this);
		}

		public string Title
		{
			get { return title; }
			set { title = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}

		public int Urgency
		{
			get { return urgency; }
			set { urgency = value; }
		}

		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}

		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}

		public int Completion
		{
			get { return completion; }
			set
			{
				if (value >= 0 && value <= 100) completion = value;
				else throw new ArgumentOutOfRangeException("Completion must be >=0 && <= 100");
			}
		}

		public bool Repeating
		{
			get { return repeating; }
			set { repeating = value; }
		}

		public bool Pinned
		{
			get { return pinned; }
			set { pinned = value; }
		}

		//public Category Category
		//{
		//	get { return category; }
		//	set { category = value; }
		//}

		public TaskType TaskType
		{
			get { return taskType; }
			set { taskType = value; }
		}

    }
}

