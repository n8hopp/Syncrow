using System;
using System.Text.Json;
using SQLite;
namespace Syncrow.Models;

[Table("categories")]
public class Category
{
	public string Name { get; set; }
	public Color? Color { get; set; }
	public Image? Icon { get; set; }
	public List<CrowTask> Tasks { get; set; }

	public Category()
	{

	}
}

