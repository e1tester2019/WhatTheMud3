using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace WhatTheMud3;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<MainPageViewModel>();
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<SettingsPage>();
		builder.Services.AddSingleton<PumperPage>();
		builder.Services.AddSingleton<PumperPageViewModel>();
		builder.Services.AddSingleton<SettingsPageViewModel>();

		builder.Services.AddSingleton<AppModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}