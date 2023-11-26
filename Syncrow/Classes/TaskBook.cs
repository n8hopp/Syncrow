using System;
using System.Text.Json;

namespace Syncrow.Classes
{
	public class TaskBook
	{
		List<Category> categories;
		public TaskBook()
		{
			categories = new List<Category>();
		}

		public void AddCategory(Category category)
		{
			Categories.Add(category);
		}

		public List<Category> Categories
		{
			get { return categories; }
		}

		public string Jsonify()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}

