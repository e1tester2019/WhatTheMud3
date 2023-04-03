using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using WhatTheMud3.ViewModels.DrillStringBuilder;
using WhatTheMud3.Views.DrillStringBuilder;
using Syncfusion.Maui.Core.Hosting;

namespace WhatTheMud3;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.ConfigureSyncfusionCore()
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<PumperPageViewModel>();
		builder.Services.AddSingleton<PumperPage>();
		builder.Services.AddSingleton<SettingsPageViewModel>();
		builder.Services.AddSingleton<SettingsPage>();
		builder.Services.AddSingleton<DrillStringBuilderPageViewModel>();
		builder.Services.AddSingleton<DrillStringBuilderPage>();
		builder.Services.AddSingleton<DrillStringSegmentsPage>();
		builder.Services.AddSingleton<DownholeToolsPage>();
		builder.Services.AddSingleton<RestrictionsPage>();

		builder.Services.AddTransient<EditDrillStringSegmentPageViewModel>();
		builder.Services.AddTransient<EditDrillStringSegmentPage>();
		

		builder.Services.AddSingleton<AppModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}