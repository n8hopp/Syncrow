#nullable enable
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Syncrow.Data;
using Syncrow.Models;

namespace Syncrow.ViewModels
{
    public partial class QuickTaskViewModel : ObservableObject
    {
        private readonly DbContext _context;
    
        public QuickTaskViewModel(DbContext context)
        {
            _context = context;
        }

        [ObservableProperty]
        private ObservableCollection<QuickTask> _quickTasks = new();

        [ObservableProperty]
        private QuickTask _operatingQuickTask = new();

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _busyText;
    
        public async Task LoadQuickTasksAsync()
        {
            /*
             * advantage of doing dbcontext as a more generic type -
             * don't need to do new files for all this stuff. can just do it like this:
             *
             * var crowTasks = await _context.GetAllAsync<CrowTask>();
             * var users = await _context.GetAllAsync<User>();
             */
            await ExecuteAsync(async () =>
            {
                var quickTasks = await _context.GetAllAsync<QuickTask>();
                if (quickTasks is not null && quickTasks.Any())
                {
                    QuickTasks ??= new ObservableCollection<QuickTask>();

                    foreach (var task in quickTasks)
                    {
                        QuickTasks.Add(task);
                    }
                }
            }, "Fetching quickTasks...");

        }

        [RelayCommand]
        private void SetOperatingQuickTask(QuickTask? quickTask) => OperatingQuickTask = quickTask ?? new();
    
        [RelayCommand]
        private async Task SaveQuickTaskAsync()
        {
            if (OperatingQuickTask is null)
                return;

            var (isValid, errorMessage) = OperatingQuickTask.Validate();
            if(!isValid)
            {
                await Shell.Current.DisplayAlert("Invalid quickTask", errorMessage, "Ok");
                return;
            }

            var busyText = OperatingQuickTask.Id == 0 ? "Creating quickTask..." : "Updating quickTask...";
            await ExecuteAsync(async () =>
            {
                if (OperatingQuickTask.Id == 0)
                {
                    // create quicktask
                    await _context.AddItemAsync<QuickTask>(OperatingQuickTask);
                    QuickTasks.Add(OperatingQuickTask);
                }
                else
                {
                    //update quicktask
                    if(await _context.UpdateItemAsync<QuickTask>(OperatingQuickTask))
                    {
                        var quickTaskCopy = OperatingQuickTask.Clone();

                        var index = QuickTasks.IndexOf(OperatingQuickTask);
                        QuickTasks.RemoveAt(index);

                        QuickTasks.Insert(index, quickTaskCopy);
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Quicktask Update Error", "Ok");
                        return;
                    }

                    
                }

                SetOperatingQuickTaskCommand.Execute(new());
            }, busyText);
        }

        [RelayCommand]
        private async Task DeleteQuickTaskAsync(int id)
        {
            await ExecuteAsync(async () =>
            {
                // ReSharper disable once HeapView.BoxingAllocation
                if (await _context.DeleteItemByKeyAsync<QuickTask>(id))
                {
                    var quickTask = QuickTasks.FirstOrDefault(p => p.Id == id);
                    QuickTasks.Remove(quickTask);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Delete Error", "QuickTask was not deleted", "Ok");
                }
            }, "Deleting quickTask");
        }

        private async Task ExecuteAsync(Func<Task> operation, string busyText)
        {
            IsBusy = true;
            BusyText = busyText ?? "Processing...";
            try
            {
                await operation?.Invoke();
            }
            finally
            {
                IsBusy = false;
                BusyText = "Processing...";
            }
        }
    
    }
}