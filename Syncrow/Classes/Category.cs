using System;
using System.Text.Json;
namespace Syncrow.Classes
{
	public class Category
	{
		private string name;
		private Color? color;
		private Image? icon;
		private List<CrowTask> tasks;

		public Category()
		{
			Name = "Empty";
			Color = new Color(255, 255, 255);
			Icon = null;
		}

		public Category(string name, Color color, Image icon)
		{
			Name = name;
			Color = color;
			Icon = null;
			tasks = new List<CrowTask>();
		}

        public void AddTask(CrowTask task)
        {
            tasks.Add(task);
        }

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public Color Color
		{
			get { return color; }
			set { color = value; }
		}

		public Image Icon
		{
			get { return icon; }
			set { icon = value; }
		}

		public List<CrowTask> Tasks
		{
			get { return tasks; }
		}

		public TaskBook TaskBook
		{
			get { return taskBook; }
			set { taskBook = value; }
		}

        public string Jsonify()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}

