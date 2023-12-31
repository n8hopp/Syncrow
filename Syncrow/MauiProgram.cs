﻿using Microsoft.Extensions.Logging;
using Syncrow.Data;
using Syncrow.ViewModels;

namespace Syncrow
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

    #if DEBUG
		    builder.Logging.AddDebug();
    #endif

            builder.Services.AddSingleton<DbContext>();
            builder.Services.AddSingleton<QuickTaskViewModel>();
            builder.Services.AddSingleton<TaskPage>();
            return builder.Build();
        }
    }
}