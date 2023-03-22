namespace WhatTheMud3.ViewModels;

public partial class MainPageViewModel : BaseViewModel
{
	[ObservableProperty] private string mainPageWellName;
	
	public MainPageViewModel(AppModel appModel)
	{
		Title = "My Main Page";
		mainPageWellName = appModel.WellName;
	}
	[RelayCommand]
	async Task GoToDrillStringBuilderPage()
	{
		await Shell.Current.GoToAsync($"{nameof(DrillStringBuilderPage)}", true);
	}
	[RelayCommand]
	public void ToggleDarkMode()
	{
		if (App.Current.UserAppTheme == AppTheme.Dark)
		{
			App.Current.UserAppTheme = AppTheme.Light;
		}
		else
		{
			App.Current.UserAppTheme = AppTheme.Dark;
		}
	}
}