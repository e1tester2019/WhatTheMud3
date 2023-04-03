namespace WhatTheMud3.ViewModels.DrillStringBuilder;


[QueryProperty("DrillStringSegment", "DrillStringSegment")]
public partial class EditDrillStringSegmentPageViewModel : BaseViewModel
{
	public EditDrillStringSegmentPageViewModel()
	{
		Title = "Edit Drill String Segment Page";
	}

	[ObservableProperty] private Segment drillStringSegment;

	[RelayCommand]
	async Task UpdateSegment()
	{
		await Shell.Current.GoToAsync("..", true);
	}
}