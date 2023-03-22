namespace WhatTheMud3.ViewModels.DrillStringBuilder;

public partial class DrillStringBuilderPageViewModel : BaseViewModel
{
	private readonly AppModel _appModel;
	[ObservableProperty] private Collection<Segment> drillString;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(ShouldNotImportDrillStringSections))]
	public bool shouldImportDrillStringSections = false;
	public bool ShouldNotImportDrillStringSections => !ShouldImportDrillStringSections;

	[ObservableProperty]
	[NotifyPropertyChangedFor(nameof(ShouldNotImportDownholeTools))]
	public bool shouldImportDownholeTools = false;
	public bool ShouldNotImportDownholeTools => !ShouldImportDownholeTools;

	public DrillStringBuilderPageViewModel(AppModel appModel)
	{
		Title = "Drill String Configurator";
		this._appModel = appModel;
		this.DrillString = appModel.DrillString;
	}

	[RelayCommand]
	async Task GoToDrillEditDrillStringSegmentPage(Segment drillStringSegment)
	{
		if (drillStringSegment is null)
		{
			drillStringSegment = new Segment();
			DrillString.Add(drillStringSegment);
		}

		if (DrillString.Count > 0)
		{
			ShouldImportDrillStringSections = false;
		}

		await Shell.Current.GoToAsync($"{nameof(EditDrillStringSegmentPage)}", true,
			new Dictionary<string, object>
			{
				{"DrillStringSegment", drillStringSegment}
			});
	}
	[RelayCommand]
	public void DeleteDrillStringSegment(Segment drillStringSegment)
	{
		if (drillStringSegment is null) return;
		DrillString.Remove(drillStringSegment);
		if (DrillString.Count == 0)
		{
			ShouldImportDrillStringSections = true;
		}
	}
	[RelayCommand]
	public void DeleteAllDrillStringSegments()
	{
		if (DrillString.Count > 0)
		{
			DrillString.Clear();
			ShouldImportDrillStringSections = true;
		}
	}
}