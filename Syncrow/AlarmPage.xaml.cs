using Syncrow.Classes;
using System.Diagnostics;

namespace Syncrow;

public partial class AlarmPage : ContentPage
{
	public AlarmPage()
	{
		InitializeComponent();

        CrowTask task = new CrowTask("Test");
		task.Description = "Hello this is a test description";
		task.StartDate = DateTime.Parse("2022-01-05");

		Category category = new Category("Test Category", new Color(255, 0, 0), new Image());
		category.AddTask(task);
		Debug.WriteLine(category.Jsonify());
	}
}
