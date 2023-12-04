using Syncrow.ViewModels;

namespace Syncrow
{
    public partial class TaskPage : ContentPage
    {
        private readonly QuickTaskViewModel _viewModel;

        public TaskPage(QuickTaskViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.LoadQuickTasksAsync();
        }
    }
}