using System.Collections.ObjectModel;
using Windows.ApplicationModel.Store;
using CommunityToolkit.Mvvm.ComponentModel;
using Syncrow.Data;
using Syncrow.Models;

namespace Syncrow.ViewModels;

public partial class QuickTaskViewModel : ObservableObject
{
    private readonly DbContext _context;
    
    public QuickTaskViewModel(DbContext context)
    {
        _context = context;
    }

    [ObservableProperty]
    private ObservableCollection<QuickTask> _quickTasks;

    [ObservableProperty]
    private QuickTask _operatingQuickTask;

    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private string _busyText;

    private async Task LoadQuickTasksAsync()
    {
        /*
         * advantage of doing dbcontext as a more generic type -
         * don't need to do new files for all this stuff. can just do it like this:
         *
         * var crowTasks = await _context.GetAllAsync<CrowTask>();
         * var users = await _context.GetAllAsync<User>();
         */
        
        var quickTasks = await _context.GetAllAsync<QuickTask>();
        if (quickTasks is not null && quickTasks.Any())
        {
            if(QuickTasks is null)
                QuickTasks = new 
        }
    }
}