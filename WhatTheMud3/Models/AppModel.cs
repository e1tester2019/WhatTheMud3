namespace WhatTheMud3.Models;

public partial class AppModel : ObservableObject
{
	#region AppParameters

	[ObservableProperty] private string wellName;

	#endregion
	
	#region Collection Parameters

	[ObservableProperty] private ObservableCollection<Segment> drillString = new()
	{
		new Segment
		{
			Id = Guid.NewGuid(),
			OuterDiameter="177.8",
			InnerDiameter = "97.18",
			BottomDepth = "2000",
			TopDepth = "0",
			WeightInAir = "22.47",
			FluidType = "Oil Based Mud"
		}
	};

	#endregion

	[RelayCommand]
	public void AddDrillString()
	{
		DrillString.Add( new Segment
		{
			Id = Guid.NewGuid(),
			OuterDiameter="222.2",
			InnerDiameter = "97.18",
			BottomDepth = "2000",
			TopDepth = "0",
			WeightInAir = "22.47",
			FluidType = "Oil Based Mud"
		});
	}
}